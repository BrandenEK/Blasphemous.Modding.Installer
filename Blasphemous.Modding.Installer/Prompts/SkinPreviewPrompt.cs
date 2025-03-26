using Blasphemous.Modding.Installer.Skins;

namespace Blasphemous.Modding.Installer.Prompts;

internal partial class SkinPreviewPrompt : Form
{
    public SkinPreviewPrompt(Skin skin)
    {
        InitializeComponent();

        Bitmap preview = LoadPreview();

        Text = skin.Data.name;
        ClientSize = preview.Size;
        BackgroundImage = preview;
    }

    private Bitmap LoadPreview()
    {
        string path = Path.Combine(Environment.CurrentDirectory, "preview.png");
        using var temp = new Bitmap(path);

        return new Bitmap(temp);
    }
}
