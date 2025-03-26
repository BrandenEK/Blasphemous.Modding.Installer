using Blasphemous.Modding.Installer.Skins;

namespace Blasphemous.Modding.Installer.Prompts;

internal partial class SkinPreviewPrompt : Form
{
    public SkinPreviewPrompt(Skin skin)
    {
        InitializeComponent();

        Text = skin.Data.name;
        DisplayPreviewImage(skin);
    }

    private async void DisplayPreviewImage(Skin skin)
    {
        Bitmap preview = LoadPreview();
        await Task.Delay(2000);

        ClientSize = preview.Size;
        BackgroundImage = preview;
        _text.Visible = false;
    }

    private Bitmap LoadPreview()
    {
        string path = Path.Combine(Environment.CurrentDirectory, "preview.png");
        using var temp = new Bitmap(path);

        return new Bitmap(temp);
    }
}
