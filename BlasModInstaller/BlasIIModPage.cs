using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace BlasModInstaller.Pages
{
    public class BlasIIModPage : InstallerPage
    {
        protected override string SaveDataPath => Environment.CurrentDirectory + "\\downloads\\BlasphemousIIMods.json";

        public BlasIIModPage(Panel pageSection) : base(pageSection) { }

        protected override void LoadExternalData()
        {
            throw new NotImplementedException();
        }
    }
}
