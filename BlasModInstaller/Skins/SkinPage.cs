using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlasModInstaller.Skins
{
    internal class SkinPage : BasePage
    {
        private readonly List<Skin> _skins = new List<Skin>();

        private bool _loaded = false;

        public SkinPage(string title, Bitmap image, Panel uiElement, string localDataPath, string globalDataPath)
            : base(title, image, uiElement, localDataPath, globalDataPath) { }

        // Skin list

        private bool SkinExists(string id, out Skin existingSkin)
        {
            foreach (Skin skin in _skins)
            {
                if (skin.id == id)
                {
                    existingSkin = skin;
                    return true;
                }
            }
            existingSkin = null;
            return false;
        }

        // Data

        public override bool ValidateDirectory()
        {
            throw new NotImplementedException();
        }

        public override void LoadData()
        {
            AdjustPageWidth();
            if (_loaded)
                return;

            LoadLocalSkins();
            LoadGlobalSkins();
            _loaded = true;
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
                _skins[i].CreateUI(_uiElement, i);

            Core.UIHandler.Log($"Loaded {_skins.Count} local skins");
            SetBackgroundColor();
            Sort();
        }

        private async Task LoadGlobalSkins()
        {
            using (HttpClient client = new HttpClient())
            {
                IReadOnlyList<Octokit.RepositoryContent> contents = await Core.GithubHandler.GetRepositoryContents("BrandenEK", "Blasphemous-Custom-Skins");
                foreach (var item in contents)
                {
                    string json = await client.GetStringAsync($"https://raw.githubusercontent.com/BrandenEK/Blasphemous-Custom-Skins/main/{item.Name}/info.txt");
                    Skin globalSkin = JsonConvert.DeserializeObject<Skin>(json);

                    if (SkinExists(globalSkin.id, out Skin localSkin))
                    {
                        localSkin.UpdateLocalData(globalSkin);
                        localSkin.UpdateUI();
                    }
                    else
                    {
                        _skins.Add(globalSkin);
                        globalSkin.CreateUI(_uiElement, _skins.Count - 1);
                    }
                }

                Core.UIHandler.Log($"Loaded {contents.Count} global skins");
            }

            SaveLocalData();
            SetBackgroundColor();
            Sort();
        }

        private void SaveLocalData()
        {
            File.WriteAllText(_localDataPath, JsonConvert.SerializeObject(_skins));
        }

        // UI

        public override void AdjustPageWidth()
        {
            bool scrollVisible = _uiElement.VerticalScroll.Visible;
            _uiElement.Width = Core.UIHandler.MainSectionWidth + (scrollVisible ? 2 : -15);
        }

        private void SetBackgroundColor()
        {
            _uiElement.BackColor = _skins.Count % 2 == 0 ? Colors.DARK_GRAY : Colors.LIGHT_GRAY;
        }

        // Install

        public override void InstallAll()
        {
            if (!UIHandler.PromptQuestion(Title, $"Are you sure you wish to install {_skins.Count} skins?"))
                return;

            Core.UIHandler.Log("Installing all skins");
            foreach (Skin skin in _skins)
            {
                if (!skin.Installed)
                {
                    skin.Install();
                }
                else if (skin.UpdateAvailable)
                {
                    skin.Uninstall();
                    skin.Install();
                }
            }
        }

        public override void UninstallAll()
        {
            if (!UIHandler.PromptQuestion(Title, $"Are you sure you wish to uninstall {_skins.Count} skins?"))
                return;

            Core.UIHandler.Log("Uninstalling all skins");
            foreach (Skin skin in _skins)
            {
                if (skin.Installed)
                {
                    skin.Uninstall();
                }
            }
        }

        // Enable

        public override void EnableAll()
        {
            throw new NotImplementedException();
        }

        public override void DisableAll()
        {
            throw new NotImplementedException();
        }

        // Sort

        public override void Sort()
        {
            _skins.Sort();

            _uiElement.VerticalScroll.Value = 0;
            for (int i = 0; i < _skins.Count; i++)
                _skins[i].SetUIPosition(i);
        }

        // Properties

        public override bool CanInstall => true;
        public override bool CanEnable => false;
        public override bool CanSortDate => false;

        public override SortType CurrentSortType
        {
            get => Core.SettingsHandler.Config.Blas1SkinSort;
            set => Core.SettingsHandler.Config.Blas1SkinSort = value;
        }
    }
}
