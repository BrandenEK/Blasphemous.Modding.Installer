using Blasphemous.Modding.Installer.Mods;
using Blasphemous.Modding.Installer.Skins;

namespace Blasphemous.Modding.Installer.PageComponents.Previewing;

internal interface IPreviewer
{
    void PreviewMod(Mod mod);

    void PreviewSkin(Skin skin);

    void Clear();
}
