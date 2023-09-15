using BlasModInstaller.Loading;
using Ionic.Zip;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlasModInstaller.Mods
{
    [Serializable]
    public class Mod : IComparable
    {
        // Data

        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTimeOffset InitialReleaseDate { get; set; }
        public string GithubAuthor { get; set; }
        public string GithubRepo { get; set; }
        public string PluginFile { get; set; }
        public string[] RequiredDlls { get; set; }

        public string LatestVersion { get; set; }
        public string LatestDownloadURL { get; set; }
        public DateTimeOffset LatestReleaseDate { get; set; }

        [JsonIgnore] private bool _downloading;
        [JsonIgnore] private ModUI _ui;

        public void UpdateLocalData(Mod globalMod)
        {
            // Name is already going to be the same
            Author = globalMod.Author;
            Description = globalMod.Description;
            InitialReleaseDate = globalMod.InitialReleaseDate;
            GithubAuthor = globalMod.GithubAuthor;
            GithubRepo = globalMod.GithubRepo;
            PluginFile = globalMod.PluginFile;
            RequiredDlls = globalMod.RequiredDlls;
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

        [JsonIgnore] public bool Installed => File.Exists(PathToEnabledPlugin) || File.Exists(PathToDisabledPlugin);
        [JsonIgnore] public bool Enabled => File.Exists(PathToEnabledPlugin);

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

        [JsonIgnore]
        public bool UpdateAvailable
        {
            get
            {
                if (!Installed)
                    return false;

                return new Version(LatestVersion).CompareTo(LocalVersion) > 0;
            }
        }

        // Paths

        [JsonIgnore]
        public string PathToEnabledPlugin => $"{Core.SettingsHandler.Config.Blas1RootFolder}\\Modding\\plugins\\{PluginFile}";
        [JsonIgnore]
        public string PathToDisabledPlugin => $"{Core.SettingsHandler.Config.Blas1RootFolder}\\Modding\\disabled\\{PluginFile}";
        [JsonIgnore]
        public string PathToConfigFile => $"{Core.SettingsHandler.Config.Blas1RootFolder}\\Modding\\config\\{Name}.cfg";
        [JsonIgnore]
        public string PathToDataFolder => $"{Core.SettingsHandler.Config.Blas1RootFolder}\\Modding\\data\\{Name}";
        [JsonIgnore]
        public string PathToKeybindingsFile => $"{Core.SettingsHandler.Config.Blas1RootFolder}\\Modding\\keybindings\\{Name}.txt";
        [JsonIgnore]
        public string PathToLevelsFolder => $"{Core.SettingsHandler.Config.Blas1RootFolder}\\Modding\\levels\\{Name}";
        [JsonIgnore]
        public string PathToLocalizationFile => $"{Core.SettingsHandler.Config.Blas1RootFolder}\\Modding\\localization\\{Name}.txt";
        [JsonIgnore]
        public string PathToLogFile => $"{Core.SettingsHandler.Config.Blas1RootFolder}\\Modding\\logs\\{Name}.log";
        [JsonIgnore]
        public string GithubLink => $"https://github.com/{GithubAuthor}/{GithubRepo}";

        // Main methods

        public async Task Install()
        {
            _downloading = true;
            using (WebClient client = new WebClient())
            {
                _ui.ShowDownloadingStatus();

                string downloadPath = $"{UIHandler.DownloadsPath}{Name.Replace(' ', '_')}.zip";

                await client.DownloadFileTaskAsync(new Uri(LatestDownloadURL), downloadPath);

                string installPath = Core.SettingsHandler.Config.Blas1RootFolder;
                if (Name != "Modding API") installPath += "\\Modding";

                using (ZipFile zipFile = ZipFile.Read(downloadPath))
                {
                    foreach (ZipEntry file in zipFile)
                        file.Extract(installPath, ExtractExistingFileAction.OverwriteSilently);
                }

                File.Delete(downloadPath);
            }
            _downloading = false;

            UpdateUI();
        }

        public void Uninstall()
        {
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
                ModLoader modLoader = Core.Blas1ModPage.Loader as ModLoader;
                foreach (string dll in RequiredDlls)
                {
                    if (modLoader.InstalledModsThatRequireDll(dll) == 0)
                    {
                        string dllPath = Core.SettingsHandler.Config.Blas1RootFolder + "\\Modding\\data\\" + dll;
                        if (File.Exists(dllPath))
                            File.Delete(dllPath);
                    }
                }
            }

            UpdateUI();
        }

        public void Enable()
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

            UpdateUI();
        }

        public void Disable()
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

            UpdateUI();
        }

        // Click methods

        public void ClickedInstall(object sender, EventArgs e)
        {
            if (_downloading) return;

            if (Installed)
            {
                if (MessageBox.Show("Are you sure you want to uninstall this mod?", Name, MessageBoxButtons.OKCancel) == DialogResult.OK)
                    Uninstall();
            }
            else
            {
                Install();
            }
        }

        public void ClickedEnable(object sender, EventArgs e)
        {
            if (Enabled)
                Disable();
            else
                Enable();
        }

        public void ClickedUpdate(object sender, EventArgs e)
        {
            Uninstall();
            Install();
        }

        public void ClickedReadme(object sender, EventArgs e)
        {
            try { Process.Start(GithubLink); }
            catch (Exception) { MessageBox.Show("Link does not exist!", "Invalid Link"); }
        }

        // Sort methods

        public int CompareTo(object obj) => SortBy(obj as Mod, Core.SettingsHandler.Config.Blas1ModSort);

        public int SortBy(Mod mod, SortType sort)
        {
            if (sort == SortType.Name)
            {
                return Name.CompareTo(mod.Name);
            }
            else if (sort == SortType.Author)
            {
                int difference = Author.CompareTo(mod.Author);
                return difference == 0 ? SortBy(mod, SortType.Name) : difference;
            }
            else if (sort == SortType.InitialRelease)
            {
                int difference = InitialReleaseDate.CompareTo(mod.InitialReleaseDate);
                return difference == 0 ? SortBy(mod, SortType.Name) : difference;
            }
            else if (sort == SortType.LatestRelease)
            {
                int difference = LatestReleaseDate.CompareTo(mod.LatestReleaseDate) * -1;
                return difference == 0 ? SortBy(mod, SortType.Name) : difference;
            }
            return 0;
        }

        // UI methods

        public void CreateUI(Panel parentPanel, int modIdx)
        {
            _ui = new ModUI(this, parentPanel);
            SetUIPosition(modIdx);
            UpdateUI();
            Core.Blas1ModPage.UIHolder.AdjustPageWidth();
        }

        public void UpdateUI()
        {
            _ui.UpdateUI(Name, (Installed ? LocalVersion.ToString(3) : LatestVersion), Author, Installed, Enabled, UpdateAvailable);
        }

        public void SetUIPosition(int modIdx)
        {
            _ui.SetPosition(modIdx);
        }
    }
}
