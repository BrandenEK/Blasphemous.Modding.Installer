using Ionic.Zip;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace BlasModInstaller.Validation
{
    internal class Blas1Validator : IValidator
    {
        private readonly string _exeName = "Blasphemous.exe";
        private readonly string _defaultPath = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Blasphemous";

        public async Task InstallModdingTools()
        {
            string toolsCache = Core.DataCache + "/tools/blas1.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(toolsCache));

            // If tools dont already exist in cache, download from web
            if (!File.Exists(toolsCache))
            {
                Logger.Warn("Downloading blas1 tools from web");
                using (WebClient client = new WebClient())
                {
                    string toolsPath = "https://github.com/BrandenEK/Blasphemous.ModdingTools/raw/main/modding-tools.zip";
                    await client.DownloadFileTaskAsync(new Uri(toolsPath), toolsCache);
                }
            }

            // Extract data in cache to game folder
            string installPath = Core.SettingsHandler.Config.Blas1RootFolder;
            using (ZipFile zipFile = ZipFile.Read(toolsCache))
            {
                foreach (ZipEntry file in zipFile)
                    file.Extract(installPath, ExtractExistingFileAction.OverwriteSilently);
            }
        }

        public void SetRootPath(string path)
        {
            Core.SettingsHandler.Config.Blas1RootFolder = path;
        }

        public bool IsRootFolderValid
        {
            get
            {
                string path = Core.SettingsHandler.Config.Blas1RootFolder;
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
                return Directory.Exists(Core.SettingsHandler.Config.Blas1RootFolder + "\\BepInEx");
            }
        }

        public bool AreModdingToolsUpdated => true;

        public string ExeName => _exeName;
        public string DefaultPath => _defaultPath;
    }
}
