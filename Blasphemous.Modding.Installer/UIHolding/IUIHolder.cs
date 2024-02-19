namespace Blasphemous.Modding.Installer.UIHolding;

internal interface IUIHolder
{
    void SetBackgroundColor();

    Panel SectionPanel { get; }
}
