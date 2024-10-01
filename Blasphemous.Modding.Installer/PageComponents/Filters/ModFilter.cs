using Blasphemous.Modding.Installer.Mods;

namespace Blasphemous.Modding.Installer.PageComponents.Filters;

internal class ModFilter : IFilter<Mod>
{
    private readonly PageSettings _settings;

    public ModFilter(PageSettings settings)
    {
        _settings = settings;
    }

    public IEnumerable<Mod> Filter(IEnumerable<Mod> list)
    {
        FilterType filter = _settings.Filter;

        return filter switch
        {
            FilterType.NotInstalled => list.Where(x => !x.Installed),
            FilterType.Installed => list.Where(x => x.Installed),
            FilterType.Disabled => list.Where(x => x.Installed && !x.Enabled),
            FilterType.Enabled => list.Where(x => x.Enabled),
            _ => list
        };
    }
}
