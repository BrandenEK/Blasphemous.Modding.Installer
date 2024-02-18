using Blasphemous.Modding.Installer.Grouping;
using Blasphemous.Modding.Installer.Loading;
using Blasphemous.Modding.Installer.Previewing;
using Blasphemous.Modding.Installer.Sorting;
using Blasphemous.Modding.Installer.UIHolding;
using Blasphemous.Modding.Installer.Validation;

namespace Blasphemous.Modding.Installer;

internal class InstallerPage
{
    private readonly string _title;
    private readonly Bitmap _image;

    private readonly IGrouper _grouper;
    private readonly ILoader _loader;
    private readonly IPreviewer _previewer;
    private readonly ISorter _sorter;
    private readonly IUIHolder _uiHolder;
    private readonly IValidator _validator;

    public InstallerPage(string title, Bitmap image, IGrouper grouper, ILoader loader, IPreviewer previewer, ISorter sorter, IUIHolder uiHolder, IValidator validator)
    {
        _title = title;
        _image = image;

        _grouper = grouper;
        _loader = loader;
        _previewer = previewer;
        _sorter = sorter;
        _uiHolder = uiHolder;
        _validator = validator;
    }

    public string Title => _title;
    public Bitmap Image => _image;

    public IGrouper Grouper => _grouper;
    public ILoader Loader => _loader;
    public IPreviewer Previewer => _previewer;
    public ISorter Sorter => _sorter;
    public IUIHolder UIHolder => _uiHolder;
    public IValidator Validator => _validator;
}
