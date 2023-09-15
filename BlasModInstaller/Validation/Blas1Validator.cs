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

        public async Task InstallModdingTools()
        {
            using (WebClient client = new WebClient())
            {
                string toolsPath = "https://github.com/BrandenEK/Blasphemous.ModdingTools/raw/main/modding-tools.zip";
                string downloadPath = UIHandler.DownloadsPath + "Blas1_Tools.zip";
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

        public string ExeName => _exeName;
    }
}
