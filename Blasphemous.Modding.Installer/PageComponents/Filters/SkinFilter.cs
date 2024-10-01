using Blasphemous.Modding.Installer.Skins;

namespace Blasphemous.Modding.Installer.PageComponents.Filters;

internal class SkinFilter : IFilter<Skin>
{
    private readonly PageSettings _settings;

    public SkinFilter(PageSettings settings)
    {
        _settings = settings;
    }

    public IEnumerable<Skin> Filter(IEnumerable<Skin> list)
    {
        FilterType filter = _settings.Filter;

        return filter switch
        {
            FilterType.NotInstalled => list.Where(x => !x.Installed),
            FilterType.Installed => list.Where(x => x.Installed),
            _ => list
        };
    }
}
