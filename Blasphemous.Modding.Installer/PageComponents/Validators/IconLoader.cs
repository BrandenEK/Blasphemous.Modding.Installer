
namespace Blasphemous.Modding.Installer.PageComponents.Validators;

internal class IconLoader
{
    private readonly Dictionary<string, Bitmap> _icons = new();

    public IconLoader()
    {

    }

    public Bitmap GetIcon(string name)
    {
        if (!_icons.TryGetValue(name, out var bitmap))
            throw new ArgumentException($"{name} icon was not loaded", nameof(name));

        return bitmap;
    }
}
