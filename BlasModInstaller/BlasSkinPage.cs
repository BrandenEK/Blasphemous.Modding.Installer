using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlasModInstaller.Pages
{
    public class BlasSkinPage : InstallerPage
    {
        protected override string SaveDataPath => Environment.CurrentDirectory + "\\downloads\\BlasphemousSkins.json";

        public BlasSkinPage(Panel pageSection) : base(pageSection) { }

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
