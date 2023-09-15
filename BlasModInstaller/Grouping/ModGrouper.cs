using BlasModInstaller.Mods;
using System.Collections.Generic;
using System.Linq;

namespace BlasModInstaller.Grouping
{
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

            Core.UIHandler.Log("Installing all mods");
            foreach (Mod mod in toInstall)
            {
                mod.Uninstall();
                mod.Install();
            }
        }

        public void UninstallAll()
        {
            IEnumerable<Mod> toUninstall = _mods.Where(x => x.Installed);

            if (!UIHandler.PromptQuestion(_title, $"Are you sure you wish to uninstall {toUninstall.Count()} mods?"))
                return;

            Core.UIHandler.Log("Uninstalling all mods");
            foreach (Mod mod in toUninstall)
            {
                mod.Uninstall();
            }
        }

        public void EnableAll()
        {
            IEnumerable<Mod> toEnable = _mods.Where(x => x.Installed && !x.Enabled);

            if (!UIHandler.PromptQuestion(_title, $"Are you sure you wish to enable {toEnable.Count()} mods?"))
                return;

            Core.UIHandler.Log("Enabling all mods");
            foreach (Mod mod in toEnable)
            {
                mod.Enable();
            }
        }

        public void DisableAll()
        {
            IEnumerable<Mod> toDisable = _mods.Where(x => x.Installed && x.Enabled);

            if (!UIHandler.PromptQuestion(_title, $"Are you sure you wish to disable {toDisable.Count()} mods?"))
                return;

            Core.UIHandler.Log("Disabling all mods");
            foreach (Mod mod in toDisable)
            {
                mod.Disable();
            }
        }

        public bool CanInstall => true;
        public bool CanEnable => true;

        public bool CanSortByCreation => true;
        public bool CanSortByDate => true;
    }
}
