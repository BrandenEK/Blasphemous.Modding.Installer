using System;
using System.Windows.Forms;
using System.Drawing;

namespace BlasModInstaller
{
    public class ModHolder
    {
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

        public void CreateUI(Panel modHolder, int modIdx)
        {
            modHolder.AutoScroll = false;
            Color backgroundColor = modIdx % 2 == 0 ? Colors.DARK_GRAY : Colors.LIGHT_GRAY;

            // Panels

            outerPanel = new Panel
            {
                Name = mod.Name,
                Parent = modHolder,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Location = new Point(0, (Sizes.MOD_HEIGHT - 2) * modIdx),
                Size = new Size(modHolder.Width, Sizes.MOD_HEIGHT),
                BackColor = Color.Black,
            };

            innerPanel = new Panel
            {
                Name = mod.Name,
                Parent = outerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                Location = new Point(0, 2),
                Size = new Size(modHolder.Width, Sizes.MOD_HEIGHT - 4),
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
                Font = Fonts.LARGE,
            };
            
            descriptionText = new Label
            {
                Name = mod.Name,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(12, 41),
                Size = new Size(450, 30),
                ForeColor = Color.LightGray,
                Font = Fonts.SMALL,
            };

            // Right stuff

            infoButton = new Button
            {
                Name = mod.Name,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(modHolder.Width - 212, 26),
                Size = new Size(42, 25),
                BackColor = Color.FromArgb(51, 153, 255),
                Font = Fonts.INSTALL,
                Text = "INFO",
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TabStop = false,
            };
            infoButton.FlatAppearance.BorderColor = Color.White;
            infoButton.Click += ClickedInfo;
            infoButton.MouseUp += MainForm.Instance.RemoveButtonFocus;
            infoButton.MouseLeave += MainForm.Instance.RemoveButtonFocus;

            installButton = new Button
            {
                Name = mod.Name,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(modHolder.Width - 158, 23),
                Size = new Size(70, 30),
                Font = Fonts.INSTALL,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TabStop = false
            };
            installButton.FlatAppearance.BorderColor = Color.White;
            installButton.Click += ClickedInstall;
            installButton.MouseUp += MainForm.Instance.RemoveButtonFocus;
            installButton.MouseLeave += MainForm.Instance.RemoveButtonFocus;

            enableButton = new Button
            {
                Name = mod.Name,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(modHolder.Width - 75, 27),
                Size = new Size(64, 22),
                BackColor = backgroundColor,
                Font = Fonts.INSTALL,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TabStop = false
            };
            enableButton.Click += ClickedEnable;
            enableButton.MouseUp += MainForm.Instance.RemoveButtonFocus;
            enableButton.MouseLeave += MainForm.Instance.RemoveButtonFocus;

            updateText = new Label
            {
                Name = mod.Name,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(modHolder.Width - 400, 17),
                Size = new Size(200, 15),
                ForeColor = Color.LightGray,
                Font = Fonts.INSTALL,
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
                Font = Fonts.INSTALL,
                Text = "Download",
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            updateButton.Click += ClickedUpdate;
            updateButton.MouseUp += MainForm.Instance.RemoveButtonFocus;
            updateButton.MouseLeave += MainForm.Instance.RemoveButtonFocus;
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
