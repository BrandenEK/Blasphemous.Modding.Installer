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
        throw new NotImplementedException();
    }

    public void RefreshList()
    {
        Logger.Info("Refreshing list of mods");
    }
}
