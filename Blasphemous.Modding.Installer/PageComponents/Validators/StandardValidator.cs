using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.Extensions;
using Blasphemous.Modding.Installer.Properties;
using Ionic.Zip;
using System.Diagnostics;

namespace Blasphemous.Modding.Installer.PageComponents.Validators;

internal abstract class StandardValidator : IValidator
{
    private readonly string _cacheDir;
    private readonly string _defaultPath;
    private readonly string _exeName;
    private readonly string _localVersionPath;
    private readonly string _remoteDownloadPath;
    private readonly string _remoteVersionPath;

    private ToolStatus _currentStatus = ToolStatus.Invalid;
    private string _remoteVersion = string.Empty;

    protected abstract string RootFolder { get; set; }

    public StandardValidator(string cacheDir, string defaultPath, string exeName, string localVersionPath, string remoteDownloadPath, string remoteVersionPath)
    {
        _cacheDir = cacheDir;
        _defaultPath = defaultPath;
        _exeName = exeName;
        _localVersionPath = localVersionPath;
        _remoteDownloadPath = remoteDownloadPath;
        _remoteVersionPath = remoteVersionPath;

        UIHandler.OnPageOpened += OnPageOpened;
        UIHandler.OnPathChanged += OnPathChanged;
    }

    private void OnPageOpened(InstallerPage page)
    {
        if (page.Validator != this)
            return;

        if (!IsRootFolderValid)
        {
            Core.UIHandler.HideToolStatus();
        }
        else if (_currentStatus == ToolStatus.Invalid)
        {
            SetAndUpdateStatus(ToolStatus.Checking);
            FetchRemoteVersion();
        }
        else
        {
            RefreshAndUpdateStatus();
        }
    }

    private void OnPathChanged(string path)
    {
        if (Core.CurrentPage.Validator != this)
            return;

        if (!IsRootFolderValid)
        {
            Core.UIHandler.HideToolStatus();
        }
        else
        {
            RefreshAndUpdateStatus();
        }
    }

    private ToolStatus GetCurrentStatus()
    {
        // These temporary states need to be manually deactivated
        if (_currentStatus == ToolStatus.Checking || _currentStatus == ToolStatus.Downloading)
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
        if (Core.CurrentPage.Validator != this)
            return;

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
        await DownloadModdingTools();
        InvalidateAndUpdateStatus();
    }

    private async void FetchRemoteVersion()
    {
        using var client = new HttpClient();
        string version = await client.GetStringAsync(_remoteVersionPath);
        version = version.Trim();

        Logger.Debug($"Found remote version: {version}");
        _remoteVersion = version;
        InvalidateAndUpdateStatus();
    }

    private async Task DownloadModdingTools()
    {
        string toolsCache = Path.Combine(Core.CacheFolder, _cacheDir, _remoteVersion, "data.zip");
        Directory.CreateDirectory(Path.GetDirectoryName(toolsCache)!);

        // If tools dont already exist in cache, download from web
        if (!File.Exists(toolsCache))
        {
            Logger.Warn("Downloading modding tools from web");
            using var client = new HttpClient();
            await client.DownloadFileAsync(new Uri(_remoteDownloadPath), toolsCache);
        }

        // Extract data in cache to game folder
        using ZipFile zipFile = ZipFile.Read(toolsCache);
        foreach (ZipEntry file in zipFile)
            file.Extract(RootFolder, ExtractExistingFileAction.OverwriteSilently);
    }

    public void SetRootPath(string path)
    {
        RootFolder = path;
    }

    public bool IsRootFolderValid
    {
        get
        {
            string path = Path.Combine(RootFolder, _exeName);
            return File.Exists(path);
        }
    }

    private bool AreModdingToolsInstalled
    {
        get
        {
            string path = Path.Combine(RootFolder, _localVersionPath);
            return File.Exists(path);
        }
    }

    private bool AreModdingToolsUpdated
    {
        get
        {
            string path = Path.Combine(RootFolder, _localVersionPath);
            var localVersion = new Version(FileVersionInfo.GetVersionInfo(path).FileVersion!);
            var remoteVersion = new Version(_remoteVersion);

            return localVersion >= remoteVersion;
        }
    }

    public string ExeName => _exeName;
    public string DefaultPath => string.IsNullOrEmpty(RootFolder) ? _defaultPath : RootFolder;

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
