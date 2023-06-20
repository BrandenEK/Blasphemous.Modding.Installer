using System.Drawing;

namespace BlasModInstaller
{
    public static class Colors
    {
        public readonly static Color LIGHT_GRAY = Color.FromArgb(64, 64, 64);
        public readonly static Color DARK_GRAY = Color.FromArgb(52, 52, 52);

        public readonly static Color GREEN = Color.FromArgb(102, 255, 102);
        public readonly static Color RED = Color.FromArgb(255, 102, 102);
        public readonly static Color ORANGE = Color.FromArgb(255, 178, 102);
        public readonly static Color BLUE = Color.FromArgb(51, 153, 255);
    }

    public static class Fonts
    {
        public readonly static Font MOD_NAME = new Font("Verdana", 16, FontStyle.Bold);
        public readonly static Font MOD_DESCRIPTION = new Font("Verdana", 9);

        public readonly static Font SKIN_NAME = new Font("Verdana", 14, FontStyle.Bold);
        public readonly static Font SKIN_AUTHOR = new Font("Verdana", 12, FontStyle.Italic);

        public readonly static Font BUTTON = new Font("Trebuchet MS", 8, FontStyle.Bold);
    }

    public static class Sizes
    {
        public const int MOD_HEIGHT = 80;
        public const int SKIN_HEIGHT = 50;
    }
}
