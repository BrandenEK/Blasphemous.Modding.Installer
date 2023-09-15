using System.Windows.Forms;

namespace BlasModInstaller.UIHolding
{
    internal interface IUIHolder
    {
        void AdjustPageWidth();

        void SetBackgroundColor();

        Panel SectionPanel { get; }
    }
}
