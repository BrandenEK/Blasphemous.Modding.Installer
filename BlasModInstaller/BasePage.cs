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

        public BasePage(string title, Bitmap image, Panel uiElement, string localDataPath, string globalDataPath)
        {
            _title = title;
            _image = image;
            _uiElement = uiElement;
            _localDataPath = localDataPath;
            _globalDataPath = globalDataPath;
        }

        public abstract void AdjustPageWidth();

        public abstract void LoadData();
        public abstract Task InstallTools();

        public abstract void InstallAll();
        public abstract void UninstallAll();

        public abstract void EnableAll();
        public abstract void DisableAll();

        public abstract void Sort();

        public abstract bool CanInstall { get; }
        public abstract bool CanEnable { get; }
        public abstract bool CanSortDate { get; }

        public string Title => _title;
        public Bitmap Image => _image;
        public Panel UIElement => _uiElement;

        public abstract SortType CurrentSortType { get; set; }

        // Move all of these to validator
        public abstract bool IsRootFolderValid { get; }
        public abstract bool AreModdingToolsInstalled { get; }
        public abstract string ExeName { get; }
    }
}
