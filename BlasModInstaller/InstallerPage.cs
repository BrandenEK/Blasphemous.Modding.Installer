using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlasModInstaller.Pages
{
    public abstract class InstallerPage<T>
    {
        // Where local data is saved
        protected abstract string SaveDataPath { get; }

        public abstract string Name { get; }

        // The current list of mods/skins
        protected List<T> dataCollection = new List<T>();
        public int DataCount => dataCollection.Count;

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

        public abstract void Sort();

        public void InstallAll()
        {
            if (MessageBox.Show($"Are you sure you wish to install {DataCount} items?", Name, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Core.UIHandler.Log("Installing all items");
                OnInstallAll();
            }
        }
        protected virtual void OnInstallAll() { }

        public void UninstallAll()
        {
            if (MessageBox.Show($"Are you sure you wish to uninstall {DataCount} items?", Name, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Core.UIHandler.Log("Uninstalling all items");
                OnUninstallAll();
            }
        }
        protected virtual void OnUninstallAll() { }

        public void EnableAll()
        {
            if (MessageBox.Show($"Are you sure you wish to enable {DataCount} items?", Name, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Core.UIHandler.Log("Enabling all items");
                OnEnableAll();
            }
        }
        protected virtual void OnEnableAll() { }

        public void DisableAll()
        {
            if (MessageBox.Show($"Are you sure you wish to disable {DataCount} items?", Name, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Core.UIHandler.Log("Disabling all items");
                OnDisableAll();
            }
        }
        protected virtual void OnDisableAll() { }

        protected void SetBackgroundColor()
        {
            _pageSection.BackColor = dataCollection.Count % 2 == 0 ? Colors.DARK_GRAY : Colors.LIGHT_GRAY;
        }

        public void AdjustPageWidth()
        {
            bool scrollVisible = _pageSection.VerticalScroll.Visible;
            _pageSection.Width = Core.UIHandler.MainSectionWidth + (scrollVisible ? 2 : -15);
        }
    }
}
