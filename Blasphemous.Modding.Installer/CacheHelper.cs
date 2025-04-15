using Blasphemous.Modding.Installer.Skins;

namespace Blasphemous.Modding.Installer;

internal static class CacheHelper
{
    public static bool GetPreviewCachePath(this Skin skin, out string cachePath)
    {
        cachePath = $"{Core.CacheFolder}/{skin.CacheSubFolder}/{skin.Data.id}/{skin.Data.version}/preview.png";

        return File.Exists(cachePath) && new FileInfo(cachePath).Length > 0;
    }
}
