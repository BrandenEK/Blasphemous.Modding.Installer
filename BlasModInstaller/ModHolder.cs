using System;
using System.Windows.Forms;
using System.Drawing;

namespace BlasModInstaller
{
    public class ModHolder
    {
        private const int MOD_HEIGHT = 82;

        private readonly static Font smallFont = new Font("Verdana", 9);
        private readonly static Font largeFont = new Font("Verdana", 16, FontStyle.Bold);
        private readonly static Font installFont = new Font("Trebuchet MS", 8, FontStyle.Bold);
        private readonly static Font enableFont = new Font("Arial", 8, FontStyle.Bold);

        private readonly Mod mod;

        private Panel outerPanel;
        private Panel innerPanel;
        private Label nameText;
        private Label authorText;
        private Label descriptionText;
        private LinkLabel linkText;

        private Button infoButton;
        private Button installButton;
        private Button enableButton;

        private Label updateText;
        private Button updateButton;
        private ProgressBar progressBar;

        private void ClickedInstall(object sender, EventArgs e)
        {
            if (mod.Installed)
            {
                if (MessageBox.Show("Are you sure you want to uninstall this mod?", nameText.Text, MessageBoxButtons.OKCancel) == DialogResult.OK)
                    mod.UninstallMod();
            }
            else if (mod.Downloading)
            {
                mod.CancelDownload();
            }
            else
            {
                mod.StartDownload();
            }
        }

        private void ClickedEnable(object sender, EventArgs e)
        {
            if (mod.Enabled)
                mod.DisableMod();
            else
                mod.EnableMod();

            UpdateUI();
        }

        private void ClickedGithub(object sender, LinkLabelLinkClickedEventArgs e) => mod.OpenGithubLink();

        private void ClickedUpdate(object sender, EventArgs e)
        {
            mod.UninstallMod();
            mod.StartDownload();
        }

        private void ClickedInfo(object sender, EventArgs e)
        {
            mod.OpenGithubLink();
        }

        public ModHolder(Mod mod)
        {
            this.mod = mod;
        }

        public void UpdateUI()
        {
            // Text
            nameText.Text = $"{mod.Name} v{(mod.Installed ? mod.LocalVersion.ToString(3) : mod.LatestVersion)}";
            //authorText.Text = "Author: " + mod.Author;
            descriptionText.Text = mod.Description;

            // Install button
            bool modInstalled = mod.Installed;
            installButton.Text = modInstalled ? "Uninstall" : "Install";
            installButton.BackColor = modInstalled ? Color.FromArgb(255, 102, 102) : Color.FromArgb(102, 255, 102);

            // Enable button
            bool modEnabled = mod.Enabled;
            enableButton.Visible = modInstalled;
            enableButton.Text = modEnabled ? "Enabled" : "Disabled";
            enableButton.ForeColor = modEnabled ? Color.Yellow : Color.White;
            enableButton.FlatAppearance.BorderColor = modEnabled ? Color.Yellow : Color.White;

            // Update text/button
            bool canUpdate = mod.UpdateAvailable;
            updateText.Visible = canUpdate;
            updateText.Text = canUpdate ? "An update is available!" : string.Empty;
            updateButton.Visible = canUpdate;
            progressBar.Visible = false;
        }

        public void DisplayDownloadBar()
        {
            updateText.Visible = true;
            updateText.Text = "Downloading...";
            updateButton.Visible = false;

            installButton.Text = "Cancel";
            installButton.BackColor = Color.FromArgb(255, 178, 102);
            progressBar.Visible = true;
            progressBar.Value = 0;
        }

        public void UpdateDownloadBar(int percentage)
        {
            progressBar.Value = percentage;
        }

        private void UnselectButton(object sender, EventArgs e)
        {
            MainForm.Instance.RemoveButtonFocus();
        }

        public void CreateUI(Panel modHolder, int modIdx)
        {
            modHolder.AutoScroll = false;
            Color backgroundColor = modIdx % 2 == 0 ? MainForm.DARK_GRAY : MainForm.LIGHT_GRAY;

            // Panels

            outerPanel = new Panel
            {
                Name = mod.Name,
                Parent = modHolder,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Location = new Point(0, MOD_HEIGHT * modIdx),
                Size = new Size(modHolder.Width, MOD_HEIGHT + (modIdx == 0 ? 3 : 2)),
                BackColor = Color.Black,
            };

            innerPanel = new Panel
            {
                Name = mod.Name,
                Parent = outerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                Location = new Point(0, modIdx == 0 ? 2 : 1),
                Size = new Size(modHolder.Width, MOD_HEIGHT - 1),
                BackColor = backgroundColor,
            };

            // Left stuff

            nameText = new Label
            {
                Name = mod.Name,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(10, 10),
                Size = new Size(400, 28),
                ForeColor = Color.LightGray,
                Font = largeFont,
            };

            descriptionText = new Label
            {
                Name = mod.Name,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(12, 41),
                Size = new Size(450, 30),
                ForeColor = Color.LightGray,
                Font = smallFont,
            };

            //authorText = new Label
            //{
            //    Name = mod.Name,
            //    Parent = innerPanel,
            //    ForeColor = Color.LightGray,
            //    Size = new Size(400, 15),
            //    Location = new Point(10, 25),
            //    Anchor = AnchorStyles.Top | AnchorStyles.Left
            //};

            //linkText = new LinkLabel
            //{
            //    Name = mod.Name,
            //    Text = "Github Repo",
            //    Parent = innerPanel,
            //    LinkColor = Color.FromArgb(0, 128, 255),
            //    Size = new Size(400, 20),
            //    Location = new Point(12, 40),
            //    Anchor = AnchorStyles.Top | AnchorStyles.Left
            //};
            //linkText.LinkClicked += ClickedGithub;

            // Right stuff

            infoButton = new Button
            {
                Name = mod.Name,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(modHolder.Width - 212, 26),
                Size = new Size(42, 25),
                BackColor = Color.FromArgb(51, 153, 255),
                Font = installFont,
                Text = "INFO",
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TabStop = false,
            };
            infoButton.FlatAppearance.BorderColor = Color.White;
            infoButton.Click += ClickedInfo;
            infoButton.MouseUp += UnselectButton;
            infoButton.MouseLeave += UnselectButton;

            installButton = new Button
            {
                Name = mod.Name,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(modHolder.Width - 158, 23),
                Size = new Size(70, 30),
                Font = installFont,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TabStop = false
            };
            installButton.FlatAppearance.BorderColor = Color.White;
            installButton.Click += ClickedInstall;
            installButton.MouseUp += UnselectButton;
            installButton.MouseLeave += UnselectButton;

            enableButton = new Button
            {
                Name = mod.Name,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(modHolder.Width - 75, 27),
                Size = new Size(64, 22),
                BackColor = backgroundColor,
                Font = enableFont,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TabStop = false
            };
            enableButton.Click += ClickedEnable;
            enableButton.MouseUp += UnselectButton;
            enableButton.MouseLeave += UnselectButton;

            updateText = new Label
            {
                Name = mod.Name,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(modHolder.Width - 400, 17),
                Size = new Size(200, 15),
                ForeColor = Color.LightGray,
                Font = smallFont,
                TextAlign = ContentAlignment.TopCenter,
                Text = string.Empty,
            };

            updateButton = new Button
            {
                Name = mod.Name,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(modHolder.Width - 334, 40),
                Size = new Size(72, 25),
                BackColor = Color.White,
                Font = installFont,
                Text = "Download",
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            updateButton.Click += ClickedUpdate;
            updateButton.MouseUp += UnselectButton;
            updateButton.MouseLeave += UnselectButton;
            updateButton.TabStop = false;

            progressBar = new ProgressBar
            {
                Name = mod.Name,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(modHolder.Width - 366, 36),
                Size = new Size(130, 22),
            };

            modHolder.AutoScroll = true;
            MainForm.Instance.AdjustHolderWidth();
            UpdateUI();
        }
    }
}
