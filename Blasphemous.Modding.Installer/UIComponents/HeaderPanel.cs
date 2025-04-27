using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.Models;

namespace Blasphemous.Modding.Installer.UIComponents;

public class HeaderPanel : Panel
{
    private HeaderImage? _header;

    public HeaderPanel()
    {
        DoubleBuffered = true;
    }

    public void ChangeHeader(HeaderImage header)
    {
        Logger.Info($"Changing header to {header.Name}");
        _header = header;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        if (_header is null)
            return;
        
        var g = e.Graphics;
        var location = new Point(_header.FlipAlign ? Width - _header.Image.Width : 0, _header.Offset);
        var size = new Size(_header.Image.Width, _header.Image.Height);

        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        g.DrawImage(_header.Image, new Rectangle(location, size));
    }
}
