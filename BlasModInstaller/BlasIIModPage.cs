using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace BlasModInstaller.Pages
{
    public class BlasIIModPage : InstallerPage
    {
        public BlasIIModPage(Panel pageSection) : base(pageSection) { }

        protected override string SaveDataPath => Environment.CurrentDirectory + "\\downloads\\BlasphemousIIMods.json";

        private readonly List<Mod> blas2mods = new List<Mod>();

        public override void SaveLocalData()
        {
            File.WriteAllText(SaveDataPath, JsonConvert.SerializeObject(blas2mods));
        }

        protected override void LoadExternalData()
        {
            throw new NotImplementedException();
        }
    }
}
