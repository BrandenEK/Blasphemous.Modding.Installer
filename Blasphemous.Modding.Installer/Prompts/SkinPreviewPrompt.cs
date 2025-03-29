using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.Extensions;
using Blasphemous.Modding.Installer.Skins;
using System.Text;

namespace Blasphemous.Modding.Installer.Prompts;

internal partial class SkinPreviewPrompt : Form
{
    public SkinPreviewPrompt(Skin skin, int scale)
    {
        InitializeComponent();

        Text = skin.Data.name;
        DisplayPreviewImage(skin, scale);
    }

    private async void DisplayPreviewImage(Skin skin, int scale)
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

    private static Bitmap LoadImageFromFile(string path)
    {
        using var image = new Bitmap(path);
        return new Bitmap(image);
    }

    private static async Task DownloadImageToFile(string url, string path)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);

        using var client = new HttpClient();
        await client.DownloadFileAsync(new Uri(url), path);
    }

    //private Bitmap LoadPreview(int scale)
    //{
    //    string path = Path.Combine(Environment.CurrentDirectory, "preview.png");

    //    using var temp = new Bitmap(path);
    //    var image = new Bitmap(temp.Width * scale, temp.Height * scale);

    //    for (int x = 0; x < image.Width; x++)
    //    {
    //        for (int y = 0; y < image.Height; y++)
    //        {
    //            Color pixel = temp.GetPixel(x / scale, y / scale);
    //            image.SetPixel(x, y, pixel);
    //        }
    //    }

    //    return image;
    //}
}
