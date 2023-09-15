using BlasModInstaller.Grouping;
using BlasModInstaller.Loading;
using BlasModInstaller.Sorting;
using BlasModInstaller.UIHolding;
using BlasModInstaller.Validation;
using System.Collections.Generic;
using System.Drawing;
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
    }
}
