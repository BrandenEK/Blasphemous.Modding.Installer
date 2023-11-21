using System.Windows.Forms;

namespace BlasModInstaller.Previewing
{
    internal interface IPreviewer
    {
        void Preview(Panel ui);

        void Clear(Panel ui);
    }
}
