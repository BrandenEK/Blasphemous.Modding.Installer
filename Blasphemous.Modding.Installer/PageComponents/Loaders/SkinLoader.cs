using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.PageComponents.Sorters;
using Blasphemous.Modding.Installer.PageComponents.UIHolders;
using Blasphemous.Modding.Installer.Skins;
using Newtonsoft.Json;

namespace Blasphemous.Modding.Installer.PageComponents.Loaders;

internal class SkinLoader : ILoader
{
    private readonly string _localDataPath;
    private readonly string _remoteDataPath;
    private readonly IUIHolder _uiHolder;
    private readonly ISorter _sorter;
    private readonly List<Skin> _skins;
    private readonly SectionType _skinType;

    private bool _loadedData;

    public SkinLoader(string localDataPath, string remoteDataPath, IUIHolder uiHolder, ISorter sorter, List<Skin> skins, SectionType skinType)
    {
        _localDataPath = localDataPath;
        _remoteDataPath = remoteDataPath;
        _uiHolder = uiHolder;
        _sorter = sorter;
        _skins = skins;
        _skinType = skinType;
    }

    public void LoadAllData()
    {
        if (_loadedData)
            return;

        LoadLocalSkins();

        if (Core.TempIgnoreTime || DateTime.Now >= Core.SettingsHandler.Properties.CurrentTime)
        {
            LoadRemoteSkins();
            DateTime next = DateTime.Now.AddHours(0.5);
            Core.SettingsHandler.Properties.SetTime(_skinType, next);
            Logger.Warn($"Next remote loading: {next}");
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
                _skins.Add(new Skin(localData[i], _uiHolder.SectionPanel, _skinType));
            }
        }

        Logger.Warn($"Loaded {_skins.Count} local skins");
        _uiHolder.SetBackgroundColor();
        _sorter.Sort();
    }

    private async void LoadRemoteSkins()
    {
        var newSkins = new List<Skin>();

        using (HttpClient client = new HttpClient())
        {
            IReadOnlyList<Octokit.RepositoryContent> contents =
                await Core.GithubHandler.GetRepositoryDirectoryAsync("BrandenEK", "Blasphemous-Custom-Skins", _remoteDataPath);

            if (contents is null)
                return;

            foreach (var item in contents)
            {
                string json = await client.GetStringAsync($"https://raw.githubusercontent.com/BrandenEK/Blasphemous-Custom-Skins/main/{_remoteDataPath}/{item.Name}/info.txt");
                SkinData data = JsonConvert.DeserializeObject<SkinData>(json)!;

                Skin? localSkin = FindSkin(data.id);
                if (localSkin != null)
                {
                    localSkin.Data = data;
                    localSkin.UpdateUI();
                    newSkins.Add(localSkin);
                }
                else
                {
                    newSkins.Add(new Skin(data, _uiHolder.SectionPanel, _skinType));
                }
            }

            Logger.Warn($"Loaded {contents.Count} global skins");
            _skins.Clear();
            _skins.AddRange(newSkins);
        }

        SaveLocalData();
        _uiHolder.SetBackgroundColor();
        _sorter.Sort();
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
