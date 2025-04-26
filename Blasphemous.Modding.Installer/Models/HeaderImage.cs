
namespace Blasphemous.Modding.Installer.Models;

public class HeaderImage
{
    public HeaderImage(Bitmap image, int offset)
    {
        Image = image;
        Offset = offset;
    }

    public Bitmap Image { get; }

    public int Offset { get; }
}
