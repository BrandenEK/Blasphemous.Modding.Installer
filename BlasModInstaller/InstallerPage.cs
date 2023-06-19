using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BlasModInstaller.Pages
{
    public abstract class InstallerPage<T>
    {
        // Where local data is saved
        protected abstract string SaveDataPath { get; }

        // The current list of mods/skins
        protected List<T> dataCollection = new List<T>();

        private bool _loadedData = false;

        private readonly Panel _pageSection;
        protected Panel PageSection => _pageSection;

        public InstallerPage(Panel pageSection)
        {
            _pageSection = pageSection;
        }

        protected bool DataExists(T searchData, out T foundData)
        {
            foreach (T data in dataCollection)
            {
                if (searchData.Equals(data))
                {
                    foundData = data;
                    return true;
                }
            }
            foundData = default;
            return false;
        }

        // Save the current list of skins/mods to a json file
        protected virtual void SaveLocalData()
        {
            File.WriteAllText(SaveDataPath, JsonConvert.SerializeObject(dataCollection));
        }

        public void LoadData()
        {
            if (!_loadedData)
            {
                LoadLocalData();
                LoadGlobalData();
                _loadedData = true;
            }
            AdjustPageWidth();
        }

        // Loads local data from json into the collection
        protected virtual void LoadLocalData()
        {
            if (File.Exists(SaveDataPath))
            {
                string json = File.ReadAllText(SaveDataPath);
                List<T> localData = JsonConvert.DeserializeObject<List<T>>(json);
                dataCollection.AddRange(localData);
            }
        }

        // Loads global data from github into the collection
        protected virtual async Task LoadGlobalData()
        {

        }

        protected void SetBackgroundColor()
        {
            _pageSection.BackColor = dataCollection.Count % 2 == 0 ? Colors.DARK_GRAY : Colors.LIGHT_GRAY;
        }

        public void AdjustPageWidth()
        {
            bool scrollVisible = _pageSection.VerticalScroll.Visible;
            _pageSection.Width = MainForm.Instance.MainSectionWidth + (scrollVisible ? 2 : -15);
        }
    }
}
