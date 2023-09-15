using BlasModInstaller.Grouping;
using BlasModInstaller.Loading;
using BlasModInstaller.Sorting;
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

        public BasePage(string title, Bitmap image, IValidator validator)
        {
            _title = title;
            _image = image;

            _validator = validator;
        }

        public abstract Task InstallTools();

        public string Title => _title;
        public Bitmap Image => _image;

        public abstract SortType CurrentSortType { get; set; }

        // New

        private readonly IValidator _validator;

        public IValidator Validator => _validator;
        public abstract IGrouper Grouper { get; }
        public abstract IUIHolder UIHolder { get; }
        public abstract ISorter Sorter { get; }
        public abstract ILoader Loader { get; }
    }
}
