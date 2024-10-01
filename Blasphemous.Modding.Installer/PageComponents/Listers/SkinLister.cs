using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.PageComponents.Filters;
using Blasphemous.Modding.Installer.PageComponents.Sorters;
using Blasphemous.Modding.Installer.Skins;

namespace Blasphemous.Modding.Installer.PageComponents.Listers;

internal class SkinLister : ILister
{
    private readonly Panel _background;
    private readonly List<Skin> _skins;

    private readonly ISorter<Skin> _sorter;
    private readonly IFilter<Skin> _filter;

    public SkinLister(Panel background, List<Skin> skins, ISorter<Skin> sorter, IFilter<Skin> filter)
    {
        _background = background;
        _skins = skins;

        _sorter = sorter;
        _filter = filter;
    }

    public void ClearList()
    {
        foreach (Skin skin in _skins)
        {
            skin.SetUIVisibility(false);
        }
    }

    public void RefreshList()
    {
        if (Core.CurrentPage.Lister != this)
            return;

        Logger.Info("Refreshing list of skins");
        var display = _sorter.Sort(_filter.Filter(_skins));

        _background.VerticalScroll.Value = 0;

        int idx = 0;
        ClearList();

        foreach (Skin skin in display)
        {
            skin.SetUIPosition(idx++);
            skin.SetUIVisibility(true);
        }

        _background.BackColor = display.Count() % 2 == 0 ? Colors.DARK_GRAY : Colors.LIGHT_GRAY;
    }
}
