using Blasphemous.Modding.Installer.PageComponents.Grouping;
using Blasphemous.Modding.Installer.PageComponents.Loading;
using Blasphemous.Modding.Installer.PageComponents.Previewing;
using Blasphemous.Modding.Installer.PageComponents.Sorting;
using Blasphemous.Modding.Installer.PageComponents.Starting;
using Blasphemous.Modding.Installer.PageComponents.UIHolding;
using Blasphemous.Modding.Installer.PageComponents.Validation;

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
    private readonly IGameStarter _starter;

    public InstallerPage(string title, Bitmap image, IGrouper grouper, ILoader loader, IPreviewer previewer, ISorter sorter, IUIHolder uiHolder, IValidator validator, IGameStarter starter)
    {
        _title = title;
        _image = image;

        _grouper = grouper;
        _loader = loader;
        _previewer = previewer;
        _sorter = sorter;
        _uiHolder = uiHolder;
        _validator = validator;
        _starter = starter;
    }

    public string Title => _title;
    public Bitmap Image => _image;

    public IGrouper Grouper => _grouper;
    public ILoader Loader => _loader;
    public IPreviewer Previewer => _previewer;
    public ISorter Sorter => _sorter;
    public IUIHolder UIHolder => _uiHolder;
    public IValidator Validator => _validator;
    public IGameStarter GameStarter => _starter;
}
