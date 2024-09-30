using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.Mods;
using Blasphemous.Modding.Installer.PageComponents.Sorters;

namespace Blasphemous.Modding.Installer.PageComponents.Listers;

internal class ModLister : ILister
{
    private readonly Panel _background;
    private readonly List<Mod> _mods;

    private readonly ISorter<Mod> _sorter;

    public ModLister(Panel background, List<Mod> mods, ISorter<Mod> sorter)
    {
        _background = background;
        _mods = mods;

        _sorter = sorter;
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
        Logger.Info("Refreshing list of mods");
        var display = _sorter.Sort(_mods);

        _background.VerticalScroll.Value = 0;

        int idx = 0;
        foreach (Mod mod in display)
        {
            mod.SetUIPosition(idx++);
            mod.SetUIVisibility(true);
        }

        _background.BackColor = display.Count() % 2 == 0 ? Colors.DARK_GRAY : Colors.LIGHT_GRAY;
    }
}
