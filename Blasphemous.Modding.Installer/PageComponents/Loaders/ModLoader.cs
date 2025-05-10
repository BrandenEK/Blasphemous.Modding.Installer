using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.Mods;
using Blasphemous.Modding.Installer.PageComponents.Listers;
using Blasphemous.Modding.Installer.Skins;
using Newtonsoft.Json;

namespace Blasphemous.Modding.Installer.PageComponents.Loaders;

internal class ModLoader : ILoader
{
    private readonly string _localDataPath;
    private readonly string _remoteDataPath;
    private readonly bool _ignoreTime;
    private readonly ILister _lister;
    private readonly List<Mod> _mods;
    private readonly SectionType _modType;
    private readonly PageSettings _pageSettings;
    private readonly GameSettings _gameSettings;

    private bool _loadedData;

    public ModLoader(string remoteDataPath, bool ignoreTime, ILister lister, List<Mod> mods, SectionType modType, PageSettings pageSettings, GameSettings gameSettings)
    {
        _pageSettings = pageSettings;
        _gameSettings = gameSettings;

        _localDataPath = Path.Combine(Core.CacheFolder, $"{_pageSettings.Id}.json");
        _remoteDataPath = remoteDataPath;
        _ignoreTime = ignoreTime;
        _lister = lister;
        _mods = mods;
        _modType = modType;
    }

    public void LoadAllData()
    {
        if (_loadedData)
            return;

        LoadLocalMods();

        if (_ignoreTime || DateTime.Now >= _pageSettings.Time)
        {
            LoadRemoteMods();
            _pageSettings.Time = DateTime.Now.AddHours(0.5);
            Logger.Warn($"Next remote loading: {_pageSettings.Time}");
        }
        else
        {
            Logger.Warn("Skipping remote loading");
        }

        _loadedData = true;
    }

    private void LoadLocalMods()
    {
        if (File.Exists(_localDataPath))
        {
            string json = File.ReadAllText(_localDataPath);
            ModData[] localData = JsonConvert.DeserializeObject<ModData[]>(json)!;

            for (int i = 0; i < localData.Length; i++)
            {
                _mods.Add(new Mod(localData[i], _modType, _gameSettings));
            }
        }

        Logger.Warn($"Loaded {_mods.Count} local mods");
        _lister.RefreshList();
    }

    private async void LoadRemoteMods()
    {
        var newMods = new List<Mod>();
        using var client = new HttpClient();

        string json = await client.GetStringAsync(_remoteDataPath);
        ModData[] remoteData = JsonConvert.DeserializeObject<ModData[]>(json)!;

        foreach (var data in remoteData)
        {
            Logger.Info($"Getting latest release for {data.name}");

            Mod? mod = await LoadMod(data, Core.HTTP_TIMEOUT);
            if (mod != null)
                newMods.Add(mod);
        }

        Logger.Warn($"Loaded {remoteData.Length} global mods");
        _mods.Clear();
        _mods.AddRange(newMods);

        SaveLocalData();
        _lister.RefreshList();
    }

    private async Task<Mod?> LoadMod(ModData data, int timeout)
    {
        try
        {
            Octokit.Release latestRelease = await Core.GithubHandler.GetLatestReleaseAsync(data.githubAuthor, data.githubRepo);
            if (latestRelease is null)
                return null;

            Version latestVersion = GithubHandler.CleanSemanticVersion(latestRelease.TagName);
            string latestDownloadURL = latestRelease.Assets[0].BrowserDownloadUrl;
            DateTimeOffset latestReleaseDate = latestRelease.CreatedAt;

            Mod? localMod = FindMod(data.name);
            ModData fullData = new ModData(data, latestVersion.ToString(), latestDownloadURL, latestReleaseDate);

            if (localMod == null)
                return new Mod(fullData, _modType, _gameSettings);

            localMod.Data = fullData;
            localMod.UpdateUI();
            return localMod;
        }
        catch (HttpRequestException ex)
        {
            if (ex.StatusCode != System.Net.HttpStatusCode.TooManyRequests)
                throw;

            Logger.Warn($"HTTP 429 error with mod {data.name}.  Retrying...");
            await Task.Delay(timeout);
            return await LoadMod(data, timeout + Core.HTTP_TIMEOUT);
        }
    }

    private void SaveLocalData()
    {
        File.WriteAllText(_localDataPath, JsonConvert.SerializeObject(_mods.Select(x => x.Data)));
    }

    private Mod? FindMod(string name)
    {
        return _mods.Find(x => x.Data.name == name);
    }

    public IEnumerable<string> GetUnusedDlls(Mod mod)
    {
        if (mod.Data.requiredDlls == null || mod.Data.requiredDlls.Length == 0)
            return Enumerable.Empty<string>();

        return mod.Data.requiredDlls
            .Where(d => !_mods.Where(m => m.RequiresDll(d) && m.Installed).Any());
    }

    // Get list of mods that this mod requires that need to be enabled
    public IEnumerable<Mod> GetModDependencies(Mod mod)
    {
        var depends = _mods.Where(x => mod.HasDependency(x.Data.name));
        depends = depends.Concat(depends.SelectMany(x => GetModDependencies(x)));
        depends = depends.Distinct().Where(x => !x.Enabled);

        return depends;
    }

    // Get list of mods that require this mod that need to be disabled
    public IEnumerable<Mod> GetModDependents(Mod mod)
    {
        var depends = _mods.Where(x => x.HasDependency(mod.Data.name));
        depends = depends.Concat(depends.SelectMany(x => GetModDependents(x)));
        depends = depends.Distinct().Where(x => x.Enabled);

        return depends;
    }
}
