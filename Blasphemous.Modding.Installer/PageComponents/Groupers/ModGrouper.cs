using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.Mods;
using Blasphemous.Modding.Installer.PageComponents.Filters;
using Blasphemous.Modding.Installer.PageComponents.Listers;

namespace Blasphemous.Modding.Installer.PageComponents.Groupers;

internal class ModGrouper : IGrouper
{
    private readonly string _title;
    private readonly IEnumerable<Mod> _mods;

    private readonly ILister _lister;
    private readonly IFilter<Mod> _filter;

    public ModGrouper(string title, IEnumerable<Mod> mods, ILister lister, IFilter<Mod> filter)
    {
        _title = title;
        _mods = mods;

        _lister = lister;
        _filter = filter;
    }

    public void InstallAll()
    {
        IEnumerable<Mod> toInstall = _filter.Filter(_mods).Where(x => !x.Installed || x.UpdateAvailable);

        if (!UIHandler.PromptQuestion(_title, $"Are you sure you wish to install {toInstall.Count()} mods?"))
            return;

        Logger.Info("Installing all mods");
        foreach (Mod mod in toInstall)
        {
            mod.Uninstall(true, false);
            mod.Install(true, false);
        }

        _lister.RefreshList();
    }

    public void UninstallAll()
    {
        IEnumerable<Mod> toUninstall = _filter.Filter(_mods).Where(x => x.Installed);

        if (!UIHandler.PromptQuestion(_title, $"Are you sure you wish to uninstall {toUninstall.Count()} mods?"))
            return;

        Logger.Info("Uninstalling all mods");
        foreach (Mod mod in toUninstall)
        {
            mod.Uninstall(true, false);
        }

        _lister.RefreshList();
    }

    public void EnableAll()
    {
        IEnumerable<Mod> toEnable = _filter.Filter(_mods).Where(x => x.Installed && !x.Enabled);

        if (!UIHandler.PromptQuestion(_title, $"Are you sure you wish to enable {toEnable.Count()} mods?"))
            return;

        Logger.Info("Enabling all mods");
        foreach (Mod mod in toEnable)
        {
            mod.Enable(true, false);
        }

        _lister.RefreshList();
    }

    public void DisableAll()
    {
        IEnumerable<Mod> toDisable = _filter.Filter(_mods).Where(x => x.Installed && x.Enabled);

        if (!UIHandler.PromptQuestion(_title, $"Are you sure you wish to disable {toDisable.Count()} mods?"))
            return;

        Logger.Info("Disabling all mods");
        foreach (Mod mod in toDisable)
        {
            mod.Disable(true, false);
        }

        _lister.RefreshList();
    }

    public void RefreshAll()
    {
        foreach (var mod in _mods)
            mod.UpdateUI();
    }

    public bool CanInstall => true;
    public bool CanEnable => true;

    public bool CanSortByCreation => true;
    public bool CanSortByDate => true;
}
