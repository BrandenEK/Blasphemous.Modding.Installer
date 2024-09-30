using Blasphemous.Modding.Installer.PageComponents.Groupers;
using Blasphemous.Modding.Installer.PageComponents.Listers;
using Blasphemous.Modding.Installer.PageComponents.Loaders;
using Blasphemous.Modding.Installer.PageComponents.Previewers;
using Blasphemous.Modding.Installer.PageComponents.Starters;
using Blasphemous.Modding.Installer.PageComponents.UIHolders;
using Blasphemous.Modding.Installer.PageComponents.Validators;

namespace Blasphemous.Modding.Installer;

internal class InstallerPage
{
    private readonly string _title;
    private readonly Bitmap _image;

    private readonly IGrouper _grouper;
    private readonly ILister _lister;
    private readonly ILoader _loader;
    private readonly IPreviewer _previewer;
    private readonly IUIHolder _uiHolder;
    private readonly IValidator _validator;
    private readonly IGameStarter _starter;

    public InstallerPage(string title, Bitmap image, IGrouper grouper, ILister lister, ILoader loader, IPreviewer previewer, IUIHolder uiHolder, IValidator validator, IGameStarter starter)
    {
        _title = title;
        _image = image;

        _grouper = grouper;
        _lister = lister;
        _loader = loader;
        _previewer = previewer;
        _uiHolder = uiHolder;
        _validator = validator;
        _starter = starter;
    }

    public string Title => _title;
    public Bitmap Image => _image;

    public IGrouper Grouper => _grouper;
    public ILister Lister => _lister;
    public ILoader Loader => _loader;
    public IPreviewer Previewer => _previewer;
    public IUIHolder UIHolder => _uiHolder;
    public IValidator Validator => _validator;
    public IGameStarter GameStarter => _starter;
}
