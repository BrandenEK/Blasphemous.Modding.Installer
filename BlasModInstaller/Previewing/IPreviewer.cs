using BlasModInstaller.Mods;
using BlasModInstaller.Skins;

namespace BlasModInstaller.Previewing
{
    internal interface IPreviewer
    {
        void PreviewMod(ModData mod);

        void PreviewSkin(SkinData skin);

        void Clear();
    }
}
