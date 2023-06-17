using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace BlasModInstaller.Pages
{
    public class BlasIIModPage : InstallerPage<Mod>
    {
        public BlasIIModPage(Panel pageSection) : base(pageSection) { }

        protected override string SaveDataPath => Environment.CurrentDirectory + "\\downloads\\BlasphemousIIMods.json";

        protected override void LoadExternalData()
        {
            throw new NotImplementedException();
        }
    }
}
