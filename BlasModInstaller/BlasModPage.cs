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

        protected override void LoadLocalData()
        {
            base.LoadLocalData();

            for (int i = 0; i < dataCollection.Count; i++)
            {
                Mod localMod = dataCollection[i];
                localMod.UI.CreateUI(PageSection, i);
                MainForm.Log(localMod.Installed ? localMod.LocalVersion.ToString() : "Not installed");
            }

            MainForm.Log($"Loaded {dataCollection.Count} local mods");
            SetBackgroundColor();
        }

        protected override async Task LoadGlobalData()
        {
            await base.LoadGlobalData();

            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync("https://raw.githubusercontent.com/BrandenEK/Blasphemous-Mod-Installer/main/mods.json");
                Mod[] globalMods = JsonConvert.DeserializeObject<Mod[]>(json);

                foreach (Mod globalMod in globalMods)
                {
                    Octokit.Release latestRelease = await MainForm.GetLatestRelease(globalMod.GithubAuthor, globalMod.GithubRepo);
                    Version webVersion = new Version(Mod.CleanSemanticVersion(latestRelease.TagName));
                    string downloadURL = latestRelease.Assets[0].BrowserDownloadUrl;

                    if (DataExists(globalMod, out Mod localMod))
                    {
                        localMod.UpdateLocalData(globalMod);
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
                        globalMod.LatestVersion = webVersion.ToString();
                        globalMod.LatestDownloadURL = downloadURL;
                        dataCollection.Add(globalMod);
                        globalMod.UI.CreateUI(PageSection, dataCollection.Count - 1);
                    }
                }

                MainForm.Log($"Loaded {globalMods.Length} global mods");
            }

            //MainForm.Log($"Github API calls remaining: {github.GetLastApiInfo().RateLimit.Remaining}");
            SetBackgroundColor();
            SaveLocalData();
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
