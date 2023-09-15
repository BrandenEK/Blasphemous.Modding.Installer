using BlasModInstaller.Loading;
using Ionic.Zip;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlasModInstaller.Mods
{
    internal class Mod : IComparable
    {
        private readonly ModUI _ui;

        private bool _downloading = false;

        public Mod(ModData data, Panel panel, int initialIndex)
        {
            Data = data;
            _ui = new ModUI(this, panel);
            SetUIPosition(initialIndex);
            UpdateUI();
            Core.Blas1ModPage.UIHolder.AdjustPageWidth();
        }

        public ModData Data { get; set; }

        public bool RequiresDll(string dllName)
        {
            if (Data.requiredDlls == null) return false;

            foreach (string dll in Data.requiredDlls)
            {
                if (dll == dllName)
                    return true;
            }
            return false;
        }

        public bool Installed => File.Exists(PathToEnabledPlugin) || File.Exists(PathToDisabledPlugin);
        public bool Enabled => File.Exists(PathToEnabledPlugin);

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

        public bool UpdateAvailable
        {
            get
            {
                if (!Installed)
                    return false;

                return new Version(Data.latestVersion).CompareTo(LocalVersion) > 0;
            }
        }

        // Paths

        public string PathToEnabledPlugin => $"{Core.SettingsHandler.Config.Blas1RootFolder}\\Modding\\plugins\\{Data.pluginFile}";
        public string PathToDisabledPlugin => $"{Core.SettingsHandler.Config.Blas1RootFolder}\\Modding\\disabled\\{Data.pluginFile}";
        public string PathToConfigFile => $"{Core.SettingsHandler.Config.Blas1RootFolder}\\Modding\\config\\{Data.name}.cfg";
        public string PathToDataFolder => $"{Core.SettingsHandler.Config.Blas1RootFolder}\\Modding\\data\\{Data.name}";
        public string PathToKeybindingsFile => $"{Core.SettingsHandler.Config.Blas1RootFolder}\\Modding\\keybindings\\{Data.name}.txt";
        public string PathToLevelsFolder => $"{Core.SettingsHandler.Config.Blas1RootFolder}\\Modding\\levels\\{Data.name}";
        public string PathToLocalizationFile => $"{Core.SettingsHandler.Config.Blas1RootFolder}\\Modding\\localization\\{Data.name}.txt";
        public string PathToLogFile => $"{Core.SettingsHandler.Config.Blas1RootFolder}\\Modding\\logs\\{Data.name}.log";
        public string GithubLink => $"https://github.com/{Data.githubAuthor}/{Data.githubRepo}";

        // Main methods

        public async Task Install()
        {
            _downloading = true;
            using (WebClient client = new WebClient())
            {
                _ui.ShowDownloadingStatus();

                string downloadPath = $"{UIHandler.DownloadsPath}{Data.name.Replace(' ', '_')}.zip";
                string installPath = Core.SettingsHandler.Config.Blas1RootFolder;
                
                // Change this !!!!!!
                if (Data.name != "Modding API") installPath += "\\Modding";

                await client.DownloadFileTaskAsync(new Uri(Data.latestDownloadURL), downloadPath);

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

            if (Data.requiredDlls != null && Data.requiredDlls.Length > 0)
            {
                ModLoader modLoader = Core.Blas1ModPage.Loader as ModLoader;
                foreach (string dll in Data.requiredDlls)
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
                if (MessageBox.Show("Are you sure you want to uninstall this mod?", Data.name, MessageBoxButtons.OKCancel) == DialogResult.OK)
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
                return Data.name.CompareTo(mod.Data.name);
            }
            else if (sort == SortType.Author)
            {
                int difference = Data.author.CompareTo(mod.Data.author);
                return difference == 0 ? SortBy(mod, SortType.Name) : difference;
            }
            else if (sort == SortType.InitialRelease)
            {
                int difference = Data.initialReleaseDate.CompareTo(mod.Data.initialReleaseDate);
                return difference == 0 ? SortBy(mod, SortType.Name) : difference;
            }
            else if (sort == SortType.LatestRelease)
            {
                int difference = Data.latestReleaseDate.CompareTo(mod.Data.latestReleaseDate) * -1;
                return difference == 0 ? SortBy(mod, SortType.Name) : difference;
            }
            return 0;
        }

        // UI methods

        public void UpdateUI()
        {
            _ui.UpdateUI(Data.name, (Installed ? LocalVersion.ToString(3) : Data.latestVersion), Data.author, Installed, Enabled, UpdateAvailable);
        }

        public void SetUIPosition(int modIdx)
        {
            _ui.SetPosition(modIdx);
        }
    }
}
