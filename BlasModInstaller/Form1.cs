using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
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
        private const int MOD_HEIGHT = 78;
        private const string BLAS_LOCATION = "C:\\Users\\Brand\\Documents\\Blasphemous";

        private Random rng = new Random();
        private Octokit.GitHubClient client;

        public MainForm()
        {
            InitializeComponent();
            CreateGithubClient();
            CreateModSections();
            UpdateModSections();
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

        private string GetEnabledPath(int modIdx) => $"{BLAS_LOCATION}\\Modding\\plugins\\{mods[modIdx].Name}.txt";
        private string GetDisabledPath(int modIdx) => $"{BLAS_LOCATION}\\Modding\\disabled\\{mods[modIdx].Name}.txt";

        private void CreateModSections()
        {
            for (int i = 0; i < mods.Length; i++)
            {
                Panel modSection = new Panel();
                modSection.Name = "mod" + i;
                modSection.BackColor =  i % 2 == 0 ? Color.LightGray : Color.WhiteSmoke;
                modSection.Parent = modHolder;
                modSection.Size = new Size(855, MOD_HEIGHT);
                modSection.Location = new Point(15, 12 + (12 + MOD_HEIGHT) * i);
                modSection.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                Label modName = new Label();
                modName.Name = "name" + i;
                modName.Text = $"{mods[i].Name}  v{mods[i].Version}";
                modName.Parent = modSection;
                modName.Size = new Size(400, 15);
                modName.Location = new Point(10, 8);
                modName.Anchor = AnchorStyles.Top | AnchorStyles.Left;

                Label modAuthor = new Label();
                modAuthor.Name = "author" + i;
                modAuthor.Text = "Author: " + mods[i].Author;
                modAuthor.Parent = modSection;
                modAuthor.Size = new Size(400, 15);
                modAuthor.Location = new Point(10, 25);
                modAuthor.Anchor = AnchorStyles.Top | AnchorStyles.Left;

                Label modDescription = new Label();
                modDescription.Name = "desc" + i;
                modDescription.Text = mods[i].Description;
                modDescription.Parent = modSection;
                modDescription.Size = new Size(450, 15);
                modDescription.Location = new Point(10, 42);
                modDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left;

                LinkLabel modLink = new LinkLabel();
                modLink.Name = "link" + i;
                modLink.Text = "Github Repo";
                modLink.Parent = modSection;
                modLink.Size = new Size(400, 15);
                modLink.Location = new Point(10, 59);
                modLink.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                modLink.LinkClicked += ClickedGithub;

                Button installButton = new Button();
                installButton.Name = "install" + i;
                installButton.Text = "Install";
                installButton.Parent = modSection;
                installButton.Size = new Size(70, 30);
                installButton.Location = new Point(700, 20);
                installButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                installButton.Click += ClickedInstall;
                
                CheckBox enabledCheckbox = new CheckBox();
                enabledCheckbox.Name = "checkbox" + i;
                enabledCheckbox.Text = "Enabled";
                enabledCheckbox.Parent = modSection;
                enabledCheckbox.Size = new Size(70, 40);
                enabledCheckbox.Location = new Point(780, 17);
                enabledCheckbox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                enabledCheckbox.Click += ClickedEnable;

                Label updateText = new Label();
                updateText.Name = "text" + i;
                updateText.Text = string.Empty;
                updateText.TextAlign = ContentAlignment.TopCenter;
                updateText.Parent = modSection;
                updateText.Size = new Size(120, 15);
                updateText.Location = new Point(520, 17);
                updateText.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                Button updateButton = new Button();
                updateButton.Name = "update" + i;
                updateButton.Text = "Download";
                updateButton.BackColor = Color.White;
                updateButton.Parent = modSection;
                updateButton.Size = new Size(72, 25);
                updateButton.Location = new Point(544, 36);
                updateButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                updateButton.Click += ClickedUpdate;

                ProgressBar progressBar = new ProgressBar();
                progressBar.Name = "progress" + i;
                progressBar.Parent = modSection;
                progressBar.Size = new Size(130, 22);
                progressBar.Location = new Point(512, 36);
                progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            }
        }

        private void UpdateModSections()
        {
            for (int i = 0; i < mods.Length; i++)
            {
                if (File.Exists(GetEnabledPath(i)))
                {
                    InstallMod_UI(i);
                    EnableMod_UI(i);
                    CheckForUpdates(i);
                }
                else if (File.Exists(GetDisabledPath(i)))
                {
                    InstallMod_UI(i);
                    DisableMod_UI(i);
                    CheckForUpdates(i);
                }
                else
                {
                    UninstallMod_UI(i);
                }
            }
        }

        private void CreateGithubClient()
        {
            client = new Octokit.GitHubClient(new Octokit.ProductHeaderValue("BlasModInstaller"));

            string tokenPath = Environment.CurrentDirectory + "\\token.txt";
            if (File.Exists(tokenPath))
            {
                string token = File.ReadAllText(tokenPath);
                client.Credentials = new Octokit.Credentials(token);
            }
        }

        private async Task CheckForUpdates(int modIdx)
        {
            //Octokit.Release latestRelease = await client.Repository.Release.GetLatest(mods[modIdx].GithubAuthor, mods[modIdx].GithubRepo);
            //blasLocation.Text += latestRelease.TagName + "  ";
            int rand = rng.Next(0, 4);
            if (rand == 1)
                ShowUpdateAvailable(modIdx);
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

        private void InstallMod(int modIdx)
        {
            // Actually install
            File.WriteAllText(GetEnabledPath(modIdx), "Fake mod");
            // Update UI
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
            if (File.Exists(GetEnabledPath(modIdx)))
                File.Delete(GetEnabledPath(modIdx));
            if (File.Exists(GetDisabledPath(modIdx)))
                File.Delete(GetDisabledPath(modIdx));
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
            string enabled = GetEnabledPath(modIdx);
            string disabled = GetDisabledPath(modIdx);
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
            string enabled = GetEnabledPath(modIdx);
            string disabled = GetDisabledPath(modIdx);
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
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(100);
                    BeginInvoke(new MethodInvoker(() => progressBar.Value = i * 10));
                }
            });
            InstallMod(modIdx);
        }

        private Mod[] mods = new Mod[]
        {
            new Mod("Modding API", "1.3.4", "Damocles", "An API that is required for almost all other mods and allows for custom skins", "BrandenEK", "Blasphemous-Modding-API"),
            new Mod("Randomizer", "1.4.5", "Damocles", "A randomizer mod that can shuffle items, enemies, and doors", "BrandenEK", "Blasphemous-Randomizer"),
            new Mod("Multiworld", "1.0.2", "Damocles", "A multiworld client that allows the randomizer to connect to Archipelago", "BrandenEK", "Blasphemous-Multiworld"),
            new Mod("Multiplayer", "1.0.2", "Damocles", "A multiplayer mod that allows you to play Blasphemous cooperatively or against other people", "BrandenEK", "Blasphemous-Multiplayer"),
            new Mod("Boots of Pleading", "0.1.0", "Damocles", "Adds a new relic called the 'Boots of Pleading' that allows you to survive falling in spikes", "BrandenEK", "Blasphemous-Boots-of-Pleading"),
            new Mod("Double Jump", "0.1.0", "Damocles", "Adds a new relic called the 'Purified Hand of the Nun' that allows you to double jump", "BrandenEK", "Blasphemous-Double-Jump"),
            new Mod("Random Prayer Use", "0.1.0", "Damocles", "Adds a new penitence that randomizes which prayer is used each time you attempt to cast one", "BrandenEK", "Blasphemous-Random-Prayer-Use"),
        };
    }

    public class Mod
    {
        public string Name { get; private set; }
        public string Version { get; private set; }
        public string Author { get; private set; }
        public string Description { get; private set; }
        public string GithubAuthor { get; private set; }
        public string GithubRepo { get; private set; }

        public Mod(string name, string version, string author, string description, string githubAuthor, string githubRepo)
        {
            Name = name;
            Version = version;
            Author = author;
            Description = description;
            GithubAuthor = githubAuthor;
            GithubRepo = githubRepo;
        }

        //public bool Installed { get; set; }
        //public bool Enabled { get; set; }
    }
}
