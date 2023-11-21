using BlasModInstaller.Mods;
using BlasModInstaller.Properties;
using BlasModInstaller.Skins;
using System;
using System.Windows.Forms;

namespace BlasModInstaller.Previewing
{
    internal class SkinPreviewer : IPreviewer
    {
        private readonly Panel _background;

        public SkinPreviewer(Panel background)
        {
            _background = background;
        }

        public void PreviewMod(ModData mod) => throw new NotImplementedException();

        public void PreviewSkin(SkinData skin)
        {
            _background.BackgroundImage = Resources.skinPreview;
        }

        public void Clear()
        {
            //_background.BackgroundImage?.Dispose();
            _background.BackgroundImage = null;
        }
    }
}
