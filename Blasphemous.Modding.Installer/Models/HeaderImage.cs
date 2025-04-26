
namespace Blasphemous.Modding.Installer.Models;

public class HeaderImage
{
    public HeaderImage(Bitmap image, bool flipalign, int offset)
    {
        Image = image;
        FlipAlign = flipalign;
        Offset = offset;
    }

    public Bitmap Image { get; }

    public bool FlipAlign { get; }

    public int Offset { get; }
}
