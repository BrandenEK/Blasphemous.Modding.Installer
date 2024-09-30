using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.Mods;

namespace Blasphemous.Modding.Installer.PageComponents.Listers;

internal class ModLister : ILister
{
    private readonly Panel _background;
    private readonly List<Mod> _mods;

    public ModLister(Panel background, List<Mod> mods)
    {
        _background = background;
        _mods = mods;
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

        _background.VerticalScroll.Value = 0;

        int idx = 0;
        foreach (Mod mod in _mods)
        {
            mod.SetUIPosition(idx++);
            mod.SetUIVisibility(true);
        }

        _background.BackColor = _mods.Count % 2 == 0 ? Colors.DARK_GRAY : Colors.LIGHT_GRAY;
    }
}
