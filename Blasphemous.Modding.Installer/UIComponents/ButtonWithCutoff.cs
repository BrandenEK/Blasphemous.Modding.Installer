
namespace Blasphemous.Modding.Installer.UIComponents;

public class ButtonWithCutoff : TransparentButton
{
    private bool _expectedVisibility;

    public int VerticalCutoff { get; set; }

    public bool ExpectedVisibility
    {
        get => _expectedVisibility;
        set
        {
            _expectedVisibility = value;
            CheckVisibility();
        }
    }

    public ButtonWithCutoff()
    {
        Move += OnMoved;
        ExpectedVisibility = Visible;
    }

    private void CheckVisibility()
    {
        Visible = _expectedVisibility && Location.Y >= VerticalCutoff;
    }

    private void OnMoved(object? _, EventArgs __)
    {
        CheckVisibility();
    }
}
