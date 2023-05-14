using System;
using System.Windows.Forms;
using System.Drawing;

namespace BlasModInstaller
{
    public class ModHolder
    {
        private const int MOD_HEIGHT = 80;

        private static Font smallFont = new Font("Trebuchet MS", 8);
        private static Font largeFont = new Font("Trebuchet MS", 12);
        private static Font installFont = new Font("Trebuchet MS", 8, FontStyle.Bold);
        private static Font enableFont = new Font("Arial", 8, FontStyle.Bold);

        private Mod mod;

        private Panel outerPanel;
        private Panel innerPanel;
        private Label nameText;
        private Label authorText;
        private Label descriptionText;
        private LinkLabel linkText;

        private Button installButton;
        private Button enableButton;

        private Label updateText;
        private Button updateButton;
        private ProgressBar progressBar;

        private void ClickedInstall(object sender, EventArgs e)
        {
            if (mod.Installed)
                mod.UninstallMod();
            else
                MainForm.Instance.Download(mod);
        }

        private void ClickedEnable(object sender, EventArgs e)
        {
            if (mod.Enabled)
                mod.DisableMod();
            else
                mod.EnableMod();

            UpdateUI(false);
        }

        private void ClickedGithub(object sender, LinkLabelLinkClickedEventArgs e) => mod.OpenGithubLink();

        private void ClickedUpdate(object sender, EventArgs e)
        {
            mod.UninstallMod();
            MainForm.Instance.Download(mod);
        }

        public ModHolder(Mod mod)
        {
            this.mod = mod;
        }

        public void UpdateUI(bool updateAvailable)
        {
            // Text
            nameText.Text = $"{mod.Name} v{mod.Version}";
            //authorText.Text = "Author: " + mod.Author;
            descriptionText.Text = mod.Description;

            // Install button
            bool modInstalled = mod.Installed;
            installButton.Enabled = true;
            installButton.Text = modInstalled ? "Uninstall" : "Install";
            installButton.BackColor = modInstalled ? Color.FromArgb(255, 102, 102) : Color.FromArgb(102, 255, 102);

            // Enable button
            bool modEnabled = mod.Enabled;
            enableButton.Visible = modInstalled;
            enableButton.Text = modEnabled ? "Enabled" : "Disabled";
            enableButton.ForeColor = modEnabled ? Color.Yellow : Color.White;
            enableButton.FlatAppearance.BorderColor = modEnabled ? Color.Yellow : Color.White;

            // Update text/button
            updateText.Visible = updateAvailable;
            updateText.Text = updateAvailable ? "An update is available!" : string.Empty;
            updateButton.Visible = updateAvailable;
            progressBar.Visible = false;
        }

        public void DisplayDownloadBar()
        {
            updateText.Visible = true;
            updateText.Text = "Downloading...";
            updateButton.Visible = false;

            installButton.Enabled = false;
            progressBar.Visible = true;
            progressBar.Value = 0;
        }

        public void UpdateDownloadBar(int percentage)
        {
            progressBar.Value = percentage;
        }

        public void CreateUI(Panel modHolder, int modIdx)
        {
            modHolder.AutoScroll = false;
            Color backgroundColor = modIdx % 2 == 0 ? Color.FromArgb(52, 52, 52) : Color.FromArgb(64, 64, 64);

            outerPanel = new Panel();
            outerPanel.Name = mod.Name;
            outerPanel.BackColor = Color.Black;
            outerPanel.Parent = modHolder;
            outerPanel.Size = new Size(modHolder.Width, MOD_HEIGHT);
            //rowBox.Location = new Point(15, 12 + (12 + MOD_HEIGHT) * modIdx);
            outerPanel.Location = new Point(0, MOD_HEIGHT * modIdx);
            outerPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            innerPanel = new Panel();
            innerPanel.Name = mod.Name;
            innerPanel.BackColor = backgroundColor;
            innerPanel.Parent = outerPanel;
            innerPanel.Size = new Size(modHolder.Width - 2, MOD_HEIGHT - 2);
            //rowBox.Location = new Point(15, 12 + (12 + MOD_HEIGHT) * modIdx);
            innerPanel.Location = new Point(1, 1);
            innerPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            nameText = new Label();
            nameText.Name = mod.Name;
            nameText.Parent = innerPanel;
            nameText.Font = largeFont;
            nameText.ForeColor = Color.LightGray;
            nameText.Size = new Size(400, 20);
            nameText.Location = new Point(10, 8);
            nameText.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            //authorText = new Label();
            //authorText.Name = mod.Name;
            //authorText.Parent = innerPanel;
            //authorText.ForeColor = Color.LightGray;
            //authorText.Size = new Size(400, 15);
            //authorText.Location = new Point(10, 25);
            //authorText.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            descriptionText = new Label();
            descriptionText.Name = mod.Name;
            descriptionText.Parent = innerPanel;
            descriptionText.Font = smallFont;
            descriptionText.ForeColor = Color.LightGray;
            descriptionText.Size = new Size(450, 15);
            descriptionText.Location = new Point(10, 42);
            descriptionText.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            //linkText = new LinkLabel();
            //linkText.Name = mod.Name;
            //linkText.Text = "Github Repo";
            //linkText.Parent = innerPanel;
            //linkText.LinkColor = Color.FromArgb(0, 128, 255);
            //linkText.Size = new Size(400, 15);
            //linkText.Location = new Point(10, 59);
            //linkText.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            //linkText.LinkClicked += ClickedGithub;

            installButton = new Button();
            installButton.Name = mod.Name;
            installButton.Parent = innerPanel;
            installButton.FlatStyle = FlatStyle.Flat;
            installButton.Font = installFont;
            installButton.FlatAppearance.BorderColor = Color.White;
            installButton.Size = new Size(70, 30);
            installButton.Location = new Point(innerPanel.Width - 158, 23);
            installButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            installButton.Click += ClickedInstall;

            enableButton = new Button();
            enableButton.Name = mod.Name;
            enableButton.Parent = innerPanel;
            enableButton.FlatStyle = FlatStyle.Flat;
            enableButton.Font = enableFont;
            enableButton.BackColor = backgroundColor;
            enableButton.Size = new Size(64, 22);
            enableButton.Location = new Point(innerPanel.Width - 75, 27);
            enableButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            enableButton.Click += ClickedEnable;

            updateText = new Label();
            updateText.Name = mod.Name;
            updateText.Text = string.Empty;
            updateText.TextAlign = ContentAlignment.TopCenter;
            updateText.Parent = innerPanel;
            updateText.ForeColor = Color.LightGray;
            updateText.Size = new Size(120, 15);
            updateText.Location = new Point(innerPanel.Width - 335, 17);
            updateText.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            updateButton = new Button();
            updateButton.Name = mod.Name;
            updateButton.Text = "Download";
            updateButton.BackColor = Color.White;
            updateButton.Parent = innerPanel;
            updateButton.Size = new Size(72, 25);
            updateButton.Location = new Point(innerPanel.Width - 311, 36);
            updateButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            updateButton.Click += ClickedUpdate;

            progressBar = new ProgressBar();
            progressBar.Name = mod.Name;
            progressBar.Parent = innerPanel;
            progressBar.Size = new Size(130, 22);
            progressBar.Location = new Point(innerPanel.Width - 343, 36);
            progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            modHolder.AutoScroll = true;
            MainForm.Instance.AdjustHolderWidth();
            UpdateUI(false);
        }
    }
}
