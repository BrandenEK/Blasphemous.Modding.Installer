using System.Drawing;

namespace BlasModInstaller
{
    public static class Colors
    {
        public readonly static Color LIGHT_GRAY = Color.FromArgb(64, 64, 64);
        public readonly static Color DARK_GRAY = Color.FromArgb(52, 52, 52);
    }

    public static class Fonts
    {
        public readonly static Font SMALL = new Font("Verdana", 9);
        public readonly static Font LARGE = new Font("Verdana", 16, FontStyle.Bold);
        public readonly static Font INSTALL = new Font("Trebuchet MS", 8, FontStyle.Bold);
        public readonly static Font ENABLE = new Font("Arial", 8, FontStyle.Bold);

        public readonly static Font SKIN_NAME = new Font("Verdana", 14, FontStyle.Bold);
        public readonly static Font SKIN_AUTHOR = new Font("Verdana", 12, FontStyle.Italic);
    }

    public static class Sizes
    {
        public const int MOD_HEIGHT = 82;
        public const int SKIN_HEIGHT = 50;
    }
}
