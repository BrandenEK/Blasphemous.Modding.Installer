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
using BlasModInstaller.Pages;

namespace BlasModInstaller
{
    public partial class MainForm : Form
    {
        private readonly Version CurrentInstallerVersion = new Version(1, 0, 0);

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

        public BlasModPage BlasModPage { get; private set; }
        public BlasSkinPage BlasSkinPage { get; private set; }
        public BlasIIModPage BlasIIModPage { get; private set; }
        //private InstallerPage currentPage;

        private Octokit.GitHubClient github;

        public MainForm()
        {
            Directory.CreateDirectory(DownloadsPath);
            if (Instance == null)
                Instance = this;
            InitializeComponent();
            BlasModPage = new BlasModPage(blas1modSection);
            BlasSkinPage = new BlasSkinPage(blas1skinSection);
            BlasIIModPage = new BlasIIModPage(blas2modSection);

            LoadConfig();
            CreateGithubClient();

            CheckForNewerInstallerRelease();
            OpenSection(SectionType.Blas1Mods);
        }

        public static async Task<Octokit.Release> GetLatestRelease(string owner, string repo)
        {
            return await Instance.github.Repository.Release.GetLatest(owner, repo);
        }

        public static async Task<IReadOnlyList<Octokit.RepositoryContent>> GetRepositoryContents(string owner, string repo)
        {
            return await Instance.github.Repository.Content.GetAllContents(owner, repo);
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

            string downloadPath = $"{DownloadsPath}{mod.Name.Replace(' ', '_')}_{Mod.CleanSemanticVersion(mod.LatestVersion)}.zip";

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
                    BeginInvoke(new MethodInvoker(() => mod.InstallMod(downloadPath)));
            };
            // Start download
            client.DownloadFileAsync(new Uri(mod.LatestDownloadURL), downloadPath);
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

        private async Task CheckForNewerInstallerRelease()
        {
            Octokit.Release latestRelease = await github.Repository.Release.GetLatest("BrandenEK", "Blasphemous-Mod-Installer");
            Version newestVersion = new Version(Mod.CleanSemanticVersion(latestRelease.TagName));

            if (newestVersion > CurrentInstallerVersion)
                warningSection.Visible = true;
        }

        private void ChooseBlasLocation(object sender, EventArgs e)
        {
            if (blasLocDialog.ShowDialog() == DialogResult.OK)
            {
                string rootPath = Path.GetDirectoryName(blasLocDialog.FileName);
                ValidateBlas1Directory(rootPath);
            }
        }


        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            AdjustHolderWidth();
        }


        public void AdjustHolderWidth()
        {
            bool scrollVisible = blas1modSection.VerticalScroll.Visible;
            blas1modSection.Width = mainSection.Width - (scrollVisible ? 17 : 16);
        }

        public void RemoveButtonFocus(object sender, EventArgs e)
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
                titleLabel.Text = "Blasphemous Mods";
                //currentPage = BlasModPage;

                ValidateBlas1Directory(BlasRootFolder);
                blas1skinSection.Visible = false;
                blas2modSection.Visible = false;
            }
            else if (section == SectionType.Blas1Skins)
            {
                titleLabel.Text = "Blasphemous Skins";
                //currentPage = BlasSkinPage;

                BlasSkinPage.LoadData();
                blas1modSection.Visible = false;
                blas1locationSection.Visible = false;
                blas1skinSection.Visible = true;
                blas2modSection.Visible = true;
            }
            else if (section == SectionType.Blas2Mods)
            {
                titleLabel.Text = "Blasphemous II Mods";
                //currentPage = BlasIIModPage;

                blas1modSection.Visible = false;
                blas1locationSection.Visible = false;
                blas1skinSection.Visible = false;
                blas2modSection.Visible = true;
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
                BlasModPage.LoadData();
                return true;
            }

            Log("Blas1 exe path not found!");
            blas1locationSection.Visible = true;
            blas1modSection.Visible = false;
            return false;
        }
    }
}
