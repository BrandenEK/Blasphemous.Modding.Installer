using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.PageComponents.Listers;
using Blasphemous.Modding.Installer.Skins;
using Newtonsoft.Json;
using Octokit;

namespace Blasphemous.Modding.Installer.PageComponents.Loaders;

internal class SkinLoader : ILoader
{
    private readonly string _localDataPath;
    private readonly string _remoteDataPath;
    private readonly bool _ignoreTime;
    private readonly ILister _lister;
    private readonly List<Skin> _skins;
    private readonly SectionType _skinType;
    private readonly PageSettings _pageSettings;
    private readonly GameSettings _gameSettings;

    private bool _loadedData;

    public SkinLoader(string remoteDataPath, bool ignoreTime, ILister lister, List<Skin> skins, SectionType skinType, PageSettings pageSettings, GameSettings gameSettings)
    {
        _pageSettings = pageSettings;
        _gameSettings = gameSettings;

        _localDataPath = Path.Combine(Core.CacheFolder, $"{_pageSettings.Id}.json");
        _remoteDataPath = remoteDataPath;
        _ignoreTime = ignoreTime;
        _lister = lister;
        _skins = skins;
        _skinType = skinType;
    }

    public void LoadAllData()
    {
        if (_loadedData)
            return;

        LoadLocalSkins();

        if (_ignoreTime || DateTime.Now >= _pageSettings.Time)
        {
            LoadRemoteSkins();
            _pageSettings.Time = DateTime.Now.AddHours(0.5);
            Logger.Warn($"Next remote loading: {_pageSettings.Time}");
        }
        else
        {
            Logger.Warn("Skipping remote loading");
        }

        _loadedData = true;
    }

    private void LoadLocalSkins()
    {
        if (File.Exists(_localDataPath))
        {
            string json = File.ReadAllText(_localDataPath);
            SkinData[] localData = JsonConvert.DeserializeObject<SkinData[]>(json)!;

            for (int i = 0; i < localData.Length; i++)
            {
                _skins.Add(new Skin(localData[i], _skinType, _gameSettings));
            }
        }

        Logger.Warn($"Loaded {_skins.Count} local skins");
        _lister.RefreshList();
    }

    private async void LoadRemoteSkins()
    {
        var newSkins = new List<Skin>();
        using var client = new HttpClient();

        IReadOnlyList<Octokit.RepositoryContent> contents =
                await Core.GithubHandler.GetRepositoryDirectoryAsync("BrandenEK", "Blasphemous.Community.Skins", _remoteDataPath);

        if (contents is null)
            return;

        foreach (var item in contents)
        {
            Skin skin = await LoadSkin(item, client, Core.HTTP_TIMEOUT);
            newSkins.Add(skin);
        }

        Logger.Warn($"Loaded {contents.Count} global skins");
        _skins.Clear();
        _skins.AddRange(newSkins);

        SaveLocalData();
        _lister.RefreshList();
    }

    private async Task<Skin> LoadSkin(RepositoryContent item, HttpClient client, int timeout)
    {
        try
        {
            string json = await client.GetStringAsync($"https://raw.githubusercontent.com/BrandenEK/Blasphemous.Community.Skins/main/{_remoteDataPath}/{item.Name}/info.txt");
            SkinData data = JsonConvert.DeserializeObject<SkinData>(json)!;

            Skin? localSkin = FindSkin(data.id);

            if (localSkin == null)
                return new Skin(data, _skinType, _gameSettings);

            localSkin.Data = data;
            localSkin.UpdateUI();
            return localSkin;
        }
        catch (HttpRequestException ex)
        {
            if (ex.StatusCode != System.Net.HttpStatusCode.TooManyRequests)
                throw;

            Logger.Warn($"HTTP 429 error with skin {item.Name}.  Retrying...");
            await Task.Delay(timeout);
            return await LoadSkin(item, client, timeout + Core.HTTP_TIMEOUT);
        }
    }

    private void SaveLocalData()
    {
        File.WriteAllText(_localDataPath, JsonConvert.SerializeObject(_skins.Select(x => x.Data)));
    }

    private Skin? FindSkin(string id)
    {
        return _skins.Find(x => x.Data.id == id);
    }
}
