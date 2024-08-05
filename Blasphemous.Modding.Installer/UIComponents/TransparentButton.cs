
namespace Blasphemous.Modding.Installer.UIComponents;

public class TransparentButton : Button
{
    public TransparentButton()
    {
        MouseEnter += ShowSideButtonBorder;
        MouseLeave += HideSideButtonBorder;
        MouseUp += (_, __) => Core.UIHandler.RemoveButtonFocus(null, new EventArgs());
    }

    private void ShowSideButtonBorder(object? _, EventArgs __)
    {
        FlatAppearance.BorderColor = Colors.BORDER_SELECTED;
    }

    private void HideSideButtonBorder(object? _, EventArgs __)
    {
        FlatAppearance.BorderColor = Colors.BORDER_UNSELECTED;
        Core.UIHandler.RemoveButtonFocus(null, new EventArgs());
    }
}
