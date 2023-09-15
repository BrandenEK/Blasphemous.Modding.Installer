using BlasModInstaller.Grouping;
using BlasModInstaller.UIHolding;
using BlasModInstaller.Validation;
using System.Drawing;
using System.Threading.Tasks;

namespace BlasModInstaller
{
    internal abstract class BasePage
    {
        protected readonly string _title;
        protected readonly Bitmap _image;
        protected readonly string _localDataPath;
        protected readonly string _globalDataPath;

        public BasePage(string title, Bitmap image, string localDataPath, string globalDataPath, IValidator validator)
        {
            _title = title;
            _image = image;
            _localDataPath = localDataPath;
            _globalDataPath = globalDataPath;

            _validator = validator;
        }

        public abstract void LoadData();
        public abstract Task InstallTools();

        public abstract void Sort();

        public string Title => _title;
        public Bitmap Image => _image;

        public abstract SortType CurrentSortType { get; set; }

        // New

        private readonly IValidator _validator;

        public IValidator Validator => _validator;
        public abstract IGrouper Grouper { get; }
        public abstract IUIHolder UIHolder { get; }
    }
}
