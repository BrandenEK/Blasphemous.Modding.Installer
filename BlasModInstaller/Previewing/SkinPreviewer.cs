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
            // Check for cache

            // Set loading image

            using (WebClient client = new WebClient())
            {
                string downloadPath = $"{UIHandler.DownloadsPath}blas1skins\\{skin.Data.id}\\{skin.Data.version}";
                Directory.CreateDirectory(downloadPath);

                try
                {
                    await client.DownloadFileTaskAsync(new Uri(skin.PreviewURL), downloadPath + "\\preview.png");
                    return new Bitmap(downloadPath + "\\preview.png");
                }
                catch (Exception)
                {
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
