using Blasphemous.Modding.Installer.Mods;
using Blasphemous.Modding.Installer.Skins;

namespace Blasphemous.Modding.Installer.PageComponents.Previewers;

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

    public void PreviewMod(Mod mod)
    {
        //_name.Visible = true;
        //_description.Visible = true;
        //_version.Visible = true;

        //_name.Text = mod.Data.name;
        //_description.Text = "    " + mod.Data.description;
        //_version.Text = $"Latest version:{Environment.NewLine}v{mod.Data.latestVersion} on {mod.Data.latestReleaseDate:MM/dd/yyyy}";

        string name = mod.Data.name;
        string description = $"    {mod.Data.description}";
        string version = $"Latest version:{Environment.NewLine}v{mod.Data.latestVersion} on {mod.Data.latestReleaseDate:MM/dd/yyyy}";

        Core.UIHandler.UpdatePreview(name, description, version, null);
    }

    public void PreviewSkin(Skin skin) => throw new NotImplementedException();

    public void Clear()
    {
        //_name.Text = string.Empty;
        //_description.Text = string.Empty;
        //_version.Text = string.Empty;

        //_name.Visible = false;
        //_description.Visible = false;
        //_version.Visible = false;

        Core.UIHandler.ClearPreview();
    }
}
