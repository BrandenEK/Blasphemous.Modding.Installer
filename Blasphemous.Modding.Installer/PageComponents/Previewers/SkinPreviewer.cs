using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.Mods;
using Blasphemous.Modding.Installer.Properties;
using Blasphemous.Modding.Installer.Skins;
using System.Net;

namespace Blasphemous.Modding.Installer.PageComponents.Previewers;

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
        // Check for file in the cache
        bool previewExists = skin.ExistsInCache("preview.png", out string previewCache);

        // If it was missing, download it from web to cache
        if (!previewExists)
        {
            Logger.Warn($"Downloading skin preview ({skin.Data.name}) from web");
            using (WebClient client = new WebClient())
            {
                try
                {
                    await client.DownloadFileTaskAsync(new Uri(skin.PreviewURL), previewCache);
                    return new Bitmap(previewCache);
                }
                catch (Exception e)
                {
                    Logger.Error("Failed to load skin preview: " + e.Message);
                    return Resources.warning;
                }
            }
        }

        // Create new image from preview in cache
        return new Bitmap(previewCache);
    }

    public void Clear()
    {
        _background.BackgroundImage?.Dispose();
        _background.BackgroundImage = null;
    }
}
