
namespace Blasphemous.Modding.Installer.Extensions;

public static class WebExtensions
{
    public static async Task DownloadFileAsync(this HttpClient client, Uri uri, string fileName)
    {
        using var stream = await client.GetStreamAsync(uri);
        using var filestream = new FileStream(fileName, FileMode.CreateNew);
        await stream.CopyToAsync(filestream);
    }
}
