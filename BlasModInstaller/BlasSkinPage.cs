using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace BlasModInstaller.Pages
{
    public class BlasSkinPage : InstallerPage<Skin>
    {
        public BlasSkinPage(Panel pageSection) : base(pageSection) { }

        protected override string SaveDataPath => Environment.CurrentDirectory + "\\downloads\\BlasphemousSkins.json";

        protected override void LoadExternalData()
        {
            LoadSkinsFromWeb();
        }

        private async Task LoadSkinsFromWeb()
        {
            IReadOnlyList<Octokit.RepositoryContent> contents = await MainForm.GetRepositoryContents("BrandenEK", "Blasphemous-Custom-Skins");
            foreach (var item in contents)
            {
                MainForm.Log(item.Name);
            }
        }

    }
}
