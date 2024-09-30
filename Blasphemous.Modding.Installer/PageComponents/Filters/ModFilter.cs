using Blasphemous.Modding.Installer.Mods;

namespace Blasphemous.Modding.Installer.PageComponents.Filters;

internal class ModFilter : IFilter<Mod>
{
    private readonly SectionType _section;

    public ModFilter(SectionType section)
    {
        _section = section;
    }

    public IEnumerable<Mod> Filter(IEnumerable<Mod> list)
    {
        FilterType filter = Core.SettingsHandler.Properties.GetFilter(_section);

        return filter switch
        {
            FilterType.NotInstalled => list.Where(x => !x.Installed),
            FilterType.Installed => list.Where(x => x.Installed),
            FilterType.Disabled => list.Where(x => !x.Enabled),
            FilterType.Enabled => list.Where(x => x.Enabled),
            _ => list
        };
    }
}
