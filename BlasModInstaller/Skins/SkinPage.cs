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

namespace BlasModInstaller.Skins
{
    internal class SkinPage : BasePage
    {
        private readonly List<Skin> _skins = new List<Skin>();
        private readonly SkinGrouper _grouper;
        private readonly GenericUIHolder<Skin> _uiHolder;
        private readonly SkinSorter _sorter;
        private readonly SkinLoader _loader;

        public SkinPage(string title, Bitmap image, Panel panel, string localDataPath, IValidator validator)
            : base(title, image, validator)
        {
            _grouper = new SkinGrouper(title, _skins);
            _uiHolder = new GenericUIHolder<Skin>(panel, _skins);
            _sorter = new SkinSorter(_uiHolder, _skins);
            _loader = new SkinLoader(localDataPath, string.Empty, _uiHolder, _sorter, _skins);
        }

        public override IGrouper Grouper => _grouper;
        public override IUIHolder UIHolder => _uiHolder;
        public override ISorter Sorter => _sorter;
        public override ILoader Loader => _loader;

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
            get => Core.SettingsHandler.Config.Blas1SkinSort;
            set => Core.SettingsHandler.Config.Blas1SkinSort = value;
        }
    }
}
