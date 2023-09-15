using BlasModInstaller.Grouping;
using BlasModInstaller.Loading;
using BlasModInstaller.Sorting;
using BlasModInstaller.UIHolding;
using BlasModInstaller.Validation;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlasModInstaller.Mods
{
    internal class ModPage : BasePage
    {
        private readonly List<Mod> _mods = new List<Mod>();
        private readonly ModGrouper _grouper;
        private readonly GenericUIHolder<Mod> _uiHolder;
        private readonly ModSorter _sorter;
        private readonly ModLoader _loader;

        public ModPage(string title, Bitmap image, Panel panel, string localDataPath, string remoteDataPath, IValidator validator)
            : base(title, image, validator)
        {
            _grouper = new ModGrouper(title, _mods);
            _uiHolder = new GenericUIHolder<Mod>(panel, _mods);
            _sorter = new ModSorter(_uiHolder, _mods);
            _loader = new ModLoader(localDataPath, remoteDataPath, _uiHolder, _sorter, _mods);
        }

        public override IGrouper Grouper => _grouper;
        public override IUIHolder UIHolder => _uiHolder;
        public override ISorter Sorter => _sorter;
        public override ILoader Loader => _loader;

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

        public override SortType CurrentSortType
        {
            get => Core.SettingsHandler.Config.Blas1ModSort;
            set => Core.SettingsHandler.Config.Blas1ModSort = value;
        }
    }
}
