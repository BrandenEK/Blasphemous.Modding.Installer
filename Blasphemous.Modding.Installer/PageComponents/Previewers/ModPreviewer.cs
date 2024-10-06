using Blasphemous.Modding.Installer.Mods;
using Blasphemous.Modding.Installer.Skins;

namespace Blasphemous.Modding.Installer.PageComponents.Previewers;

internal class ModPreviewer : IPreviewer
{
    public void PreviewMod(Mod mod)
    {
        string name = mod.Data.name;
        string description = $"    {mod.Data.description}";
        string version = $"Latest version:{Environment.NewLine}v{mod.Data.latestVersion} on {mod.Data.latestReleaseDate:MM/dd/yyyy}";

        Core.UIHandler.UpdatePreview(name, description, version, null);
    }

    public void PreviewSkin(Skin skin) => throw new NotImplementedException();

    public void Clear()
    {
        Core.UIHandler.ClearPreview();
    }
}
