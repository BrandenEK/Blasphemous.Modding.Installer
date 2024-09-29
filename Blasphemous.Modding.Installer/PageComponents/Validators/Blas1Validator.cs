using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.Properties;
using Ionic.Zip;
using System.Net;

namespace Blasphemous.Modding.Installer.PageComponents.Validators;

internal class Blas1Validator : IValidator
{
    private readonly string _exeName = "Blasphemous.exe";
    private readonly string _defaultPath = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Blasphemous";

    private ToolStatus _currentStatus = ToolStatus.Checking;

    public Blas1Validator()
    {
        UIHandler.OnPageOpened += OnPageOpened;
        UIHandler.OnPathChanged += OnPathChanged;
    }

    private void OnPageOpened(InstallerPage page)
    {
        if (page.Validator != this || !IsRootFolderValid)
            return;

        RefreshAndUpdateStatus();
    }

    private void OnPathChanged(string path)
    {
        if (Core.CurrentPage.Validator != this || !IsRootFolderValid)
            return;

        RefreshAndUpdateStatus();
    }

    private ToolStatus GetCurrentStatus()
    {
        // These temporary states need to be manually deactivated
        //if (_currentStatus == ToolStatus.Checking)
        //    return;
        if (_currentStatus == ToolStatus.Downloading)
            return _currentStatus;

        if (!AreModdingToolsInstalled)
            return ToolStatus.NotInstalled;

        if (!AreModdingToolsUpdated)
            return ToolStatus.InstalledNotUpdated;

        return _currentStatus = ToolStatus.InstalledAndUpdated;
    }

    private void SetAndUpdateStatus(ToolStatus status)
    {
        _currentStatus = status;
        UpdateStatusUI();
    }

    private void RefreshAndUpdateStatus()
    {
        _currentStatus = GetCurrentStatus();
        UpdateStatusUI();
    }

    private void InvalidateAndUpdateStatus()
    {
        _currentStatus = ToolStatus.Invalid;
        _currentStatus = GetCurrentStatus();
        UpdateStatusUI();
    }

    private void UpdateStatusUI()
    {
        string text = _currentStatus switch
        {
            ToolStatus.Checking => "Checking for updates...",
            ToolStatus.Downloading => "Downloading...",
            ToolStatus.NotInstalled => "Not installed - Click to download",
            ToolStatus.InstalledNotUpdated => "Update available - Click to download",
            ToolStatus.InstalledAndUpdated => "Installed and updated",
            _ => throw new Exception($"Invalid tool status: {_currentStatus}")
        };

        Bitmap icon = _currentStatus switch
        {
            ToolStatus.Checking => Resources.icon_circles_light,
            ToolStatus.Downloading => Resources.icon_dash_light,
            ToolStatus.NotInstalled => Resources.icon_x_light,
            ToolStatus.InstalledNotUpdated => Resources.icon_arrow_light,
            ToolStatus.InstalledAndUpdated => Resources.icon_check_light,
            _ => throw new Exception($"Invalid tool status: {_currentStatus}")
        };

        Core.UIHandler.UpdateToolStatus(text, icon);
    }

    public async void OnClickToolStatus()
    {
        if (_currentStatus != ToolStatus.NotInstalled && _currentStatus != ToolStatus.InstalledNotUpdated)
            return;

        Logger.Info("Installing modding tools");
        SetAndUpdateStatus(ToolStatus.Downloading);
        await InstallModdingTools();
        InvalidateAndUpdateStatus();
    }










    public async Task InstallModdingTools()
    {
        string toolsCache = Path.Combine(Core.CacheFolder, "tools", "blas1.zip");
        Directory.CreateDirectory(Path.GetDirectoryName(toolsCache));

        // If tools dont already exist in cache, download from web
        if (!File.Exists(toolsCache))
        {
            Logger.Warn("Downloading blas1 tools from web");
            using (WebClient client = new WebClient())
            {
                string toolsPath = "https://github.com/BrandenEK/Blasphemous.ModdingTools/raw/main/modding-tools-windows.zip";
                await client.DownloadFileTaskAsync(new Uri(toolsPath), toolsCache);
            }
        }

        // Extract data in cache to game folder
        string installPath = Core.SettingsHandler.Properties.Blas1RootFolder;
        using (ZipFile zipFile = ZipFile.Read(toolsCache))
        {
            foreach (ZipEntry file in zipFile)
                file.Extract(installPath, ExtractExistingFileAction.OverwriteSilently);
        }
    }

    public void SetRootPath(string path)
    {
        Core.SettingsHandler.Properties.Blas1RootFolder = path;
    }

    public bool IsRootFolderValid
    {
        get
        {
            string path = Core.SettingsHandler.Properties.Blas1RootFolder;
            if (File.Exists(path + "\\" + _exeName))
            {
                Directory.CreateDirectory(path + "\\Modding\\disabled");
                return true;
            }

            return false;
        }
    }

    public bool AreModdingToolsInstalled
    {
        get
        {
            bool installed = Directory.Exists(Core.SettingsHandler.Properties.Blas1RootFolder + "\\BepInEx");
            
            // Temporary delete old folders I dont want anymore
            if (installed)
            {
                string docs = Path.Combine(Core.SettingsHandler.Properties.Blas1RootFolder, "Modding", "docs");
                if (Directory.Exists(docs))
                    Directory.Delete(docs, true);

                string output = Path.Combine(Core.SettingsHandler.Properties.Blas1RootFolder, "Modding", "output");
                if (Directory.Exists(output))
                    Directory.Delete(output, true);
            }

            return installed;
        }
    }

    public bool AreModdingToolsUpdated => true;

    public string ExeName => _exeName;
    public string DefaultPath => string.IsNullOrEmpty(Core.SettingsHandler.Properties.Blas1RootFolder)
        ? _defaultPath
        : Core.SettingsHandler.Properties.Blas1RootFolder;

    enum ToolStatus
    {
        Checking,
        Downloading,
        NotInstalled,
        InstalledNotUpdated,
        InstalledAndUpdated,
        Invalid
    }
}
