using BlasModInstaller.Skins;
using BlasModInstaller.Sorting;
using BlasModInstaller.UIHolding;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlasModInstaller.Loading
{
    internal class SkinLoader : ILoader
    {
        private readonly string _localDataPath;
        private readonly string _remoteDataPath;
        private readonly IUIHolder _uiHolder;
        private readonly ISorter _sorter;
        private readonly List<Skin> _skins;

        private bool _loadedData;

        public SkinLoader(string localDataPath, string remoteDataPath, IUIHolder uiHolder, ISorter sorter, List<Skin> skins)
        {
            _localDataPath = localDataPath;
            _remoteDataPath = remoteDataPath;
            _uiHolder = uiHolder;
            _sorter = sorter;
            _skins = skins;
        }

        public void LoadAllData()
        {
            _uiHolder.AdjustPageWidth();
            if (_loadedData)
                return;

            LoadLocalSkins();
            LoadRemoteSkins();
            _loadedData = true;
        }

        private void LoadLocalSkins()
        {
            if (File.Exists(_localDataPath))
            {
                string json = File.ReadAllText(_localDataPath);
                Skin[] localSkins = JsonConvert.DeserializeObject<Skin[]>(json);
                _skins.AddRange(localSkins);
            }

            for (int i = 0; i < _skins.Count; i++)
                _skins[i].CreateUI(_uiHolder.SectionPanel, i);

            Core.UIHandler.Log($"Loaded {_skins.Count} local skins");
            _uiHolder.SetBackgroundColor();
            _sorter.Sort();
        }

        private async Task LoadRemoteSkins()
        {
            using (HttpClient client = new HttpClient())
            {
                IReadOnlyList<Octokit.RepositoryContent> contents = await Core.GithubHandler.GetRepositoryContents("BrandenEK", "Blasphemous-Custom-Skins");
                foreach (var item in contents)
                {
                    string json = await client.GetStringAsync($"https://raw.githubusercontent.com/BrandenEK/Blasphemous-Custom-Skins/main/{item.Name}/info.txt");
                    Skin globalSkin = JsonConvert.DeserializeObject<Skin>(json);

                    Skin localSkin = FindSkin(globalSkin.id);
                    if (localSkin != null)
                    {
                        localSkin.UpdateLocalData(globalSkin);
                        localSkin.UpdateUI();
                    }
                    else
                    {
                        _skins.Add(globalSkin);
                        globalSkin.CreateUI(_uiHolder.SectionPanel, _skins.Count - 1);
                    }
                }

                Core.UIHandler.Log($"Loaded {contents.Count} global skins");
            }

            SaveLocalData();
            _uiHolder.SetBackgroundColor();
            _sorter.Sort();
        }

        private void SaveLocalData()
        {
            File.WriteAllText(_localDataPath, JsonConvert.SerializeObject(_skins));
        }

        private Skin FindSkin(string id)
        {
            return _skins.Find(x => x.id == id);
        }
    }
}
