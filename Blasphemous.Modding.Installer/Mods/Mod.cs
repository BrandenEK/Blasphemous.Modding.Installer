using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.PageComponents.Loaders;
using Ionic.Zip;
using System.Diagnostics;
using System.Net;
using System.Text;

namespace Blasphemous.Modding.Installer.Mods;

internal class Mod
{
    private readonly ModUI _ui;
    private readonly SectionType _modType;

    private bool _downloading = false;

    public Mod(ModData data, Panel panel, SectionType modType)
    {
        Data = data;
        _modType = modType;
        _ui = new ModUI(this, panel);
        SetUIPosition(-1);
        UpdateUI();
    }

    public ModData Data { get; set; }

    private InstallerPage ModPage => _modType == SectionType.Blas1Mods
        ? Core.Blas1ModPage
        : Core.Blas2ModPage;

    public bool RequiresDll(string dllName) =>
        Data.requiredDlls != null && Data.requiredDlls.Contains(dllName);

    public bool HasDependency(string modName) =>
        Data.dependencies != null && Data.dependencies.Contains(modName);

    public bool Installed => File.Exists(PathToEnabledPlugin) || File.Exists(PathToDisabledPlugin);
    public bool Enabled => File.Exists(PathToEnabledPlugin);

    public Version LocalVersion
    {
        get
        {
            string filePath;
            if (File.Exists(PathToEnabledPlugin))
                filePath = PathToEnabledPlugin;
            else if (File.Exists(PathToDisabledPlugin))
                filePath = PathToDisabledPlugin;
            else
                return null;

            return new Version(FileVersionInfo.GetVersionInfo(filePath).FileVersion);
        }
    }

    public bool UpdateAvailable
    {
        get
        {
            if (!Installed)
                return false;

            return new Version(Data.latestVersion).CompareTo(LocalVersion) > 0;
        }
    }

    // Paths

    private string RootFolder => Core.SettingsHandler.Properties.GetRootPath(_modType);
    public string GithubLink => $"https://github.com/{Data.githubAuthor}/{Data.githubRepo}";

    public string PathToEnabledPlugin => $"{RootFolder}/Modding/plugins/{Data.pluginFile}";
    public string PathToDisabledPlugin => $"{RootFolder}/Modding/disabled/{Data.pluginFile}";
    public string PathToConfigFile => $"{RootFolder}/Modding/config/{Data.name}.cfg";
    public string PathToContentFolder => $"{RootFolder}/Modding/content/{Data.name}";
    public string PathToDataFolder => $"{RootFolder}/Modding/data/{Data.name}";
    public string PathToKeybindingsFile => $"{RootFolder}/Modding/keybindings/{Data.name}.txt";
    public string PathToLevelsFolder => $"{RootFolder}/Modding/levels/{Data.name}";
    public string PathToLocalizationFile => $"{RootFolder}/Modding/localization/{Data.name}.txt";

    public bool ExistsInCache(string fileName, out string cachePath)
    {
        cachePath = $"{Core.CacheFolder}/blas{(_modType == SectionType.Blas1Mods ? "1" : "2")}mods/{Data.name}/{Data.latestVersion}/{fileName}";
        Directory.CreateDirectory(Path.GetDirectoryName(cachePath));

        return File.Exists(cachePath) && new FileInfo(cachePath).Length > 0;
    }

    // Main methods

    public async void Install(bool skipDepend)
    {
        // Check for dependencies first
        if (!skipDepend && !AreDependenciesEnabled())
            return;

        string installPath = RootFolder + "/Modding";
        Directory.CreateDirectory(installPath);

        // Check for data in the cache
        bool zipExists = ExistsInCache("data.zip", out string zipCache);

        // If it was missing, download it from web to cache
        if (!zipExists)
        {
            await DownloadMod(zipCache);
        }

        // Extract data in cache to game folder
        using (ZipFile zipFile = ZipFile.Read(zipCache))
        {
            foreach (ZipEntry file in zipFile)
                file.Extract(installPath, ExtractExistingFileAction.OverwriteSilently);
        }

        UpdateUI();
    }

    private async Task DownloadMod(string zipCache)
    {
        Logger.Warn($"Downloading mod ({Data.name}) from web");
        using (WebClient client = new WebClient())
        {
            _downloading = true;
            _ui.ShowDownloadingStatus();

            await client.DownloadFileTaskAsync(new Uri(Data.latestDownloadURL), zipCache);

            _downloading = false;
        }
    }

    public void Uninstall(bool skipDepend)
    {
        // Check for dependents first
        if (!skipDepend && !AreDependentsDisabled())
            return;

        if (File.Exists(PathToEnabledPlugin))
            File.Delete(PathToEnabledPlugin);
        if (File.Exists(PathToDisabledPlugin))
            File.Delete(PathToDisabledPlugin);
        // Keep config file
        // Keep content folder
        if (Directory.Exists(PathToDataFolder))
            Directory.Delete(PathToDataFolder, true);
        if (File.Exists(PathToKeybindingsFile))
            File.Delete(PathToKeybindingsFile);
        if (Directory.Exists(PathToLevelsFolder))
            Directory.Delete(PathToLevelsFolder, true);
        if (File.Exists(PathToLocalizationFile))
            File.Delete(PathToLocalizationFile);

        RemoveUnusedDlls();
        UpdateUI();
    }

    public void Enable(bool skipDepend)
    {
        // Check for dependencies first
        if (!skipDepend && !AreDependenciesEnabled())
            return;

        string enabled = PathToEnabledPlugin;
        string disabled = PathToDisabledPlugin;
        if (File.Exists(disabled))
        {
            if (!File.Exists(enabled))
                File.Move(disabled, enabled);
            else
                File.Delete(disabled);
        }

        UpdateUI();
    }

    public void Disable(bool skipDepend)
    {
        // Check for dependents first
        if (!skipDepend && !AreDependentsDisabled())
            return;

        string enabled = PathToEnabledPlugin;
        string disabled = PathToDisabledPlugin;
        if (File.Exists(enabled))
        {
            if (!File.Exists(disabled))
                File.Move(enabled, disabled);
            else
                File.Delete(enabled);
        }

        UpdateUI();
    }

    // Helper methods

    private void RemoveUnusedDlls()
    {
        ModLoader modLoader = ModPage.Loader as ModLoader;
        IEnumerable<string> unused = modLoader.GetUnusedDlls(this);

        foreach (string dll in unused)
        {
            string dllPath = RootFolder + "/Modding/data/" + dll;
            if (File.Exists(dllPath))
                File.Delete(dllPath);
        }
    }

    private bool AreDependenciesEnabled()
    {
        ModLoader modLoader = ModPage.Loader as ModLoader;
        IEnumerable<Mod> dependencies = modLoader.GetModDependencies(this);
        Logger.Warn($"Found dependencies: {string.Join(", ", dependencies.Select(x => x.Data.name))}");

        if (!dependencies.Any())
            return true;

        // Build list of mod names
        var sb = new StringBuilder("This mod has dependencies on the following mods:").AppendLine();
        foreach (var mod in dependencies)
            sb.Append("- ").AppendLine(mod.Data.name);
        sb.AppendLine().Append("Download and enable them now?");

        // Prompt if they want to download dependencies
        if (MessageBox.Show(sb.ToString(), Data.name, MessageBoxButtons.OKCancel) != DialogResult.OK)
            return false;

        // Download and enable all dependencies
        Logger.Info("Enabling dependencies for " + Data.name);
        foreach (Mod mod in dependencies)
        {
            if (mod.UpdateAvailable)
                mod.Uninstall(true);
            if (!mod.Installed)
                mod.Install(true);
            mod.Enable(true);
        }

        return true;
    }

    private bool AreDependentsDisabled()
    {
        ModLoader modLoader = ModPage.Loader as ModLoader;
        IEnumerable<Mod> dependents = modLoader.GetModDependents(this);
        Logger.Warn($"Found dependents: {string.Join(", ", dependents.Select(x => x.Data.name))}");

        if (!dependents.Any())
            return true;

        // Build list of mod names
        var sb = new StringBuilder("This mod has dependents that rely on it:").AppendLine();
        foreach (var mod in dependents)
            sb.Append("- ").AppendLine(mod.Data.name);
        sb.AppendLine().Append("Disable them now?");

        // Prompt if they want to disable dependencies
        if (MessageBox.Show(sb.ToString(), Data.name, MessageBoxButtons.OKCancel) != DialogResult.OK)
            return false;

        // Disable all dependencies
        Logger.Info("Disabling dependents for " + Data.name);
        foreach (Mod mod in dependents)
        {
            mod.Disable(true);
        }

        return true;
    }

    // Click methods

    public void ClickedInstall(object sender, EventArgs e)
    {
        if (_downloading) return;

        if (Installed)
        {
            if (MessageBox.Show("Are you sure you want to uninstall this mod?", Data.name, MessageBoxButtons.OKCancel) == DialogResult.OK)
                Uninstall(false);
        }
        else
        {
            Install(false);
        }
    }

    public void ClickedEnable(object sender, EventArgs e)
    {
        if (Enabled)
            Disable(false);
        else
            Enable(false);
    }

    public void ClickedUpdate(object sender, EventArgs e)
    {
        Uninstall(true);
        Install(false);
    }

    public void ClickedReadme(object sender, EventArgs e)
    {
        try
        {
            Process.Start(new ProcessStartInfo(GithubLink)
            {
                UseShellExecute = true
            });
        }
        catch
        {
            MessageBox.Show("Link does not exist!", "Invalid Link");
        }
    }

    // UI methods

    public void UpdateUI()
    {
        _ui.UpdateUI(Data.name, (Installed ? LocalVersion.ToString(3) : Data.latestVersion), Data.author, Installed, Enabled, UpdateAvailable);
    }

    public void SetUIPosition(int modIdx)
    {
        _ui.SetPosition(modIdx);
    }

    public void OnStartHover() => ModPage.Previewer.PreviewMod(this);

    public void OnEndHover() => ModPage.Previewer.Clear();
}
