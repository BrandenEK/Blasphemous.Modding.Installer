using BlasModInstaller.Skins;
using BlasModInstaller.Sorting;
using BlasModInstaller.UIHolding;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private readonly SectionType _skinType;

        private bool _loadedData;

        public SkinLoader(string localDataPath, string remoteDataPath, IUIHolder uiHolder, ISorter sorter, List<Skin> skins, SectionType skinType)
        {
            _localDataPath = localDataPath;
            _remoteDataPath = remoteDataPath;
            _uiHolder = uiHolder;
            _sorter = sorter;
            _skins = skins;
            _skinType = skinType;
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
                SkinData[] localData = JsonConvert.DeserializeObject<SkinData[]>(json);

                for (int i = 0; i < localData.Length; i++)
                {
                    _skins.Add(new Skin(localData[i], _uiHolder.SectionPanel, i, _skinType));
                }
            }

            Core.UIHandler.Log($"Loaded {_skins.Count} local skins");
            _uiHolder.SetBackgroundColor();
            _sorter.Sort();
        }

        private async Task LoadRemoteSkins()
        {
            using (HttpClient client = new HttpClient())
            {
                IReadOnlyList<Octokit.RepositoryContent> contents = 
                    await Core.GithubHandler.GetRepositoryDirectory("BrandenEK", "Blasphemous-Custom-Skins", _remoteDataPath);
                
                foreach (var item in contents)
                {
                    string json = await client.GetStringAsync($"https://raw.githubusercontent.com/BrandenEK/Blasphemous-Custom-Skins/main/{_remoteDataPath}/{item.Name}/info.txt");
                    SkinData data = JsonConvert.DeserializeObject<SkinData>(json);

                    Skin localSkin = FindSkin(data.id);
                    if (localSkin != null)
                    {
                        localSkin.Data = data;
                        localSkin.UpdateUI();
                    }
                    else
                    {
                        _skins.Add(new Skin(data, _uiHolder.SectionPanel, _skins.Count, _skinType));
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
            File.WriteAllText(_localDataPath, JsonConvert.SerializeObject(_skins.Select(x => x.Data)));
        }

        private Skin FindSkin(string id)
        {
            return _skins.Find(x => x.Data.id == id);
        }
    }
}
