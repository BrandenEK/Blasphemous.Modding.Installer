using BlasModInstaller.Grouping;
using BlasModInstaller.Validation;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlasModInstaller
{
    internal abstract class BasePage
    {
        protected readonly string _title;
        protected readonly Bitmap _image;
        protected readonly Panel _uiElement;
        protected readonly string _localDataPath;
        protected readonly string _globalDataPath;

        public BasePage(string title, Bitmap image, Panel uiElement, string localDataPath, string globalDataPath, IValidator validator)
        {
            _title = title;
            _image = image;
            _uiElement = uiElement;
            _localDataPath = localDataPath;
            _globalDataPath = globalDataPath;

            _validator = validator;
        }

        public abstract void AdjustPageWidth();

        public abstract void LoadData();
        public abstract Task InstallTools();

        public abstract void Sort();

        public abstract bool CanInstall { get; }
        public abstract bool CanEnable { get; }
        public abstract bool CanSortDate { get; }

        public string Title => _title;
        public Bitmap Image => _image;
        public Panel UIElement => _uiElement;

        public abstract SortType CurrentSortType { get; set; }

        // New

        private readonly IValidator _validator;

        public IValidator Validator => _validator;
        public abstract IGrouper Grouper { get; }
    }
}
