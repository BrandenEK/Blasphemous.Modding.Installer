using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace BlasModInstaller
{
    public partial class MainForm : Form
    {
        public static string BlasExePath { get; private set; }
        public static string ModdingFolderPath => $"{BlasExePath}\\Modding";

        public static MainForm Instance { get; private set; }

        private Octokit.GitHubClient github;
        private List<Mod> mods;

        public MainForm()
        {
            BlasExePath = "C:\\Users\\Brand\\Documents\\Blasphemous";
            if (Instance == null)
                Instance = this;

            InitializeComponent();
            CreateGithubClient();
            
            LoadModsFromJson();
            LoadModsFromWeb();
        }

        private string SavedModsPath => Environment.CurrentDirectory + "\\downloads\\mods.json";
        private string DownloadsPath => Environment.CurrentDirectory + "\\downloads\\";

        private void LoadModsFromJson()
        {
            if (File.Exists(SavedModsPath))
            {
                string json = File.ReadAllText(SavedModsPath);
                mods = JsonConvert.DeserializeObject<List<Mod>>(json);

                for (int i = 0; i < mods.Count; i++)
                    mods[i].UI.CreateUI(modHolder, Width, i);
            }
            else
            {
                mods = new List<Mod>();
            }
        }

        private async Task LoadModsFromWeb()
        {
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync("https://raw.githubusercontent.com/BrandenEK/Blasphemous-Mod-Installer/main/mods.json");
                Mod[] webMods = JsonConvert.DeserializeObject<Mod[]>(json);

                foreach (Mod webMod in webMods)
                {
                    int modExistsIdx = -1;
                    for (int i = 0; i < mods.Count; i++)
                    {
                        if (mods[i].Name == webMod.Name)
                        {
                            modExistsIdx = i;
                            break;
                        }
                    }
                    
                    Octokit.Release latestRelease = await github.Repository.Release.GetLatest(webMod.GithubAuthor, webMod.GithubRepo);
                    Version webVersion = new Version(latestRelease.TagName);

                    if (modExistsIdx >= 0)
                    {
                        Mod localMod = mods[modExistsIdx];
                        localMod.CopyData(webMod);

                        Version localVersion = new Version(localMod.Version);
                        bool updateAvailable = webVersion.CompareTo(localVersion) > 0;
                        localMod.UI.UpdateUI(updateAvailable);
                    }
                    else
                    {
                        webMod.Version = webVersion.ToString();
                        mods.Add(webMod);
                        webMod.UI.CreateUI(modHolder, Width, mods.Count - 1);
                    }
                }
            }

            SaveMods();
        }

        // After loading more mods from web or updating version, need to save new json
        public void SaveMods()
        {
            File.WriteAllText(SavedModsPath, JsonConvert.SerializeObject(mods));
        }

        private void CreateGithubClient()
        {
            github = new Octokit.GitHubClient(new Octokit.ProductHeaderValue("BlasModInstaller"));

            string tokenPath = Environment.CurrentDirectory + "\\token.txt";
            if (File.Exists(tokenPath))
            {
                string token = File.ReadAllText(tokenPath);
                github.Credentials = new Octokit.Credentials(token);
            }
        }

        private void ClickedDebug(object sender, EventArgs e)
        {
        }

        public async Task Download(Mod mod)
        {
            mod.UI.DisplayDownloadBar();

            Octokit.Release latestRelease = await github.Repository.Release.GetLatest(mod.GithubAuthor, mod.GithubRepo);
            string newVersion = latestRelease.TagName;
            string downloadUrl = latestRelease.Assets[0].BrowserDownloadUrl;
            string downloadPath = $"{DownloadsPath}{mod.Name.Replace(' ', '_')}_{newVersion}.zip";

            using (WebClient client = new WebClient())
            {
                client.DownloadProgressChanged += (object sender, DownloadProgressChangedEventArgs e) => 
                {
                    BeginInvoke(new MethodInvoker(() => mod.UI.UpdateDownloadBar(e.ProgressPercentage)));
                };
                client.DownloadFileCompleted += (object sender, AsyncCompletedEventArgs e) =>
                {
                    BeginInvoke(new MethodInvoker(() => mod.InstallMod(newVersion, downloadPath)));
                };
                client.DownloadFileAsync(new Uri(downloadUrl), downloadPath);
            }
        }
    }
}
