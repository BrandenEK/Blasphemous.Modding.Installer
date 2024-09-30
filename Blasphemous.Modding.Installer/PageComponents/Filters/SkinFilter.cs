using Blasphemous.Modding.Installer.Skins;

namespace Blasphemous.Modding.Installer.PageComponents.Filters;

internal class SkinFilter : IFilter<Skin>
{
    private readonly SectionType _section;

    public SkinFilter(SectionType section)
    {
        _section = section;
    }

    public IEnumerable<Skin> Filter(IEnumerable<Skin> list)
    {
        FilterType filter = Core.SettingsHandler.Properties.GetFilter(_section);

        return filter switch
        {
            FilterType.NotInstalled => list.Where(x => !x.Installed),
            FilterType.Installed => list.Where(x => x.Installed),
            _ => list
        };
    }
}
