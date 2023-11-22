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
            using (WebClient client = new WebClient())
            {
                string toolsPath = "https://github.com/BrandenEK/Blasphemous.ModdingTools/raw/main/modding-tools.zip";
                string downloadPath = Core.DataCache + "/Blas1tools.zip";
                string installPath = Core.SettingsHandler.Config.Blas1RootFolder;

                await client.DownloadFileTaskAsync(new Uri(toolsPath), downloadPath);

                using (ZipFile zipFile = ZipFile.Read(downloadPath))
                {
                    foreach (ZipEntry file in zipFile)
                        file.Extract(installPath, ExtractExistingFileAction.OverwriteSilently);
                }

                File.Delete(downloadPath);
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
