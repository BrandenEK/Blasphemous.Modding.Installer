using BlasModInstaller.Loading;
using Ionic.Zip;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace BlasModInstaller.Mods
{
    internal class Mod : IComparable
    {
        private readonly ModUI _ui;
        private readonly SectionType _modType;

        private bool _downloading = false;

        public Mod(ModData data, Panel panel, SectionType modType)
        {
            Data = data;
            _modType = modType;
            _ui = new ModUI(this, panel);
            SetUIPosition(-1);
            UpdateUI();
            ModPage.UIHolder.AdjustPageWidth();
        }

        public ModData Data { get; set; }

        private InstallerPage ModPage => _modType == SectionType.Blas1Mods ? Core.Blas1ModPage : Core.Blas2ModPage;
        private SortType ModSort => _modType == SectionType.Blas1Mods ? Core.SettingsHandler.Config.Blas1ModSort : Core.SettingsHandler.Config.Blas2ModSort;

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

        private string RootFolder => Core.SettingsHandler.GetRootPathBySection(_modType);
        public string GithubLink => $"https://github.com/{Data.githubAuthor}/{Data.githubRepo}";

        public string PathToEnabledPlugin => $"{RootFolder}/Modding/plugins/{Data.pluginFile}";
        public string PathToDisabledPlugin => $"{RootFolder}/Modding/disabled/{Data.pluginFile}";
        public string PathToConfigFile => $"{RootFolder}/Modding/config/{Data.name}.cfg";
        public string PathToDataFolder => $"{RootFolder}/Modding/data/{Data.name}";
        public string PathToKeybindingsFile => $"{RootFolder}/Modding/keybindings/{Data.name}.txt";
        public string PathToLevelsFolder => $"{RootFolder}/Modding/levels/{Data.name}";
        public string PathToLocalizationFile => $"{RootFolder}/Modding/localization/{Data.name}.txt";
        public string PathToLogFile => $"{RootFolder}/Modding/logs/{Data.name}.log";

        public bool ExistsInCache(string fileName, out string cachePath)
        {
            cachePath = $"{Core.DataCache}/blas{(_modType == SectionType.Blas1Mods ? "1" : "2")}mods/{Data.name}/{Data.latestVersion}/{fileName}";
            Directory.CreateDirectory(Path.GetDirectoryName(cachePath));

            return File.Exists(cachePath) && new FileInfo(cachePath).Length > 0;
        }

        // Main methods

        public async void Install()
        {
            string installPath = RootFolder + "/Modding";
            Directory.CreateDirectory(installPath);

            // Check for data in the cache
            bool zipExists = ExistsInCache("data.zip", out string zipCache);

            // If it was missing, download it from web to cache
            if (!zipExists)
            {
                Core.UIHandler.Log("Downloading mod data from web");
                using (WebClient client = new WebClient())
                {
                    _downloading = true;
                    _ui.ShowDownloadingStatus();

                    await client.DownloadFileTaskAsync(new Uri(Data.latestDownloadURL), zipCache);
                    
                    _downloading = false;
                }
            }

            // Extract data in cache to game folder
            using (ZipFile zipFile = ZipFile.Read(zipCache))
            {
                foreach (ZipEntry file in zipFile)
                    file.Extract(installPath, ExtractExistingFileAction.OverwriteSilently);
            }

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
                ModLoader modLoader = ModPage.Loader as ModLoader;
                foreach (string dll in Data.requiredDlls)
                {
                    if (modLoader.InstalledModsThatRequireDll(dll) == 0)
                    {
                        string dllPath = RootFolder + "/Modding/data/" + dll;
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

        public int CompareTo(object obj) => SortBy(obj as Mod, ModSort);

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

        public void MouseEnter(object sender, EventArgs e) => ModPage.Previewer.PreviewMod(this);

        public void MouseLeave(object sender, EventArgs e) => ModPage.Previewer.Clear();
    }
}
