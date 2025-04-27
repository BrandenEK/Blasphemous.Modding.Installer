
namespace Blasphemous.Modding.Installer.Models;

public class HeaderImage
{
    public HeaderImage(string name, Bitmap image, bool flipalign, bool darkmode, int offset)
    {
        Name = name;
        Image = image;
        FlipAlign = flipalign;
        DarkMode = darkmode;
        Offset = offset;
    }

    public string Name { get; }

    public Bitmap Image { get; }

    public bool FlipAlign { get; }

    public bool DarkMode { get; }

    public int Offset { get; }
}
