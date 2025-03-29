using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.Extensions;
using Blasphemous.Modding.Installer.Properties;
using Blasphemous.Modding.Installer.Skins;

namespace Blasphemous.Modding.Installer;

internal static class CacheHelper
{
    public static bool GetPreviewCachePath(this Skin skin, out string cachePath)
    {
        cachePath = $"{Core.CacheFolder}/blas1skins/{skin.Data.id}/{skin.Data.version}/preview.png";

        return File.Exists(cachePath) && new FileInfo(cachePath).Length > 0;
    }

    //public static Task<Bitmap> LoadPreviewFromCache(this Skin skin)
    //{
    //    if (!skin.GetPreviewCachePath(out string cachePath))
    //    {

    //    }
    //}

    //public static async Task LoadPreviewFromWeb(this Skin skin, string path)
    //{
    //    Logger.Warn($"Downloading skin preview ({skin.Data.name}) from web");
    //    using var client = new HttpClient();

    //    try
    //    {
    //        await client.DownloadFileAsync(new Uri(skin.PreviewURL), path);
    //    }
    //    catch (Exception e)
    //    {
    //        Logger.Error("Failed to load skin preview: " + e.Message);
    //        return Resources.warning;
    //    }
    //}

    //private async Task<Bitmap> LoadPreviewImageAsync(Skin skin)
    //{
    //    // Check for file in the cache
    //    bool previewExists = skin.ExistsInCache("preview.png", out string previewCache);

    //    // If it was missing, download it from web to cache
    //    if (!previewExists)
    //    {
    //        Logger.Warn($"Downloading skin preview ({skin.Data.name}) from web");
    //        using var client = new HttpClient();

    //        try
    //        {
    //            await client.DownloadFileAsync(new Uri(skin.PreviewURL), previewCache);
    //            return new Bitmap(previewCache);
    //        }
    //        catch (Exception e)
    //        {
    //            Logger.Error("Failed to load skin preview: " + e.Message);
    //            return Resources.warning;
    //        }
    //    }

    //    // Create new image from preview in cache
    //    return new Bitmap(previewCache);
    //}
}
