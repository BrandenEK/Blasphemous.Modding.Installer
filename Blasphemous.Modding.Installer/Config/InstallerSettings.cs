
namespace Blasphemous.Modding.Installer.Config;

public class InstallerSettings
{
    public WindowSettings Window { get; set; } = new();

    public SectionType LastSection { get; set; } = SectionType.Blas1Mods;

    public List<GameSettings> Games { get; set; } = new();
    public List<PageSettings> Pages { get; set; } = new();

    public GameSettings GetGameSettings(string id)
    {
        var settings = Games.FirstOrDefault(x => x.Id == id);
        return settings ?? CreateNewGame(id);
    }

    private GameSettings CreateNewGame(string id)
    {
        var settings = new GameSettings()
        {
            Id = id
        };
        Games.Add(settings);
        return settings;
    }

    public PageSettings GetPageSettings(string id)
    {
        var settings = Pages.FirstOrDefault(x => x.Id == id);
        return settings ?? CreateNewPage(id);
    }

    private PageSettings CreateNewPage(string id)
    {
        var settings = new PageSettings()
        {
            Id = id
        };
        Pages.Add(settings);
        return settings;
    }
}

public class WindowSettings
{
    public Point Location { get; set; } = new Point(0, 0);
    public Size Size { get; set; } = new Size(1, 1);
    public bool IsMaximized { get; set; } = true;
}

public class GameSettings
{
    public string Id { get; set; } = string.Empty;
    public string RootFolder { get; set; } = string.Empty;
    public LaunchOptions LaunchOptions { get; set; } = new LaunchOptions(true, true);
}

public class PageSettings
{
    public string Id { get; set; } = string.Empty;
    public SortType Sort { get; set; } = SortType.Name;
    public FilterType Filter { get; set; } = FilterType.All;
    public DateTime Time { get; set; } = DateTime.Now;
}
