
namespace Blasphemous.Modding.Installer.Components;

public class RowColorer
{
    private readonly Control _parent;
    private readonly IEnumerable<Control> _transparentChildren;

    private int _position;
    private bool _isHovering = false;

    public RowColorer(Control parent, IEnumerable<Control> transparentChildren)
    {
        _parent = parent;
        _transparentChildren = transparentChildren;

        AddMouseEnterEvent(parent);
        AddMouseLeaveEvent(parent);
    }

    public void UpdatePosition(int position)
    {
        _position = position;
        RefreshColor();
    }

    private void RefreshColor()
    {
        Color backgroundColor = _isHovering
            ? Colors.SELECTED_GRAY
            : _position % 2 == 0
                ? Colors.DARK_GRAY
                : Colors.LIGHT_GRAY;

        _parent.BackColor = backgroundColor;
        foreach (Control control in _transparentChildren)
            control.BackColor = backgroundColor;
    }

    private void AddMouseEnterEvent(Control control)
    {
        EventHandler action = (_, __) => ChangeHoverStatus(true);

        control.MouseEnter += action;
        foreach (Control child in control.Controls)
            child.MouseEnter += action;
    }

    private void AddMouseLeaveEvent(Control control)
    {
        EventHandler action = (_, __) => ChangeHoverStatus(false);

        control.MouseLeave += action;
        foreach (Control child in control.Controls)
            child.MouseLeave += action;
    }

    private void ChangeHoverStatus(bool status)
    {
        _isHovering = status;
        RefreshColor();
    }
}
