using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.Mods;

namespace Blasphemous.Modding.Installer.PageComponents.Groupers;

internal class ModGrouper : IGrouper
{
    private readonly string _title;
    private readonly IEnumerable<Mod> _mods;

    public ModGrouper(string title, IEnumerable<Mod> mods)
    {
        _title = title;
        _mods = mods;
    }

    public void InstallAll()
    {
        IEnumerable<Mod> toInstall = _mods.Where(x => !x.Installed || x.UpdateAvailable);

        if (!UIHandler.PromptQuestion(_title, $"Are you sure you wish to install {toInstall.Count()} mods?"))
            return;

        Logger.Info("Installing all mods");
        foreach (Mod mod in toInstall)
        {
            mod.Uninstall(true);
            mod.Install(true);
        }
    }

    public void UninstallAll()
    {
        IEnumerable<Mod> toUninstall = _mods.Where(x => x.Installed);

        if (!UIHandler.PromptQuestion(_title, $"Are you sure you wish to uninstall {toUninstall.Count()} mods?"))
            return;

        Logger.Info("Uninstalling all mods");
        foreach (Mod mod in toUninstall)
        {
            mod.Uninstall(true);
        }
    }

    public void EnableAll()
    {
        IEnumerable<Mod> toEnable = _mods.Where(x => x.Installed && !x.Enabled);

        if (!UIHandler.PromptQuestion(_title, $"Are you sure you wish to enable {toEnable.Count()} mods?"))
            return;

        Logger.Info("Enabling all mods");
        foreach (Mod mod in toEnable)
        {
            mod.Enable(true);
        }
    }

    public void DisableAll()
    {
        IEnumerable<Mod> toDisable = _mods.Where(x => x.Installed && x.Enabled);

        if (!UIHandler.PromptQuestion(_title, $"Are you sure you wish to disable {toDisable.Count()} mods?"))
            return;

        Logger.Info("Disabling all mods");
        foreach (Mod mod in toDisable)
        {
            mod.Disable(true);
        }
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
