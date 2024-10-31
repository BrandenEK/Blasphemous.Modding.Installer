using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.Extensions;
using Blasphemous.Modding.Installer.PageComponents.Validators.IconLoaders;
using Ionic.Zip;
using System.Diagnostics;

namespace Blasphemous.Modding.Installer.PageComponents.Validators;

internal class StandardValidator : IValidator
{
    private readonly string _defaultPath;
    private readonly string _exeName;
    private readonly string _localVersionPath;
    private readonly string _remoteDownloadPath;
    private readonly string _remoteVersionPath;

    private readonly IIconLoader _iconLoader;
    private readonly GameSettings _settings;

    private ToolStatus _currentStatus = ToolStatus.Invalid;
    private string _remoteVersion = string.Empty;

    public StandardValidator(string defaultPath, string exeName, string localVersionPath, string remoteDownloadPath, string remoteVersionPath, IIconLoader iconLoader, GameSettings settings)
    {
        _defaultPath = defaultPath;
        _exeName = exeName;
        _localVersionPath = localVersionPath;
        _remoteDownloadPath = remoteDownloadPath;
        _remoteVersionPath = remoteVersionPath;

        _iconLoader = iconLoader;
        _settings = settings;

        UIHandler.OnPageOpened += OnPageOpened;
        //UIHandler.OnPathChanged += OnPathChanged;
    }

    private void OnPageOpened(InstallerPage page)
    {
        if (page.Validator != this)
            return;

        bool isValid = IsRootFolderValid;
        Core.UIHandler.UpdateRootFolderText(isValid ? _settings.RootFolder : $"Click to locate {_exeName}");

        if (!isValid)
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

    //private void OnPathChanged(string path)
    //{
    //    if (Core.CurrentPage.Validator != this)
    //        return;

    //    bool isValid = IsRootFolderValid;
    //    Core.UIHandler.UpdateRootFolderText(isValid ? RootFolder : $"Click to locate {_exeName}");

    //    if (!isValid)
    //    {
    //        Core.UIHandler.HideToolStatus();
    //    }
    //    else
    //    {
    //        RefreshAndUpdateStatus();
    //    }
    //}

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
            ToolStatus.NotInstalled => "Click to download modding tools",
            ToolStatus.InstalledNotUpdated => "Click to update modding tools",
            ToolStatus.InstalledAndUpdated => "Modding tools are up to date",
            _ => throw new Exception($"Invalid tool status: {_currentStatus}")
        };

        Bitmap icon = _currentStatus switch
        {
            ToolStatus.Checking => _iconLoader.GetIcon("circles"),
            ToolStatus.Downloading => _iconLoader.GetIcon("dash"),
            ToolStatus.NotInstalled => _iconLoader.GetIcon("x"),
            ToolStatus.InstalledNotUpdated => _iconLoader.GetIcon("arrow"),
            ToolStatus.InstalledAndUpdated => _iconLoader.GetIcon("check"),
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
        string version;

        try
        {
            version = await client.GetStringAsync(_remoteVersionPath);
            version = version.Trim();
        }
        catch
        {
            Logger.Error("Failed to fetch tools remote version");
            return;
        }

        Logger.Debug($"Found remote version: {version}");
        _remoteVersion = version;
        InvalidateAndUpdateStatus();
    }

    private async Task DownloadModdingTools()
    {
        string toolsCache = Path.Combine(Core.CacheFolder, $"{_settings.Id}tools", _remoteVersion, "data.zip");
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
            file.Extract(_settings.RootFolder, ExtractExistingFileAction.OverwriteSilently);
    }

    public bool IsRootFolderValid
    {
        get
        {
            if (string.IsNullOrEmpty(_settings.RootFolder))
                return false;

            string path = Path.Combine(_settings.RootFolder, _exeName);
            return File.Exists(path);
        }
    }

    public bool AreModdingToolsInstalled
    {
        get
        {
            string path = Path.Combine(_settings.RootFolder, _localVersionPath);
            return File.Exists(path);
        }
    }

    public bool AreModdingToolsUpdated
    {
        get
        {
            string path = Path.Combine(_settings.RootFolder, _localVersionPath);
            var localVersion = new Version(FileVersionInfo.GetVersionInfo(path).FileVersion!);
            var remoteVersion = new Version(_remoteVersion);

            return localVersion >= remoteVersion;
        }
    }

    public string ExeName => _exeName;
    public string DefaultPath => string.IsNullOrEmpty(_settings.RootFolder) ? _defaultPath : _settings.RootFolder;

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
