using BlasModInstaller.Grouping;
using BlasModInstaller.Loading;
using BlasModInstaller.Sorting;
using BlasModInstaller.UIHolding;
using BlasModInstaller.Validation;
using System.Collections.Generic;
using System.Drawing;
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

        public override SortType CurrentSortType
        {
            get => Core.SettingsHandler.Config.Blas1SkinSort;
            set => Core.SettingsHandler.Config.Blas1SkinSort = value;
        }
    }
}
