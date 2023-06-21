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

        public override string Name => "Blasphemous Mods";

        protected override void LoadLocalData()
        {
            base.LoadLocalData();

            for (int i = 0; i < dataCollection.Count; i++)
                dataCollection[i].CreateUI(PageSection, i);

            MainForm.Log($"Loaded {dataCollection.Count} local mods");
            SetBackgroundColor();
            Sort();
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
                    DateTimeOffset latestReleaseDate = latestRelease.CreatedAt;
                    
                    if (DataExists(globalMod, out Mod localMod))
                    {
                        localMod.LatestVersion = webVersion.ToString();
                        localMod.LatestDownloadURL = downloadURL;
                        localMod.LatestReleaseDate = latestReleaseDate;
                        localMod.UpdateLocalData(globalMod);
                        localMod.UpdateUI();
                    }
                    else
                    {
                        globalMod.LatestVersion = webVersion.ToString();
                        globalMod.LatestDownloadURL = downloadURL;
                        globalMod.LatestReleaseDate = latestReleaseDate;
                        dataCollection.Add(globalMod);
                        globalMod.CreateUI(PageSection, dataCollection.Count - 1);
                    }
                }

                MainForm.Log($"Loaded {globalMods.Length} global mods");
            }

            SaveLocalData();
            SetBackgroundColor();
            Sort();
        }

        public override void Sort()
        {
            dataCollection.Sort();

            // Move modding api to the top always
            for (int i = 0; i < dataCollection.Count; i++)
            {
                if (dataCollection[i].Name == "Modding API")
                {
                    Mod api = dataCollection[i];
                    dataCollection.RemoveAt(i);
                    dataCollection.Insert(0, api);
                    break;
                }
            }

            for (int i = 0; i < dataCollection.Count; i++)
                dataCollection[i].SetUIPosition(i);
        }

        protected override void OnInstallAll()
        {
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

        protected override void OnUninstallAll()
        {
            foreach (Mod mod in dataCollection)
            {
                if (mod.Installed)
                {
                    mod.Uninstall();
                }
            }
        }

        protected override void OnEnableAll()
        {
            foreach (Mod mod in dataCollection)
            {
                if (mod.Installed && !mod.Enabled)
                {
                    mod.Enable();
                }
            }
        }

        protected override void OnDisableAll()
        {
            foreach (Mod mod in dataCollection)
            {
                if (mod.Installed && mod.Enabled)
                {
                    mod.Disable();
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
