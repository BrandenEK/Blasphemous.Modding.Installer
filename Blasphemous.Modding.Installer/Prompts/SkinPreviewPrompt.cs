using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.Extensions;
using Blasphemous.Modding.Installer.Properties;
using Blasphemous.Modding.Installer.Skins;

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

        ShowFailure($"Preview could not be loaded!");

        //Bitmap preview = LoadPreview();
        //await Task.Delay(2000);

        //ShowPreview(preview);
    }

    private void ShowPreview(Bitmap preview)
    {
        Size currentSize = ClientSize;
        ClientSize = preview.Size + new Size(100, 100);
        Size sizeDifference = (ClientSize - currentSize) / 2;

        Location -= sizeDifference;
        BackgroundImage = preview;
        _text.Visible = false;
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

    private Bitmap LoadPreview()
    {
        string path = Path.Combine(Environment.CurrentDirectory, "preview.png");
        using var temp = new Bitmap(path);

        return new Bitmap(temp);
    }

    private async Task<Bitmap> LoadPreviewAsync(Skin skin)
    {
        // Check for file in the cache
        bool previewExists = skin.ExistsInCache("preview.png", out string previewCache);

        // If it was missing, download it from web to cache
        if (!previewExists)
        {
            Logger.Warn($"Downloading skin preview ({skin.Data.name}) from web");
            using var client = new HttpClient();

            try
            {
                await client.DownloadFileAsync(new Uri(skin.PreviewURL), previewCache);
                return new Bitmap(previewCache);
            }
            catch (Exception e)
            {
                Logger.Error("Failed to load skin preview: " + e.Message);
                return Resources.warning;
            }
        }

        // Create new image from preview in cache
        return new Bitmap(previewCache);
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
