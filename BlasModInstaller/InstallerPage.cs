using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BlasModInstaller.Pages
{
    public abstract class InstallerPage
    {
        // Where local data is saved
        protected abstract string SaveDataPath { get; }

        private bool _loadedData = false;

        private readonly Panel _pageSection;
        protected Panel PageSection => _pageSection;

        public InstallerPage(Panel pageSection)
        {
            _pageSection = pageSection;
        }

        // Save the current list of skins/mods to a json file
        public abstract void SaveLocalData();

        public void LoadData()
        {
            if (!_loadedData)
                LoadExternalData();
            _loadedData = true;
        }

        // Load list of skins/mods from local json and from online
        protected abstract void LoadExternalData();
    }
}
