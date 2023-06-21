using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
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
                dataCollection[i].CreateUI(PageSection, i);

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
                    Version webVersion = MainForm.CleanSemanticVersion(latestRelease.TagName);
                    string downloadURL = latestRelease.Assets[0].BrowserDownloadUrl;

                    if (DataExists(globalMod, out Mod localMod))
                    {
                        localMod.LatestVersion = webVersion.ToString();
                        localMod.LatestDownloadURL = downloadURL;
                        localMod.UpdateLocalData(globalMod);
                        localMod.UpdateUI();
                    }
                    else
                    {
                        globalMod.LatestVersion = webVersion.ToString();
                        globalMod.LatestDownloadURL = downloadURL;
                        dataCollection.Add(globalMod);
                        globalMod.CreateUI(PageSection, dataCollection.Count - 1);
                    }
                }

                MainForm.Log($"Loaded {globalMods.Length} global mods");
            }

            SaveLocalData();
            SetBackgroundColor();
        }

        protected override void OnDownloadAll()
        {
            MainForm.Log("Downloading all mods");
            foreach (Mod mod in dataCollection)
            {
                if (!mod.Installed)
                {
                    mod.Install();
                }
                else if (mod.UpdateAvailable)
                {
                    mod.Uninstall();
                    mod.Install();
                }
            }
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
