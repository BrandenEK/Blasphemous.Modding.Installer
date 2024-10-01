using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.Mods;
using Blasphemous.Modding.Installer.PageComponents.Filters;
using Blasphemous.Modding.Installer.PageComponents.Sorters;

namespace Blasphemous.Modding.Installer.PageComponents.Listers;

internal class ModLister : ILister
{
    private readonly Panel _background;
    private readonly List<Mod> _mods;

    private readonly ISorter<Mod> _sorter;
    private readonly IFilter<Mod> _filter;

    public ModLister(Panel background, List<Mod> mods, ISorter<Mod> sorter, IFilter<Mod> filter)
    {
        _background = background;
        _mods = mods;

        _sorter = sorter;
        _filter = filter;
    }

    public void ClearList()
    {
        foreach (Mod mod in _mods)
        {
            mod.SetUIVisibility(false);
        }
    }

    public void RefreshList()
    {
        if (Core.CurrentPage.Lister != this)
            return;

        Logger.Info("Refreshing list of mods");
        var display = _sorter.Sort(_filter.Filter(_mods));

        _background.VerticalScroll.Value = 0;

        int idx = 0;
        ClearList();

        foreach (Mod mod in display)
        {
            mod.SetUIPosition(idx++);
            mod.SetUIVisibility(true);
        }

        _background.BackColor = display.Count() % 2 == 0 ? Colors.DARK_GRAY : Colors.LIGHT_GRAY;
    }
}
