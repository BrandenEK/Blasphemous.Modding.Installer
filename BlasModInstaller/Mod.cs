using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Ionic.Zip;
using Newtonsoft.Json;

namespace BlasModInstaller
{
    [Serializable]
    public class Mod
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public string Description { get; private set; }
        public string GithubAuthor { get; private set; }
        public string GithubRepo { get; private set; }
        public string PluginFile { get; private set; }
        public string[] RequiredDlls { get; private set; }

        public string Version { get; set; }

        [JsonIgnore]
        public bool Installed => File.Exists(PathToEnabledPlugin) || File.Exists(PathToDisabledPlugin);
        [JsonIgnore]
        public bool Enabled => File.Exists(PathToEnabledPlugin);

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

        public void InstallMod(string newVersion, string zipPath)
        {
            // Actually install
            string installPath = Name == "Modding API" ? MainForm.BlasExePath : MainForm.ModdingFolderPath;
            using (ZipFile zipFile = ZipFile.Read(zipPath))
            {
                foreach (ZipEntry file in zipFile)
                    file.Extract(installPath, ExtractExistingFileAction.OverwriteSilently);
            }
            Version = newVersion;
            MainForm.Instance.SaveMods();
            File.Delete(zipPath);
            UI.UpdateUI(false);
        }

        public void UninstallMod()
        {
            // Actually uninstall
            if (File.Exists(PathToEnabledPlugin))
                File.Delete(PathToEnabledPlugin);
            if (File.Exists(PathToDisabledPlugin))
                File.Delete(PathToDisabledPlugin);
            if (File.Exists(PathToConfigFile))
                File.Delete(PathToConfigFile);
            if (File.Exists(PathToLocalizationFile))
                File.Delete(PathToLocalizationFile);
            if (File.Exists(PathToLogFile))
                File.Delete(PathToLogFile);
            if (Directory.Exists(PathToDataFolder))
                Directory.Delete(PathToDataFolder, true);
            if (Directory.Exists(PathToLevelsFolder))
                Directory.Delete(PathToLevelsFolder, true);

            //string[] dlls = mods[modIdx].RequiredDlls;
            //if (dlls != null && dlls.Length > 0)
            //{
            //    foreach (string dll in dlls)
            //    {
            //        blasLocation.Text += dll + " ";
            //    }
            //}

            // Update UI
            UI.UpdateUI(false);
        }

        public void EnableMod()
        {
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
                Process.Start($"https://github.com/{GithubAuthor}/{GithubRepo}");
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

        // Install paths
        [JsonIgnore]
        public string PathToEnabledPlugin => $"{MainForm.BlasExePath}\\Modding\\plugins\\{PluginFile}";
        [JsonIgnore]
        public string PathToDisabledPlugin => $"{MainForm.BlasExePath}\\Modding\\disabled\\{PluginFile}";
        [JsonIgnore]
        public string PathToConfigFile => $"{MainForm.BlasExePath}\\Modding\\config\\{Name}.cfg";
        [JsonIgnore]
        public string PathToLocalizationFile => $"{MainForm.BlasExePath}\\Modding\\localization\\{Name}.txt";
        [JsonIgnore]
        public string PathToLogFile => $"{MainForm.BlasExePath}\\Modding\\logs\\{Name}.log";
        [JsonIgnore]
        public string PathToDataFolder => $"{MainForm.BlasExePath}\\Modding\\data\\{Name}";
        [JsonIgnore]
        public string PathToLevelsFolder => $"{MainForm.BlasExePath}\\Modding\\levels\\{Name}";
    }
}
