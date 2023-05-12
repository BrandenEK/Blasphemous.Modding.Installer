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
using Ionic.Zip;

namespace BlasModInstaller
{
    public partial class MainForm : Form
    {
        private const int MOD_HEIGHT = 78;

        public static string BlasExePath { get; private set; }

        private Octokit.GitHubClient github;
        private List<Mod> mods;

        public MainForm()
        {
            BlasExePath = "C:\\Users\\Brand\\Documents\\Blasphemous";
            InitializeComponent();
            CreateGithubClient();
            
            LoadModsFromJson();
            LoadModsFromWeb();
        }

        private int GetInstallButtonMod(Button button) => int.Parse(button.Name.Substring(7));
        private int GetEnabledCheckboxMod(CheckBox checkbox) => int.Parse(checkbox.Name.Substring(8));
        private int GetGithubLinkMod(LinkLabel label) => int.Parse(label.Name.Substring(4));
        private int GetUpdateButtonMod(Button button) => int.Parse(button.Name.Substring(6));

        private Button GetInstallButton(int modIdx) => Controls.Find("install" + modIdx, true)[0] as Button;
        private CheckBox GetEnabledCheckbox(int modIdx) => Controls.Find("checkbox" + modIdx, true)[0] as CheckBox;
        private Button GetUpdateButton(int modIdx) => Controls.Find("update" + modIdx, true)[0] as Button;
        private ProgressBar GetProgressBar(int modIdx) => Controls.Find("progress" + modIdx, true)[0] as ProgressBar;
        private Label GetDownloadText(int modIdx) => Controls.Find("text" + modIdx, true)[0] as Label;
        private Label GetNameText(int modIdx) => Controls.Find("name" + modIdx, true)[0] as Label;

        private string SavedModsPath => Environment.CurrentDirectory + "\\downloads\\mods.json";
        private string DownloadsPath => Environment.CurrentDirectory + "\\downloads\\";
        private string ModdingFolder => $"{BlasExePath}\\Modding";

        private void LoadModsFromJson()
        {
            if (File.Exists(SavedModsPath))
            {
                string json = File.ReadAllText(SavedModsPath);
                mods = JsonConvert.DeserializeObject<List<Mod>>(json);

                for (int i = 0; i < mods.Count; i++)
                    CreateModSection(mods[i], i);
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
                        if (webVersion.CompareTo(localVersion) > 0)
                        {
                            ShowUpdateAvailable(modExistsIdx);
                        }
                    }
                    else
                    {
                        webMod.Version = webVersion.ToString();
                        mods.Add(webMod);
                        CreateModSection(webMod, mods.Count - 1);
                    }
                }
            }

            SaveMods();
        }

        // After loading more mods from web or updating version, need to save new json
        private void SaveMods()
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

        private void ClickedInstall(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int modIdx = GetInstallButtonMod(button);
            if (button.Text == "Install")
            {
                Download(modIdx);
            }
            else
            {
                UninstallMod(modIdx);
            }
        }

        private void ClickedEnable(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;
            int modIdx = GetEnabledCheckboxMod(checkbox);
            if (checkbox.Checked)
                EnableMod(modIdx);
            else
                DisableMod(modIdx);
        }

        private void ClickedGithub(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int modIdx = GetGithubLinkMod(sender as LinkLabel);
            try
            {
                Process.Start($"https://github.com/{mods[modIdx].GithubAuthor}/{mods[modIdx].GithubRepo}");
            }
            catch (Exception)
            {
                MessageBox.Show("Link does not exist!", "Invalid Link");
            }
        }

        private void ClickedUpdate(object sender, EventArgs e)
        {
            int modIdx = GetUpdateButtonMod(sender as Button);
            UninstallMod(modIdx);
            Download(modIdx);
        }

        private void ClickedDebug(object sender, EventArgs e)
        {
            for (int i = 0; i < mods.Count; i++)
            {
                bool scrollPresent = modHolder.VerticalScroll.Visible;
                Controls.Find("mod" + i, true)[0].Size = new Size(Width - (scrollPresent ? 67 : 50), MOD_HEIGHT);
            }
        }

        private void InstallMod(int modIdx, string newVersion, string zipPath)
        {
            // Actually install
            string installPath = mods[modIdx].Name == "Modding API" ? BlasExePath : ModdingFolder;
            using (ZipFile zipFile = ZipFile.Read(zipPath))
            {
                foreach (ZipEntry file in zipFile)
                    file.Extract(installPath, ExtractExistingFileAction.OverwriteSilently);
            }
            mods[modIdx].Version = newVersion;
            SaveMods();
            File.Delete(zipPath);
            // Update UI
            GetNameText(modIdx).Text = $"{mods[modIdx].Name} v{newVersion}";
            InstallMod_UI(modIdx);
        }

        private void InstallMod_UI(int modIdx)
        {
            // Set button status
            Button button = GetInstallButton(modIdx);
            button.Text = "Uninstall";
            button.BackColor = Color.Beige;
            button.Enabled = true;
            // Set checkbox status
            CheckBox checkbox = GetEnabledCheckbox(modIdx);
            checkbox.Enabled = true;
            checkbox.Checked = true;
            // Set update status
            HideUpdateAvailable(modIdx);
        }

        private void UninstallMod(int modIdx)
        {
            // Actually uninstall
            if (File.Exists(mods[modIdx].PathToEnabledPlugin))
                File.Delete(mods[modIdx].PathToEnabledPlugin);
            if (File.Exists(mods[modIdx].PathToDisabledPlugin))
                File.Delete(mods[modIdx].PathToDisabledPlugin);
            if (File.Exists(mods[modIdx].PathToConfigFile))
                File.Delete(mods[modIdx].PathToConfigFile);
            if (File.Exists(mods[modIdx].PathToLocalizationFile))
                File.Delete(mods[modIdx].PathToLocalizationFile);
            if (File.Exists(mods[modIdx].PathToLogFile))
                File.Delete(mods[modIdx].PathToLogFile);
            if (Directory.Exists(mods[modIdx].PathToDataFolder))
                Directory.Delete(mods[modIdx].PathToDataFolder, true);
            if (Directory.Exists(mods[modIdx].PathToLevelsFolder))
                Directory.Delete(mods[modIdx].PathToLevelsFolder, true);

            //string[] dlls = mods[modIdx].RequiredDlls;
            //if (dlls != null && dlls.Length > 0)
            //{
            //    foreach (string dll in dlls)
            //    {
            //        blasLocation.Text += dll + " ";
            //    }
            //}

            // Update UI
            UninstallMod_UI(modIdx);
        }

        private void UninstallMod_UI(int modIdx)
        {
            // Set button status
            Button button = GetInstallButton(modIdx);
            button.Text = "Install";
            button.BackColor = Color.AliceBlue;
            button.Enabled = true;
            // Set checkbox status
            CheckBox checkbox = GetEnabledCheckbox(modIdx);
            checkbox.Enabled = false;
            checkbox.Checked = false;
            // Set update status
            HideUpdateAvailable(modIdx);
        }

        private void EnableMod(int modIdx)
        {
            string enabled = mods[modIdx].PathToEnabledPlugin;
            string disabled = mods[modIdx].PathToDisabledPlugin;
            if (File.Exists(disabled))
            {
                if (!File.Exists(enabled))
                    File.Move(disabled, enabled);
                else
                    File.Delete(disabled);
            }
        }

        private void EnableMod_UI(int modIdx)
        {
            CheckBox checkbox = GetEnabledCheckbox(modIdx);
            checkbox.Checked = true;
        }

        private void DisableMod(int modIdx)
        {
            string enabled = mods[modIdx].PathToEnabledPlugin;
            string disabled = mods[modIdx].PathToDisabledPlugin;
            if (File.Exists(enabled))
            {
                if (!File.Exists(disabled))
                    File.Move(enabled, disabled);
                else
                    File.Delete(enabled);
            }
        }

        private void DisableMod_UI(int modIdx)
        {
            CheckBox checkbox = GetEnabledCheckbox(modIdx);
            checkbox.Checked = false;
        }

        private void ShowUpdateAvailable(int modIdx)
        {
            // Set text status
            Label label = GetDownloadText(modIdx);
            label.Visible = true;
            label.Text = "An update is available!";
            // Set button status
            Button button = GetUpdateButton(modIdx);
            button.Visible = true;
            // Set progress bar status
            ProgressBar progressBar = GetProgressBar(modIdx);
            progressBar.Visible = false;
        }

        private void HideUpdateAvailable(int modIdx)
        {
            // Set text status
            Label label = GetDownloadText(modIdx);
            label.Visible = false;
            label.Text = string.Empty;
            // Set button status
            Button button = GetUpdateButton(modIdx);
            button.Visible = false;
            // Set progress bar staus
            ProgressBar progressBar = GetProgressBar(modIdx);
            progressBar.Visible = false;
        }

        private void DisplayDownloadBar(int modIdx)
        {
            // Set text status
            Label label = GetDownloadText(modIdx);
            label.Visible = true;
            label.Text = "Downloading...";
            // Set install button status
            GetInstallButton(modIdx).Enabled = false;
            // Set update button status
            GetUpdateButton(modIdx).Visible = false;
            // Set progress bar status
            ProgressBar progressBar = GetProgressBar(modIdx);
            progressBar.Visible = true;
            progressBar.Value = 0;
        }

        private async Task Download(int modIdx)
        {
            DisplayDownloadBar(modIdx);
            ProgressBar progressBar = GetProgressBar(modIdx);

            Octokit.Release latestRelease = await github.Repository.Release.GetLatest(mods[modIdx].GithubAuthor, mods[modIdx].GithubRepo);
            string newVersion = latestRelease.TagName;
            string downloadUrl = latestRelease.Assets[0].BrowserDownloadUrl;
            string downloadPath = $"{DownloadsPath}{mods[modIdx].Name.Replace(' ', '_')}_{newVersion}.zip";

            using (WebClient client = new WebClient())
            {
                client.DownloadProgressChanged += (object sender, DownloadProgressChangedEventArgs e) => 
                {
                    BeginInvoke(new MethodInvoker(() => progressBar.Value = e.ProgressPercentage));
                };
                client.DownloadFileCompleted += (object sender, AsyncCompletedEventArgs e) =>
                {
                    BeginInvoke(new MethodInvoker(() => InstallMod(modIdx, newVersion, downloadPath)));
                };
                client.DownloadFileAsync(new Uri(downloadUrl), downloadPath);
            }
        }

        private void CreateModSection(Mod mod, int modIdx)
        {
            modHolder.AutoScroll = false;

            Panel modSection = new Panel();
            modSection.Name = "mod" + modIdx;
            modSection.BackColor = modIdx % 2 == 0 ? Color.LightGray : Color.WhiteSmoke;
            modSection.Parent = modHolder;
            modSection.Size = new Size(Width - 50, MOD_HEIGHT);
            modSection.Location = new Point(15, 12 + (12 + MOD_HEIGHT) * modIdx);
            modSection.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            Label modName = new Label();
            modName.Name = "name" + modIdx;
            modName.Text = $"{mod.Name} v{mod.Version}";
            modName.Parent = modSection;
            modName.Size = new Size(400, 15);
            modName.Location = new Point(10, 8);
            modName.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            Label modAuthor = new Label();
            modAuthor.Name = "author" + modIdx;
            modAuthor.Text = "Author: " + mod.Author;
            modAuthor.Parent = modSection;
            modAuthor.Size = new Size(400, 15);
            modAuthor.Location = new Point(10, 25);
            modAuthor.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            Label modDescription = new Label();
            modDescription.Name = "desc" + modIdx;
            modDescription.Text = mod.Description;
            modDescription.Parent = modSection;
            modDescription.Size = new Size(450, 15);
            modDescription.Location = new Point(10, 42);
            modDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            LinkLabel modLink = new LinkLabel();
            modLink.Name = "link" + modIdx;
            modLink.Text = "Github Repo";
            modLink.Parent = modSection;
            modLink.Size = new Size(400, 15);
            modLink.Location = new Point(10, 59);
            modLink.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            modLink.LinkClicked += ClickedGithub;

            Button installButton = new Button();
            installButton.Name = "install" + modIdx;
            installButton.Text = "Install";
            installButton.Parent = modSection;
            installButton.Size = new Size(70, 30);
            installButton.Location = new Point(modSection.Width - 155, 20);
            installButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            installButton.Click += ClickedInstall;

            CheckBox enabledCheckbox = new CheckBox();
            enabledCheckbox.Name = "checkbox" + modIdx;
            enabledCheckbox.Text = "Enabled";
            enabledCheckbox.Parent = modSection;
            enabledCheckbox.Size = new Size(70, 40);
            enabledCheckbox.Location = new Point(modSection.Width - 75, 17);
            enabledCheckbox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            enabledCheckbox.Click += ClickedEnable;

            Label updateText = new Label();
            updateText.Name = "text" + modIdx;
            updateText.Text = string.Empty;
            updateText.TextAlign = ContentAlignment.TopCenter;
            updateText.Parent = modSection;
            updateText.Size = new Size(120, 15);
            updateText.Location = new Point(modSection.Width - 335, 17);
            updateText.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            Button updateButton = new Button();
            updateButton.Name = "update" + modIdx;
            updateButton.Text = "Download";
            updateButton.BackColor = Color.White;
            updateButton.Parent = modSection;
            updateButton.Size = new Size(72, 25);
            updateButton.Location = new Point(modSection.Width - 311, 36);
            updateButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            updateButton.Click += ClickedUpdate;

            ProgressBar progressBar = new ProgressBar();
            progressBar.Name = "progress" + modIdx;
            progressBar.Parent = modSection;
            progressBar.Size = new Size(130, 22);
            progressBar.Location = new Point(modSection.Width - 343, 36);
            progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            modHolder.AutoScroll = true;

            if (File.Exists(mods[modIdx].PathToEnabledPlugin))
            {
                InstallMod_UI(modIdx);
                EnableMod_UI(modIdx);
            }
            else if (File.Exists(mods[modIdx].PathToDisabledPlugin))
            {
                InstallMod_UI(modIdx);
                DisableMod_UI(modIdx);
            }
            else
            {
                UninstallMod_UI(modIdx);
            }
        }
    }
}
