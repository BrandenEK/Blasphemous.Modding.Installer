using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.Extensions;
using Blasphemous.Modding.Installer.Skins;
using System.Text;

namespace Blasphemous.Modding.Installer.Prompts;

internal partial class SkinPreviewPrompt : Form
{
    private readonly int _scaleFactor;

    public SkinPreviewPrompt(Skin skin, int scaleFactor)
    {
        InitializeComponent();

        Text = skin.Data.name;
        _scaleFactor = scaleFactor;

        DisplayPreviewImage(skin);
    }

    private async void DisplayPreviewImage(Skin skin)
    {
        bool cacheHit = skin.GetPreviewCachePath(out string cachePath);

        // Skin preview already exists in the cache
        if (cacheHit)
        {
            ShowPreview(LoadImageFromFile(cachePath));
            return;
        }

        // Attempt to download the file from the web
        try
        {
            Logger.Warn($"Downloading skin preview ({skin.Data.id}) from web");

            await Task.WhenAll(DownloadImageToFile(skin.PreviewURL, cachePath), Task.Delay(500));
            ShowPreview(LoadImageFromFile(cachePath));
        }
        catch (Exception ex)
        {
            string message = new StringBuilder()
                .AppendLine("Failed to load preview:")
                .AppendLine(ex.GetType().Name)
                .AppendLine()
                .AppendLine(ex.Message)
                .ToString();

            Logger.Error(ex);
            ShowFailure(message);
        }
    }

    private void ShowPreview(Bitmap preview)
    {
        Size currentSize = ClientSize;
        ClientSize = preview.Size + new Size(100, 100);
        Size sizeDifference = (ClientSize - currentSize) / 2;

        _text.Visible = false;
        BackgroundImage = preview;
        Location -= sizeDifference;
    }

    private void ShowFailure(string message)
    {
        _text.Text = message;
    }

    private Bitmap LoadImageFromFile(string path)
    {
        using var image = new Bitmap(path);

        return ScalePreview(image);
    }

    private async Task DownloadImageToFile(string url, string path)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);

        using var client = new HttpClient();
        await client.DownloadFileAsync(new Uri(url), path, Core.HTTP_TIMEOUT);
    }

    private Bitmap ScalePreview(Bitmap preview)
    {
        var image = new Bitmap(preview.Width * _scaleFactor, preview.Height * _scaleFactor);

        for (int x = 0; x < image.Width; x++)
        {
            for (int y = 0; y < image.Height; y++)
            {
                Color pixel = preview.GetPixel(x / _scaleFactor, y / _scaleFactor);
                image.SetPixel(x, y, pixel);
            }
        }

        return image;
    }
}
