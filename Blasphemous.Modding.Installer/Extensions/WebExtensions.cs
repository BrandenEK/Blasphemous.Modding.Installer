using Basalt.Framework.Logging;

namespace Blasphemous.Modding.Installer.Extensions;

public static class WebExtensions
{
    public static async Task DownloadFileAsync(this HttpClient client, Uri uri, string fileName, int timeout)
    {
        try
        {
            using var stream = await client.GetStreamAsync(uri);
            using var filestream = new FileStream(fileName, FileMode.CreateNew);
            await stream.CopyToAsync(filestream);
        }
        catch (HttpRequestException ex)
        {
            if (ex.StatusCode != System.Net.HttpStatusCode.TooManyRequests)
                throw;

            Logger.Warn($"HTTP 429 error when downloading {uri}.  Retrying...");
            await Task.Delay(timeout);
            await DownloadFileAsync(client, uri, fileName, timeout + Core.HTTP_TIMEOUT);
        }
    }
}
