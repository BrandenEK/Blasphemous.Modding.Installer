using BlasModInstaller.Mods;
using BlasModInstaller.Skins;
using System;
using System.Windows.Forms;

namespace BlasModInstaller.Previewing
{
    internal class ModPreviewer : IPreviewer
    {
        private readonly Label _name;
        private readonly Label _description;
        private readonly Label _version;

        public ModPreviewer(Label name, Label description, Label version)
        {
            _name = name;
            _description = description;
            _version = version;
        }

        public void PreviewMod(ModData mod)
        {
            _name.Visible = true;
            _description.Visible = true;
            _version.Visible = true;

            _name.Text = mod.name;
            _description.Text = "    " + mod.description;
            _version.Text = $"Latest version:{Environment.NewLine}v{mod.latestVersion} on {mod.latestReleaseDate:MM/dd/yyyy}";
        }

        public void PreviewSkin(SkinData skin) => throw new NotImplementedException();

        public void Clear()
        {
            _name.Text = string.Empty;
            _description.Text = string.Empty;
            _version.Text = string.Empty;

            _name.Visible = false;
            _description.Visible = false;
            _version.Visible = false;
        }
    }
}
