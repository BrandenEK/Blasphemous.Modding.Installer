using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.Config;
using Blasphemous.Modding.Installer.Mods;
using Blasphemous.Modding.Installer.PageComponents.Listers;
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
    private readonly PageSettings _settings;

    private bool _loadedData;

    public ModLoader(string localDataPath, string remoteDataPath, bool ignoreTime, ILister lister, List<Mod> mods, SectionType modType, PageSettings settings)
    {
        _localDataPath = localDataPath;
        _remoteDataPath = remoteDataPath;
        _ignoreTime = ignoreTime;
        _lister = lister;
        _mods = mods;
        _modType = modType;
        _settings = settings;
    }

    public void LoadAllData()
    {
        if (_loadedData)
            return;

        LoadLocalMods();

        if (_ignoreTime || DateTime.Now >= _settings.Time)
        {
            LoadRemoteMods();
            _settings.Time = DateTime.Now.AddHours(0.5);
            Logger.Warn($"Next remote loading: {_settings.Time}");
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
                _mods.Add(new Mod(localData[i], _modType));
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
            Octokit.Release latestRelease = await Core.GithubHandler.GetLatestReleaseAsync(data.githubAuthor, data.githubRepo);
            if (latestRelease is null)
                return;

            Version latestVersion = GithubHandler.CleanSemanticVersion(latestRelease.TagName);
            string latestDownloadURL = latestRelease.Assets[0].BrowserDownloadUrl;
            DateTimeOffset latestReleaseDate = latestRelease.CreatedAt;

            Mod? localMod = FindMod(data.name);
            ModData fullData = new ModData(data, latestVersion.ToString(), latestDownloadURL, latestReleaseDate);

            if (localMod != null)
            {
                localMod.Data = fullData;
                localMod.UpdateUI();
                newMods.Add(localMod);
            }
            else
            {
                newMods.Add(new Mod(fullData, _modType));
            }
        }

        Logger.Warn($"Loaded {remoteData.Length} global mods");
        _mods.Clear();
        _mods.AddRange(newMods);

        SaveLocalData();
        _lister.RefreshList();
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
