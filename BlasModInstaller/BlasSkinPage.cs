using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlasModInstaller.Pages
{
    public class BlasSkinPage : InstallerPage<Skin>
    {
        public BlasSkinPage(Panel pageSection) : base(pageSection) { }

        protected override string SaveDataPath => Environment.CurrentDirectory + "\\downloads\\BlasphemousSkins.json";

        protected override void LoadLocalData()
        {
            base.LoadLocalData();

            for (int i = 0; i < dataCollection.Count; i++)
                dataCollection[i].CreateUI(PageSection, i);

            MainForm.Log($"Loaded {dataCollection.Count} local skins");
            SetBackgroundColor();
        }

        protected override async Task LoadGlobalData()
        {
            using (HttpClient client = new HttpClient())
            {
                IReadOnlyList<Octokit.RepositoryContent> contents = await MainForm.GetRepositoryContents("BrandenEK", "Blasphemous-Custom-Skins");
                foreach (var item in contents)
                {
                    string json = await client.GetStringAsync($"https://raw.githubusercontent.com/BrandenEK/Blasphemous-Custom-Skins/main/{item.Name}/info.txt");
                    Skin globalSkin = JsonConvert.DeserializeObject<Skin>(json);

                    if (DataExists(globalSkin, out Skin localSkin))
                    {
                        localSkin.UpdateLocalData(globalSkin);
                        localSkin.UpdateUI();
                    }
                    else
                    {
                        dataCollection.Add(globalSkin);
                        globalSkin.CreateUI(PageSection, dataCollection.Count - 1);
                    }
                }

                MainForm.Log($"Loaded {contents.Count} global skins");
            }

            SaveLocalData();
            SetBackgroundColor();
        }

        protected override void OnDownloadAll()
        {
            base.OnDownloadAll();
            MainForm.Log("Downloading all skins");
            foreach (Skin skin in dataCollection)
            {
                if (!skin.Installed)
                {
                    skin.Install();
                }
                else if (skin.UpdateAvailable)
                {
                    skin.Uninstall();
                    skin.Install();
                }
            }
        }
    }
}
