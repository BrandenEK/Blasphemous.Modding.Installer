using Blasphemous.Modding.Installer.Models;

namespace Blasphemous.Modding.Installer.UIComponents;

public class HeaderPanel : Panel
{
    public HeaderPanel()
    {
        DoubleBuffered = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        if (!Core.Initialized)
            return;
        
        HeaderImage header = Core.CurrentPage.Header;
        var g = e.Graphics;
        var location = new Point(header.FlipAlign ? Width - header.Image.Width : 0, header.Offset);
        var size = new Size(header.Image.Width, header.Image.Height);

        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        g.DrawImage(header.Image, new Rectangle(location, size));
    }
}
