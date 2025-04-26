using Basalt.Framework.Logging;
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

        Logger.Info("Repainting header!");
        HeaderImage header = Core.CurrentPage.Header;

        var g = e.Graphics;
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        g.DrawImage(header.Image, Width - header.Image.Width, header.Offset, header.Image.Width, header.Image.Height);

    }
}
