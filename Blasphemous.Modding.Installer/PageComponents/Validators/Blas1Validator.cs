using Basalt.Framework.Logging;
using Ionic.Zip;
using System.Net;

namespace Blasphemous.Modding.Installer.PageComponents.Validators;

internal class Blas1Validator : IValidator
{
    private readonly string _exeName = "Blasphemous.exe";
    private readonly string _defaultPath = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Blasphemous";

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
}
