
namespace Blasphemous.Modding.Installer.UIComponents;

public class TransparentButton : Button
{
    private bool _isSpecial;
    private bool _isSelected;

    public TransparentButton()
    {
        MouseEnter += ShowSideButtonBorder;
        MouseLeave += HideSideButtonBorder;
        MouseUp += (_, __) => Core.UIHandler.RemoveButtonFocus(null, new EventArgs());
    }

    private void ShowSideButtonBorder(object? _, EventArgs __)
    {
        _isSelected = true;
        UpdateColors();
    }

    private void HideSideButtonBorder(object? _, EventArgs __)
    {
        _isSelected = false;
        UpdateColors();

        Core.UIHandler.RemoveButtonFocus(null, new EventArgs());
    }

    public void SetSpecial(bool isSpecial)
    {
        _isSpecial = isSpecial;
        UpdateColors();
    }

    private void UpdateColors()
    {
        ForeColor = _isSpecial ? Colors.BORDER_SPECIAL : Colors.BORDER_SELECTED;
        FlatAppearance.BorderColor = _isSelected ? ForeColor : Colors.BORDER_UNSELECTED;
    }
}
