using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlasModInstaller
{
    public partial class MainForm : Form
    {
        private const int MOD_HEIGHT = 78;

        public MainForm()
        {
            InitializeComponent();
            CreateModSections();
            UpdateModSections();
        }

        private void CreateModSections()
        {
            for (int i = 0; i < mods.Length; i++)
            {
                Panel modSection = new Panel();
                modSection.Name = "mod" + i;
                modSection.BackColor = Color.Silver;
                modSection.Parent = modHolder;
                modSection.Size = new Size(855, MOD_HEIGHT);
                modSection.Location = new Point(15, 12 + (12 + MOD_HEIGHT) * i);
                modSection.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                Label modName = new Label();
                modName.Name = "name" + i;
                modName.Text = mods[i].Name;
                modName.Parent = modSection;
                modName.Size = new Size(400, 15);
                modName.Location = new Point(10, 8);
                modName.Anchor = AnchorStyles.Top | AnchorStyles.Left;

                Label modVersion = new Label();
                modVersion.Name = "version" + i;
                modVersion.Text = "Version: " + mods[i].Version;
                modVersion.Parent = modSection;
                modVersion.Size = new Size(400, 15);
                modVersion.Location = new Point(10, 25);
                modVersion.Anchor = AnchorStyles.Top | AnchorStyles.Left;

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
                enabledCheckbox.CheckedChanged += ClickedEnable;

                Label updateText = new Label();
                updateText.Name = "text" + i;
                updateText.Text = "";
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
                UpdateInstalled(i, false);
        }

        private void ClickedInstall(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int modIdx = int.Parse(button.Name.Substring(7));
            bool shouldInstall = !mods[modIdx].Installed;
            if (shouldInstall)
            {
                button.Enabled = false;
                UpdateUpdated(modIdx, false, true);
                Download(modIdx);
            }
            else
            {
                UpdateInstalled(modIdx, false);
            }
        }

        private void ClickedEnable(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;
            int modIdx = int.Parse(checkbox.Name.Substring(8));
            mods[modIdx].Enabled = checkbox.Checked;
        }

        private void ClickedGithub(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int modIdx = int.Parse((sender as LinkLabel).Name.Substring(4));
            try
            {
                Process.Start(mods[modIdx].GithubLink);
            }
            catch (Exception)
            {
                MessageBox.Show("Link does not exist!", "Invalid Link");
            }
        }

        private void ClickedUpdate(object sender, EventArgs e)
        {
            int modIdx = int.Parse((sender as Button).Name.Substring(6));
            UpdateUpdated(modIdx, false, true);
            Download(modIdx);
        }

        private void UpdateInstalled(int modIdx, bool installed)
        {
            mods[modIdx].Installed = installed;
            Button button = Controls.Find("install" + modIdx, true)[0] as Button;
            button.Text = installed ? "Uninstall" : "Install";
            button.BackColor = installed ? Color.AntiqueWhite : Color.AliceBlue;
            button.Enabled = true;
            CheckBox checkbox = Controls.Find("checkbox" + modIdx, true)[0] as CheckBox;
            checkbox.Enabled = installed;
            if (!installed)
            {
                checkbox.Checked = false;
                mods[modIdx].Enabled = false;
            }
            UpdateUpdated(modIdx, installed, false);
        }

        private void InstalledMod(int modIdx)
        {

        }

        private void UninstalledMod(int modIdx)
        {

        }

        //private void UpdateEnabled(int modIdx, bool enabled)
        //{
        //    mods[modIdx].Enabled = enabled;
        //    CheckBox checkbox = Controls.Find("checkbox" + modIdx, true)[0] as CheckBox;
        //    checkbox.Checked = enabled;
        //}

        private void UpdateUpdated(int modIdx, bool needsUpdate, bool download)
        {
            Button button = Controls.Find("update" + modIdx, true)[0] as Button;
            button.Visible = needsUpdate;
            ProgressBar progressBar = Controls.Find("progress" + modIdx, true)[0] as ProgressBar;
            progressBar.Visible = download;
            Label label = Controls.Find("text" + modIdx, true)[0] as Label;
            label.Visible = needsUpdate || download;
            label.Text = needsUpdate ? "An update is available!" : (download ? "Downloading..." : "");
        }

        private async Task Download(int modIdx)
        {
            ProgressBar progressBar = Controls.Find("progress" + modIdx, true)[0] as ProgressBar;
            progressBar.Value = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(100);
                    BeginInvoke(new MethodInvoker(() => progressBar.Value = i * 10));
                }
            });
            UpdateInstalled(modIdx, true);
        }

        private Mod[] mods = new Mod[]
        {
            new Mod("Modding API", "1.3.4", "An API that is required for almost all other mods and allows for custom skins", "https://github.com/BrandenEK/Blasphemous-Modding-API"),
            new Mod("Randomizer", "1.4.5", "A randomizer mod that can shuffle items, enemies, and doors", "https://github.com/BrandenEK/Blasphemous-Randomizer"),
            new Mod("Multiworld", "1.0.2", "A multiworld client that allows the randomizer to connect to Archipelago", "https://github.com/BrandenEK/Blasphemous-Multiworld"),
            new Mod("Multiplayer", "1.0.2", "A multiplayer mod that allows you to play Blasphemous cooperatively or against other people", "https://github.com/BrandenEK/Blasphemous-Multiplayer"),
            new Mod("Boots of Pleading", "0.1.0", "Adds a new relic called the 'Boots of Pleading' that allows you to survive falling in spikes", "https://github.com/BrandenEK/Blasphemous-Boots-of-Pleading"),
            new Mod("Double Jump", "0.1.0", "Adds a new relic called the 'Purified Hand of the Nun' that allows you to double jump", "https://github.com/BrandenEK/Blasphemous-Double-Jump"),
            new Mod("Random Prayer Use", "0.1.0", "Adds a new penitence that randomizes which prayer is used each time you attempt to cast one", "https://github.com/BrandenEK/Blasphemous-Random-Prayer-Use"),
        };
    }

    public class Mod
    {
        public string Name { get; private set; }
        public string Version { get; private set; }
        public string Description { get; private set; }
        public string GithubLink { get; private set; }

        public Mod(string name, string version, string description, string githubLink)
        {
            Name = name;
            Version = version;
            Description = description;
            GithubLink = githubLink;
        }

        public bool Installed { get; set; }
        public bool Enabled { get; set; }
    }
}
