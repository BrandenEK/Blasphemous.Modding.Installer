using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Windows.Forms;

namespace BlasModInstaller.Pages
{
    public class BlasModPage : InstallerPage<Mod>
    {
        public BlasModPage(Panel pageSection) : base(pageSection) { }

        protected override string SaveDataPath => Environment.CurrentDirectory + "\\downloads\\BlasphemousMods.json";

        protected override void LoadExternalData()
        {
            LoadLocalData();
            LoadModsFromWeb();
        }

        protected override void LoadLocalData()
        {
            base.LoadLocalData();

            for (int i = 0; i < dataCollection.Count; i++)
            {
                Mod localMod = dataCollection[i];
                localMod.UI.CreateUI(PageSection, i);
                MainForm.Log(localMod.Installed ? localMod.LocalVersion.ToString() : "Not installed");
            }

            MainForm.Log($"Loaded {dataCollection.Count} mods from json");
            SetBackgroundColor();
        }

        private async Task LoadModsFromWeb()
        {
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync("https://raw.githubusercontent.com/BrandenEK/Blasphemous-Mod-Installer/main/mods.json");
                Mod[] webMods = JsonConvert.DeserializeObject<Mod[]>(json);

                foreach (Mod webMod in webMods)
                {
                    Octokit.Release latestRelease = await MainForm.GetLatestRelease(webMod.GithubAuthor, webMod.GithubRepo);
                    Version webVersion = new Version(Mod.CleanSemanticVersion(latestRelease.TagName));
                    string downloadURL = latestRelease.Assets[0].BrowserDownloadUrl;

                    if (ModExists(webMod.Name, out Mod localMod))
                    {
                        localMod.CopyData(webMod);
                        localMod.LatestVersion = webVersion.ToString();
                        localMod.LatestDownloadURL = downloadURL;

                        if (localMod.Installed)
                        {
                            localMod.UpdateAvailable = webVersion.CompareTo(localMod.LocalVersion) > 0;
                        }
                        localMod.UI.UpdateUI();
                    }
                    else
                    {
                        webMod.LatestVersion = webVersion.ToString();
                        webMod.LatestDownloadURL = downloadURL;
                        dataCollection.Add(webMod);
                        webMod.UI.CreateUI(PageSection, dataCollection.Count - 1);
                    }
                }

                MainForm.Log($"Loaded {webMods.Length} mods from the web");
            }

            //MainForm.Log($"Github API calls remaining: {github.GetLastApiInfo().RateLimit.Remaining}");
            SetBackgroundColor();
            SaveLocalData();
        }

        private bool ModExists(string name, out Mod foundMod)
        {
            foundMod = null;
            foreach (Mod mod in dataCollection)
            {
                if (name == mod.Name)
                {
                    foundMod = mod;
                    return true;
                }
            }
            return false;
        }

        private void SetBackgroundColor()
        {
            PageSection.BackColor = dataCollection.Count % 2 == 0 ? Colors.DARK_GRAY : Colors.LIGHT_GRAY;
        }

        public int InstalledModsThatRequireDll(string dllName)
        {
            int count = 0;
            foreach (Mod mod in dataCollection)
            {
                if (mod.RequiresDll(dllName) && mod.Installed)
                    count++;
            }
            return count;
        }
    }
}
