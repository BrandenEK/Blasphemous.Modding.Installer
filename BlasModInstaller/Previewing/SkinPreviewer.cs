using BlasModInstaller.Mods;
using BlasModInstaller.Properties;
using BlasModInstaller.Skins;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
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

        public void PreviewMod(Mod mod) => throw new NotImplementedException();

        public async void PreviewSkin(Skin skin)
        {
            _background.BackgroundImage = await LoadPreviewImageAsync(skin);
        }

        private async Task<Bitmap> LoadPreviewImageAsync(Skin skin)
        {
            // If preview is already in cache, use it
            if (skin.ExistsInCache("preview.png", out string cachePath))
                return new Bitmap(cachePath);

            // Otherwise, download from web into cache
            using (WebClient client = new WebClient())
            {
                Directory.CreateDirectory(Path.GetDirectoryName(cachePath));

                try
                {
                    await client.DownloadFileTaskAsync(new Uri(skin.PreviewURL), cachePath);
                    return new Bitmap(cachePath);
                }
                catch (Exception e)
                {
                    Core.UIHandler.Log("Failed to load skin preview: " + e.Message);
                    return Resources.warning;
                }
            }
        }

        public void Clear()
        {
            _background.BackgroundImage?.Dispose();
            _background.BackgroundImage = null;
        }
    }
}
