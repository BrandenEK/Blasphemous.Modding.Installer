namespace Blasphemous.Modding.Installer.UIHolding;

internal interface IUIHolder
{
    void AdjustPageWidth();

    void SetBackgroundColor();

    Panel SectionPanel { get; }
}
