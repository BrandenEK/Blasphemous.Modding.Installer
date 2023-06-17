using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Ionic.Zip;
using Newtonsoft.Json;

namespace BlasModInstaller
{
    [Serializable]
    public class Mod
    {
        // This data will generally always stay the same
        public string Name { get; private set; }
        public string Author { get; private set; }
        public string Description { get; private set; }
        public string GithubAuthor { get; private set; }
        public string GithubRepo { get; private set; }
        public string PluginFile { get; private set; }
        public string[] RequiredDlls { get; private set; }
        // This data is set whenever loading mods from web
        public string LatestVersion { get; set; }
        public string LatestDownloadURL { get; set; }

        [JsonIgnore]
        public bool Installed => File.Exists(PathToEnabledPlugin) || File.Exists(PathToDisabledPlugin);
        [JsonIgnore]
        public bool Enabled => File.Exists(PathToEnabledPlugin);

        [JsonIgnore]
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

        public Mod(string name, string author, string description, string githubAuthor, string githubRepo, string pluginFile, string[] requiredDlls)
        {
            Name = name;
            Author = author;
            Description = description;
            GithubAuthor = githubAuthor;
            GithubRepo = githubRepo;
            PluginFile = pluginFile;
            RequiredDlls = requiredDlls;
        }

        public void InstallMod(string zipPath)
        {
            if (MainForm.BlasRootFolder == null) return;

            // Actually install
            string installPath = MainForm.BlasRootFolder;
            if (Name != "Modding API")
                installPath += "\\Modding";

            using (ZipFile zipFile = ZipFile.Read(zipPath))
            {
                foreach (ZipEntry file in zipFile)
                    file.Extract(installPath, ExtractExistingFileAction.OverwriteSilently);
            }
            UpdateAvailable = false;
            MainForm.Instance.BlasModPage.SaveMods();
            File.Delete(zipPath);
            UI.UpdateUI();
        }

        public void UninstallMod()
        {
            if (MainForm.BlasRootFolder == null) return;

            // Actually uninstall
            if (File.Exists(PathToEnabledPlugin))
                File.Delete(PathToEnabledPlugin);
            if (File.Exists(PathToDisabledPlugin))
                File.Delete(PathToDisabledPlugin);
            if (File.Exists(PathToConfigFile))
                File.Delete(PathToConfigFile);
            if (File.Exists(PathToKeybindingsFile))
                File.Delete(PathToKeybindingsFile);
            if (File.Exists(PathToLocalizationFile))
                File.Delete(PathToLocalizationFile);
            if (File.Exists(PathToLogFile))
                File.Delete(PathToLogFile);
            if (Directory.Exists(PathToDataFolder))
                Directory.Delete(PathToDataFolder, true);
            if (Directory.Exists(PathToLevelsFolder))
                Directory.Delete(PathToLevelsFolder, true);

            if (RequiredDlls != null && RequiredDlls.Length > 0)
            {
                foreach (string dll in RequiredDlls)
                {
                    if (MainForm.Instance.BlasModPage.InstalledModsThatRequireDll(dll) == 0)
                    {
                        string dllPath = MainForm.BlasRootFolder + "\\Modding\\data\\" + dll;
                        if (File.Exists(dllPath))
                            File.Delete(dllPath);
                    }
                }
            }

            // Update UI
            UpdateAvailable = false;
            UI.UpdateUI();
        }

        public void EnableMod()
        {
            if (MainForm.BlasRootFolder == null) return;

            string enabled = PathToEnabledPlugin;
            string disabled = PathToDisabledPlugin;
            if (File.Exists(disabled))
            {
                if (!File.Exists(enabled))
                    File.Move(disabled, enabled);
                else
                    File.Delete(disabled);
            }
        }

        public void DisableMod()
        {
            if (MainForm.BlasRootFolder == null) return;

            string enabled = PathToEnabledPlugin;
            string disabled = PathToDisabledPlugin;
            if (File.Exists(enabled))
            {
                if (!File.Exists(disabled))
                    File.Move(enabled, disabled);
                else
                    File.Delete(enabled);
            }
        }

        public void OpenGithubLink()
        {
            try
            {
                Process.Start(GithubLink);
            }
            catch (Exception)
            {
                MessageBox.Show("Link does not exist!", "Invalid Link");
            }
        }

        public void CopyData(Mod other)
        {
            // Name is already going to be the same
            Author = other.Author;
            Description = other.Description;
            GithubAuthor = other.GithubAuthor;
            GithubRepo = other.GithubRepo;
            PluginFile = other.PluginFile;
            RequiredDlls = other.RequiredDlls;
        }

        public bool RequiresDll(string dllName)
        {
            if (RequiredDlls == null) return false;

            foreach (string dll in RequiredDlls)
            {
                if (dll == dllName)
                    return true;
            }
            return false;
        }

        private ModHolder m_UI;
        [JsonIgnore]
        public ModHolder UI
        {
            get
            {
                if (m_UI == null)
                    m_UI = new ModHolder(this);
                return m_UI;
            }
        }

        // Download stuff

        [JsonIgnore]
        public bool Downloading { get; private set; }
        [JsonIgnore]
        public bool UpdateAvailable { get; set; }

        private WebClient client;

        public void StartDownload()
        {
            client = new WebClient();
            Downloading = true;
            UI.DisplayDownloadBar();
            MainForm.Instance.DownloadMod(this, client);
        }

        public void FinishDownload()
        {
            Downloading = false;
            client.Dispose();
            client = null;
        }

        public void CancelDownload()
        {
            if (client != null)
            {
                client.CancelAsync();
                FinishDownload();
            }
            UI.UpdateUI();
        }

        // Install paths
        [JsonIgnore]
        public string PathToEnabledPlugin => $"{MainForm.BlasRootFolder}\\Modding\\plugins\\{PluginFile}";
        [JsonIgnore]
        public string PathToDisabledPlugin => $"{MainForm.BlasRootFolder}\\Modding\\disabled\\{PluginFile}";
        [JsonIgnore]
        public string PathToConfigFile => $"{MainForm.BlasRootFolder}\\Modding\\config\\{Name}.cfg";
        [JsonIgnore]
        public string PathToDataFolder => $"{MainForm.BlasRootFolder}\\Modding\\data\\{Name}";
        [JsonIgnore]
        public string PathToKeybindingsFile => $"{MainForm.BlasRootFolder}\\Modding\\keybindings\\{Name}.txt";
        [JsonIgnore]
        public string PathToLevelsFolder => $"{MainForm.BlasRootFolder}\\Modding\\levels\\{Name}";
        [JsonIgnore]
        public string PathToLocalizationFile => $"{MainForm.BlasRootFolder}\\Modding\\localization\\{Name}.txt";
        [JsonIgnore]
        public string PathToLogFile => $"{MainForm.BlasRootFolder}\\Modding\\logs\\{Name}.log";
        [JsonIgnore]
        public string GithubLink => $"https://github.com/{GithubAuthor}/{GithubRepo}";

        public static string CleanSemanticVersion(string version)
        {
            return version.ToLower().Replace("v", "");
        }
    }
}
