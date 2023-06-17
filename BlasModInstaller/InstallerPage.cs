using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlasModInstaller.Pages
{
    public abstract class InstallerPage
    {
        private bool _loadedData = false;

        private readonly Panel _pageSection;
        protected Panel PageSection => _pageSection;

        public InstallerPage(Panel pageSection)
        {
            _pageSection = pageSection;
        }

        public void LoadData()
        {
            if (!_loadedData)
                LoadExternalData();
            _loadedData = true;
        }

        protected abstract void LoadExternalData();


        // New

        protected abstract string SaveDataPath { get; }
    }
}
