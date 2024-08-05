using Blasphemous.Modding.Installer.Extensions;

namespace Blasphemous.Modding.Installer.UIComponents;

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

        parent.AddMouseEnterEvent(() => ChangeHoverStatus(true));
        parent.AddMouseLeaveEvent(() => ChangeHoverStatus(false));
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

    private void ChangeHoverStatus(bool status)
    {
        _isHovering = status;
        RefreshColor();
    }
}
