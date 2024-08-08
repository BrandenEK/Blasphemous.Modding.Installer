using Basalt.Framework.Logging;
using Ionic.Zip;
using System.Diagnostics;
using System.Net;

namespace Blasphemous.Modding.Installer.PageComponents.Validators;

internal class Blas2Validator : IValidator
{
    private readonly string _exeName = "Blasphemous 2.exe";
    private readonly string _defaultPath = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Blasphemous 2";

    public async Task InstallModdingTools()
    {
        string toolsCache = Path.Combine(Core.CacheFolder, "tools", "blas2.zip");
        Directory.CreateDirectory(Path.GetDirectoryName(toolsCache));

        // If tools dont already exist in cache, download from web
        if (!File.Exists(toolsCache))
        {
            Logger.Warn("Downloading blas2 tools from web");
            using (WebClient client = new WebClient())
            {
                string toolsPath = "https://github.com/BrandenEK/BlasII.ModdingTools/raw/main/modding-tools-windows.zip";
                await client.DownloadFileTaskAsync(new Uri(toolsPath), toolsCache);
            }
        }

        // Extract data in cache to game folder
        string installPath = Core.SettingsHandler.Properties.Blas2RootFolder;
        using (ZipFile zipFile = ZipFile.Read(toolsCache))
        {
            foreach (ZipEntry file in zipFile)
                file.Extract(installPath, ExtractExistingFileAction.OverwriteSilently);
        }
    }

    public void SetRootPath(string path)
    {
        Core.SettingsHandler.Properties.Blas2RootFolder = path;
    }

    public bool IsRootFolderValid
    {
        get
        {
            string path = Core.SettingsHandler.Properties.Blas2RootFolder;
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
            return Directory.Exists(Core.SettingsHandler.Properties.Blas2RootFolder + "\\MelonLoader");
        }
    }

    public bool AreModdingToolsUpdated
    {
        get
        {
            string filePath = Core.SettingsHandler.Properties.Blas2RootFolder + "\\MelonLoader\\net6\\MelonLoader.dll";
            return File.Exists(filePath) && FileVersionInfo.GetVersionInfo(filePath).FileMajorPart == 2;
        }
    }

    public string ExeName => _exeName;
    public string DefaultPath => string.IsNullOrEmpty(Core.SettingsHandler.Properties.Blas2RootFolder)
        ? _defaultPath
        : Core.SettingsHandler.Properties.Blas2RootFolder;
}
