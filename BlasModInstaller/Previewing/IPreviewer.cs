using BlasModInstaller.Mods;
using BlasModInstaller.Skins;

namespace BlasModInstaller.Previewing
{
    internal interface IPreviewer
    {
        void PreviewMod(Mod mod);

        void PreviewSkin(Skin skin);

        void Clear();
    }
}
