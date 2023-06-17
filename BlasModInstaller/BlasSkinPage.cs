using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;

namespace BlasModInstaller.Pages
{
    public class BlasSkinPage : InstallerPage<Skin>
    {
        public BlasSkinPage(Panel pageSection) : base(pageSection) { }

        protected override string SaveDataPath => Environment.CurrentDirectory + "\\downloads\\BlasphemousSkins.json";

        protected override void LoadLocalData()
        {
            base.LoadLocalData();

            MainForm.Log($"Loaded {dataCollection.Count} local skins");
        }

        protected override async Task LoadGlobalData()
        {
            using (HttpClient client = new HttpClient())
            {
                IReadOnlyList<Octokit.RepositoryContent> contents = await MainForm.GetRepositoryContents("BrandenEK", "Blasphemous-Custom-Skins");
                foreach (var item in contents)
                {
                    // Temp - get rid of other files
                    if (item.Name.StartsWith("#") || item.Name.StartsWith("R"))
                        continue;

                    string json = await client.GetStringAsync($"https://raw.githubusercontent.com/BrandenEK/Blasphemous-Custom-Skins/main/{item.Name}/info.txt");
                    Skin globalSkin = JsonConvert.DeserializeObject<Skin>(json);
                    MainForm.Log($"Name: {globalSkin.name}, Author: {globalSkin.author}");

                    if (DataExists(globalSkin, out Skin localSkin))
                    {
                        localSkin.UpdateLocalData(globalSkin);
                    }
                    else
                    {
                        dataCollection.Add(globalSkin);
                    }
                }

                MainForm.Log($"Loaded {contents.Count} global skins");
            }

            SaveLocalData();
        }
    }
}
