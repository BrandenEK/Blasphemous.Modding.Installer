using Blasphemous.Modding.Installer.Models;
using Blasphemous.Modding.Installer.PageComponents.Groupers;
using Blasphemous.Modding.Installer.PageComponents.Listers;
using Blasphemous.Modding.Installer.PageComponents.Loaders;
using Blasphemous.Modding.Installer.PageComponents.Starters;
using Blasphemous.Modding.Installer.PageComponents.Validators;

namespace Blasphemous.Modding.Installer;

internal class InstallerPage
{
    private readonly string _title;
    private readonly List<HeaderImage> _headers;

    private readonly IGrouper _grouper;
    private readonly ILister _lister;
    private readonly ILoader _loader;
    private readonly IValidator _validator;
    private readonly IGameStarter _starter;

    public PageSettings PageSettings { get; }
    public GameSettings GameSettings { get; }

    public InstallerPage(string title, List<HeaderImage> headers, IGrouper grouper, ILister lister, ILoader loader, IValidator validator, IGameStarter starter, PageSettings pageSettings, GameSettings gameSettings)
    {
        _title = title;
        _headers = headers;

        _grouper = grouper;
        _lister = lister;
        _loader = loader;
        _validator = validator;
        _starter = starter;

        PageSettings = pageSettings;
        GameSettings = gameSettings;
    }

    public string Title => _title;

    public List<HeaderImage> Headers => _headers;
    public HeaderImage CurrentHeader
    {
        get
        {
            HeaderImage? header = _headers.FirstOrDefault(x => x.Name == GameSettings.HeaderImage);

            if (header == null)
            {
                header = _headers.First();
                GameSettings.HeaderImage = header.Name;
            }

            return header;
        }
    }

    public IGrouper Grouper => _grouper;
    public ILister Lister => _lister;
    public ILoader Loader => _loader;
    public IValidator Validator => _validator;
    public IGameStarter GameStarter => _starter;
}
