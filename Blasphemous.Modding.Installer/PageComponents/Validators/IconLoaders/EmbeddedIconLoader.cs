using Basalt.Framework.Logging;
using System.Reflection;

namespace Blasphemous.Modding.Installer.PageComponents.Validators.IconLoaders;

internal class EmbeddedIconLoader : IIconLoader
{
    private readonly Dictionary<string, Bitmap> _icons = new();

    public EmbeddedIconLoader()
    {
        string[] icons = { "check", "x", "arrow", "dash", "circles" };
        foreach (string name in icons)
        {
            Bitmap bmp = LoadIcon(name);
            _icons.Add(name, bmp);

            Logger.Warn($"Loaded icon {name}");
        }
    }

    private Bitmap LoadIcon(string name)
    {
        string path = $"Blasphemous.Modding.Installer.Resources.icons.{name}.png";
        using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path)!;

        return new Bitmap(stream);
    }

    public Bitmap GetIcon(string name)
    {
        if (!_icons.TryGetValue(name, out var bitmap))
            throw new ArgumentException($"{name} icon was not loaded", nameof(name));

        return bitmap;
    }
}
