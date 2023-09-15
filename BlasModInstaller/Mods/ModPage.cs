using BlasModInstaller.Grouping;
using BlasModInstaller.UIHolding;
using BlasModInstaller.Validation;
using Ionic.Zip;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlasModInstaller.Mods
{
    internal class ModPage : BasePage
    {
        private readonly List<Mod> _mods = new List<Mod>();
        private readonly ModGrouper _grouper;
        private readonly GenericUIHolder<Mod> _uiHolder;

        private bool _loaded = false;

        public ModPage(string title, Bitmap image, Panel panel, string localDataPath, string globalDataPath, IValidator validator)
            : base(title, image, localDataPath, globalDataPath, validator)
        {
            _grouper = new ModGrouper(title, _mods);
            _uiHolder = new GenericUIHolder<Mod>(panel, _mods);
        }

        public override IGrouper Grouper => _grouper;
        public override IUIHolder UIHolder => _uiHolder;

        // Mod list

        public int InstalledModsThatRequireDll(string dllName)
        {
            int count = 0;
            foreach (Mod mod in _mods)
            {
                if (mod.RequiresDll(dllName) && mod.Installed)
                    count++;
            }
            return count;
        }

        private bool ModExists(string name, out Mod existingMod)
        {
            foreach (Mod mod in _mods)
            {
                if (mod.Name == name)
                {
                    existingMod = mod;
                    return true;
                }
            }
            existingMod = null;
            return false;
        }

        // Data

        public override void LoadData()
        {
            _uiHolder.AdjustPageWidth();
            if (_loaded)
                return;

            LoadLocalMods();
            LoadGlobalMods();
            _loaded = true;
        }

        private void LoadLocalMods()
        {
            if (File.Exists(_localDataPath))
            {
                string json = File.ReadAllText(_localDataPath);
                Mod[] localMods = JsonConvert.DeserializeObject<Mod[]>(json);
                _mods.AddRange(localMods);
            }

            for (int i = 0; i < _mods.Count; i++)
                _mods[i].CreateUI(_uiHolder.SectionPanel, i);

            Core.UIHandler.Log($"Loaded {_mods.Count} local mods");
            _uiHolder.SetBackgroundColor();
            Sort();
        }

        private async Task LoadGlobalMods()
        {
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(_globalDataPath);
                Mod[] globalMods = JsonConvert.DeserializeObject<Mod[]>(json);

                foreach (Mod globalMod in globalMods)
                {
                    Octokit.Release latestRelease = await Core.GithubHandler.GetLatestRelease(globalMod.GithubAuthor, globalMod.GithubRepo);
                    Version webVersion = GithubHandler.CleanSemanticVersion(latestRelease.TagName);
                    string downloadURL = latestRelease.Assets[0].BrowserDownloadUrl;
                    DateTimeOffset latestReleaseDate = latestRelease.CreatedAt;

                    if (ModExists(globalMod.Name, out Mod localMod))
                    {
                        localMod.LatestVersion = webVersion.ToString();
                        localMod.LatestDownloadURL = downloadURL;
                        localMod.LatestReleaseDate = latestReleaseDate;
                        localMod.UpdateLocalData(globalMod);
                        localMod.UpdateUI();
                    }
                    else
                    {
                        globalMod.LatestVersion = webVersion.ToString();
                        globalMod.LatestDownloadURL = downloadURL;
                        globalMod.LatestReleaseDate = latestReleaseDate;
                        _mods.Add(globalMod);
                        globalMod.CreateUI(_uiHolder.SectionPanel, _mods.Count - 1);
                    }
                }

                Core.UIHandler.Log($"Loaded {globalMods.Length} global mods");
            }

            SaveLocalData();
            _uiHolder.SetBackgroundColor();
            Sort();
        }

        private void SaveLocalData()
        {
            File.WriteAllText(_localDataPath, JsonConvert.SerializeObject(_mods));
        }

        public override async Task InstallTools()
        {
            using (WebClient client = new WebClient())
            {
                string downloadPath = $"{UIHandler.DownloadsPath}{"Blas1_Tools"}.zip";
                string installPath = Core.SettingsHandler.Config.Blas1RootFolder;

                // Get this from somewhere else later
                string temp = "https://github.com/BrandenEK/Blasphemous.ModdingTools/raw/main/modding-tools.zip";
                await client.DownloadFileTaskAsync(new Uri(temp), downloadPath);

                using (ZipFile zipFile = ZipFile.Read(downloadPath))
                {
                    foreach (ZipEntry file in zipFile)
                        file.Extract(installPath, ExtractExistingFileAction.OverwriteSilently);
                }

                File.Delete(downloadPath);
            }
        }

        // Sort

        public override void Sort()
        {
            _mods.Sort();

            // Move modding api to the top always
            for (int i = 0; i < _mods.Count; i++)
            {
                if (_mods[i].Name == "Modding API")
                {
                    Mod api = _mods[i];
                    _mods.RemoveAt(i);
                    _mods.Insert(0, api);
                    break;
                }
            }

            _uiHolder.SectionPanel.VerticalScroll.Value = 0;
            for (int i = 0; i < _mods.Count; i++)
                _mods[i].SetUIPosition(i);
        }

        public override SortType CurrentSortType
        {
            get => Core.SettingsHandler.Config.Blas1ModSort;
            set => Core.SettingsHandler.Config.Blas1ModSort = value;
        }
    }
}
