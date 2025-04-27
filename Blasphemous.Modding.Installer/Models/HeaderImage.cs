
namespace Blasphemous.Modding.Installer.Models;

public class HeaderImage
{
    public HeaderImage(string name, Bitmap image, bool flipalign, int offset)
    {
        Name = name;
        Image = image;
        FlipAlign = flipalign;
        Offset = offset;
    }

    public string Name { get; }

    public Bitmap Image { get; }

    public bool FlipAlign { get; }

    public int Offset { get; }
}
