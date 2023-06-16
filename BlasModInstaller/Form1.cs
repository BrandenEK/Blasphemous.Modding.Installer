using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace BlasModInstaller
{
    public partial class MainForm : Form
    {
        public static Color LIGHT_GRAY => Color.FromArgb(64, 64, 64);
        public static Color DARK_GRAY => Color.FromArgb(52, 52, 52);

        private string SavedModsPath => Environment.CurrentDirectory + "\\downloads\\mods.json";
        private string DownloadsPath => Environment.CurrentDirectory + "\\downloads\\";
        private string ConfigPath => Environment.CurrentDirectory + "\\installer.cfg";

        public static MainForm Instance { get; private set; }

        private Config config;
        public static string BlasRootFolder
        {
            get => Instance.config.BlasRootFolder;
            private set
            {
                Instance.config.BlasRootFolder = value;
                Instance.SaveConfig();
            }
        }

        private Octokit.GitHubClient github;

        // Keep this as null until mods are loaded
        private List<Mod> blas1mods;
        private bool checkedWebMods = false;

        public MainForm()
        {
            Directory.CreateDirectory(DownloadsPath);
            if (Instance == null)
                Instance = this;
            LoadConfig();

            InitializeComponent();
            CreateGithubClient();

            OpenSection(SectionType.Blas1Mods);
        }

        private void LoadModsFromJson()
        {
            if (blas1mods != null)
                return;

            if (File.Exists(SavedModsPath))
            {
                string json = File.ReadAllText(SavedModsPath);
                blas1mods = JsonConvert.DeserializeObject<List<Mod>>(json);

                for (int i = 0; i < blas1mods.Count; i++)
                    blas1mods[i].UI.CreateUI(blas1modSection, i);
            }
            else
            {
                blas1mods = new List<Mod>();
            }

            Log($"Loaded {blas1mods.Count} mods from json");
            SetBackgroundColor();
        }

        private async Task LoadModsFromWeb()
        {
            if (checkedWebMods)
                return;

            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync("https://raw.githubusercontent.com/BrandenEK/Blasphemous-Mod-Installer/main/mods.json");
                Mod[] webMods = JsonConvert.DeserializeObject<Mod[]>(json);

                foreach (Mod webMod in webMods)
                {                    
                    Octokit.Release latestRelease = await github.Repository.Release.GetLatest(webMod.GithubAuthor, webMod.GithubRepo);
                    string cleanVersion = latestRelease.TagName.ToLower().Replace("v", "");
                    Version webVersion = new Version(cleanVersion);

                    if (ModExists(webMod.Name, out Mod localMod))
                    {
                        localMod.CopyData(webMod);

                        if (localMod.Installed)
                        {
                            Version localVersion = new Version(localMod.Version);
                            localMod.UpdateAvailable = webVersion.CompareTo(localVersion) > 0;
                        }
                        else
                        {
                            localMod.Version = webVersion.ToString();
                        }
                        localMod.UI.UpdateUI();
                    }
                    else
                    {
                        webMod.Version = webVersion.ToString();
                        blas1mods.Add(webMod);
                        webMod.UI.CreateUI(blas1modSection, blas1mods.Count - 1);
                    }
                }

                Log($"Loaded {webMods.Length} mods from the web");
                checkedWebMods = true;
            }

            Log($"Github API calls remaining: {github.GetLastApiInfo().RateLimit.Remaining}");
            SetBackgroundColor();
            SaveMods();
        }

        // After loading more mods from web or updating version, need to save new json
        public void SaveMods()
        {
            File.WriteAllText(SavedModsPath, JsonConvert.SerializeObject(blas1mods));
        }

        private bool ModExists(string name, out Mod foundMod)
        {
            foundMod = null;
            foreach (Mod mod in blas1mods)
            {
                if (name == mod.Name)
                {
                    foundMod = mod;
                    return true;
                }
            }
            return false;
        }

        private void CreateGithubClient()
        {
            github = new Octokit.GitHubClient(new Octokit.ProductHeaderValue("BlasModInstaller"));
            if (config.GithubToken != null && config.GithubToken != string.Empty)
            {
                github.Credentials = new Octokit.Credentials(config.GithubToken);
            }
        }

        public async Task DownloadMod(Mod mod, WebClient client)
        {
            if (BlasRootFolder == null) return;

            Octokit.Release latestRelease = await github.Repository.Release.GetLatest(mod.GithubAuthor, mod.GithubRepo);
            string newVersion = latestRelease.TagName;
            string downloadUrl = latestRelease.Assets[0].BrowserDownloadUrl;
            string downloadPath = $"{DownloadsPath}{mod.Name.Replace(' ', '_')}_{newVersion}.zip";

            // Update download bar
            client.DownloadProgressChanged += (object sender, DownloadProgressChangedEventArgs e) =>
            {
                BeginInvoke(new MethodInvoker(() => mod.UI.UpdateDownloadBar(e.ProgressPercentage)));
            };
            // Finish download
            client.DownloadFileCompleted += (object sender, AsyncCompletedEventArgs e) =>
            {
                mod.FinishDownload();
                if (!e.Cancelled)
                    BeginInvoke(new MethodInvoker(() => mod.InstallMod(newVersion, downloadPath)));
            };
            // Start download
            client.DownloadFileAsync(new Uri(downloadUrl), downloadPath);
        }

        // Config

        private void LoadConfig()
        {
            if (File.Exists(ConfigPath))
            {
                // Load config
                config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(ConfigPath));
            }
            else
            {
                // Create new config
                config = new Config();
                SaveConfig();
            }
        }

        private void SaveConfig()
        {
            File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(config, Formatting.Indented));
        }

        // ...

        private void ChooseBlasLocation(object sender, EventArgs e)
        {
            if (blasLocDialog.ShowDialog() == DialogResult.OK)
            {
                string rootPath = Path.GetDirectoryName(blasLocDialog.FileName);
                ValidateBlas1Directory(rootPath);
            }
        }

        public int InstalledModsThatRequireDll(string dllName)
        {
            int count = 0;
            foreach (Mod mod in blas1mods)
            {
                if (mod.RequiresDll(dllName) && mod.Installed)
                    count++;
            }
            return count;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (blas1mods != null)
                AdjustHolderWidth();
        }

        private void SetBackgroundColor()
        {
            blas1modSection.BackColor = blas1mods.Count % 2 == 0 ? DARK_GRAY : LIGHT_GRAY;
        }

        public void AdjustHolderWidth()
        {
            bool scrollVisible = blas1modSection.VerticalScroll.Visible;
            blas1modSection.Width = mainSection.Width - (scrollVisible ? 17 : 16);
        }

        public void RemoveButtonFocus()
        {
            titleLabel.Focus();
        }

        public static void Log(string message)
        {
            Instance.debugLog.Text += message + "\r\n";
        }

        private void ShowSideButtonBorder(object sender, EventArgs e)
        {
            (sender as Button).FlatAppearance.BorderColor = Color.White;
        }

        private void HideSideButtonBorder(object sender, EventArgs e)
        {
            (sender as Button).FlatAppearance.BorderColor = Color.Black;
        }

        private void blas1modsBtn_Click(object sender, EventArgs e) => OpenSection(SectionType.Blas1Mods);
        private void blas1skinsBtn_Click(object sender, EventArgs e) => OpenSection(SectionType.Blas1Skins);
        private void blas2modsBtn_Click(object sender, EventArgs e) => OpenSection(SectionType.Blas2Mods);

        private void OpenSection(SectionType section)
        {
            if (section == SectionType.Blas1Mods)
            {
                ValidateBlas1Directory(BlasRootFolder);
                blas2modSection.Visible = false;
            }
            else if (section == SectionType.Blas2Mods)
            {
                blas2modSection.Visible = true;
                blas1locationSection.Visible = false;
                blas1modSection.Visible = false;
            }
        }

        private bool ValidateBlas1Directory(string blasRootPath)
        {
            if (File.Exists(blasRootPath + "\\Blasphemous.exe"))
            {
                Log("Blas1 exe path validated!");
                Directory.CreateDirectory(blasRootPath + "\\Modding\\disabled"); // Only because its not included in the API
                BlasRootFolder = blasRootPath;

                blas1locationSection.Visible = false;
                blas1modSection.Visible = true;
                LoadModsFromJson();
                LoadModsFromWeb();
                return true;
            }

            Log("Blas1 exe path not found!");
            blas1locationSection.Visible = true;
            blas1modSection.Visible = false;
            return false;
        }
    }
}
