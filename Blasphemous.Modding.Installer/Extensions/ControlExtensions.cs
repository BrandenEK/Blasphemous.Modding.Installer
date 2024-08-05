
namespace Blasphemous.Modding.Installer.Extensions;

public static class ControlExtensions
{
    public static void AddMouseEnterEvent(this Control control, Action callback)
    {
        void OnMouseEnter(object? _, EventArgs __) => callback();

        control.MouseEnter += OnMouseEnter;
        foreach (Control child in control.Controls)
            child.MouseEnter += OnMouseEnter;
    }

    public static void AddMouseLeaveEvent(this Control control, Action callback)
    {
        void OnMouseLeave(object? _, EventArgs __) => callback();

        control.MouseLeave += OnMouseLeave;
        foreach (Control child in control.Controls)
            child.MouseLeave += OnMouseLeave;
    }
}
