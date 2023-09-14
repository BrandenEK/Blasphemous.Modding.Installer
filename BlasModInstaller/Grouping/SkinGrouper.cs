using BlasModInstaller.Skins;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlasModInstaller.Grouping
{
    internal class SkinGrouper : IGrouper
    {
        private readonly string _title;
        private readonly IEnumerable<Skin> _skins;

        public SkinGrouper(string title, IEnumerable<Skin> skins)
        {
            _title = title;
            _skins = skins;
        }

        public void InstallAll()
        {
            IEnumerable<Skin> toInstall = _skins.Where(x => !x.Installed || x.UpdateAvailable);

            if (!UIHandler.PromptQuestion(_title, $"Are you sure you wish to install {toInstall.Count()} skins?"))
                return;

            Core.UIHandler.Log("Installing all skins");
            foreach (Skin skin in toInstall)
            {
                skin.Uninstall();
                skin.Install();
            }
        }

        public void UninstallAll()
        {
            IEnumerable<Skin> toUninstall = _skins.Where(x => x.Installed);

            if (!UIHandler.PromptQuestion(_title, $"Are you sure you wish to uninstall {toUninstall.Count()} skins?"))
                return;

            Core.UIHandler.Log("Uninstalling all mods");
            foreach (Skin skin in toUninstall)
            {
                skin.Uninstall();
            }
        }

        public void EnableAll()
        {
            throw new NotImplementedException();
        }

        public void DisableAll()
        {
            throw new NotImplementedException();
        }
    }
}
