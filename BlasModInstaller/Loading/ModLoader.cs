using BlasModInstaller.Mods;
using BlasModInstaller.Sorting;
using BlasModInstaller.UIHolding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlasModInstaller.Loading
{
    internal class ModLoader : ILoader
    {
        private readonly string _localDataPath;
        private readonly string _globalDataPath;
        private readonly IUIHolder _uiHolder;
        private readonly ISorter _sorter;
        private readonly List<Mod> _mods;

        private bool _loadedData;

        public ModLoader(string localDataPath, string globalDataPath, IUIHolder uiHolder, ISorter sorter, List<Mod> mods)
        {
            _localDataPath = localDataPath;
            _globalDataPath = globalDataPath;
            _uiHolder = uiHolder;
            _sorter = sorter;
            _mods = mods;
        }

        public void LoadAllData()
        {
            _uiHolder.AdjustPageWidth();
            if (_loadedData)
                return;

            LoadLocalMods();
            LoadRemoteMods();
            _loadedData = true;
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
            _sorter.Sort();
        }

        private async Task LoadRemoteMods()
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

                    Mod localMod = FindMod(globalMod.Name);
                    if (localMod != null)
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
            _sorter.Sort();
        }

        private void SaveLocalData()
        {
            File.WriteAllText(_localDataPath, JsonConvert.SerializeObject(_mods));
        }

        private Mod FindMod(string name)
        {
            return _mods.Find(x => x.Name == name);
        }

        public int InstalledModsThatRequireDll(string dllName)
        {
            return _mods.Where(x => x.RequiresDll(dllName) && x.Installed).Count();
        }
    }
}
