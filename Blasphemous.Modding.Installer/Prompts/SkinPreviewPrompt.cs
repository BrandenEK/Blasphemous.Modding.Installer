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
        Bitmap preview = LoadPreview();
        await Task.Delay(2000);

        Size currentSize = ClientSize;
        ClientSize = preview.Size + new Size(100, 100);
        Size sizeDifference = (ClientSize - currentSize) / 2;

        Location -= sizeDifference;
        BackgroundImage = preview;
        _text.Visible = false;
    }

    private Bitmap LoadPreview()
    {
        string path = Path.Combine(Environment.CurrentDirectory, "preview.png");
        using var temp = new Bitmap(path);

        return new Bitmap(temp);
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
