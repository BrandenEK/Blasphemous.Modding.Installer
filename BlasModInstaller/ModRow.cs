using Ionic.Zip;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlasModInstaller
{
    public class ModRow
    {
        private readonly Mod mod;

        private readonly Panel outerPanel;
        private readonly Panel innerPanel;

        private readonly Label nameText;
        private readonly Label authorText;

        private readonly Button infoButton;
        private readonly Button installButton;
        private readonly Button enableButton;

        private readonly Label updateText;
        private readonly Button updateButton;

        private bool _downloading;

        // Main methods

        public async Task Install()
        {
            if (MainForm.BlasRootFolder == null) return;

            _downloading = true;
            using (WebClient client = new WebClient())
            {
                installButton.Text = "Downloading...";
                installButton.ForeColor = Colors.ORANGE;
                installButton.FlatAppearance.BorderColor = Colors.ORANGE;

                string downloadPath = $"{MainForm.DownloadsPath}{mod.Name.Replace(' ', '_')}.zip";

                await client.DownloadFileTaskAsync(new Uri(mod.LatestDownloadURL), downloadPath);

                string installPath = MainForm.BlasRootFolder;
                if (mod.Name != "Modding API") installPath += "\\Modding";

                using (ZipFile zipFile = ZipFile.Read(downloadPath))
                {
                    foreach (ZipEntry file in zipFile)
                        file.Extract(installPath, ExtractExistingFileAction.OverwriteSilently);
                }

                File.Delete(downloadPath);
            }
            _downloading = false;

            UpdateUI();
        }

        public void Uninstall()
        {
            if (MainForm.BlasRootFolder == null) return;

            // Actually uninstall
            if (File.Exists(mod.PathToEnabledPlugin))
                File.Delete(mod.PathToEnabledPlugin);
            if (File.Exists(mod.PathToDisabledPlugin))
                File.Delete(mod.PathToDisabledPlugin);
            if (File.Exists(mod.PathToConfigFile))
                File.Delete(mod.PathToConfigFile);
            if (File.Exists(mod.PathToKeybindingsFile))
                File.Delete(mod.PathToKeybindingsFile);
            if (File.Exists(mod.PathToLocalizationFile))
                File.Delete(mod.PathToLocalizationFile);
            if (File.Exists(mod.PathToLogFile))
                File.Delete(mod.PathToLogFile);
            if (Directory.Exists(mod.PathToDataFolder))
                Directory.Delete(mod.PathToDataFolder, true);
            if (Directory.Exists(mod.PathToLevelsFolder))
                Directory.Delete(mod.PathToLevelsFolder, true);

            if (mod.RequiredDlls != null && mod.RequiredDlls.Length > 0)
            {
                foreach (string dll in mod.RequiredDlls)
                {
                    if (MainForm.Instance.BlasModPage.InstalledModsThatRequireDll(dll) == 0)
                    {
                        string dllPath = MainForm.BlasRootFolder + "\\Modding\\data\\" + dll;
                        if (File.Exists(dllPath))
                            File.Delete(dllPath);
                    }
                }
            }

            UpdateUI();
        }

        public void Enable()
        {
            if (MainForm.BlasRootFolder == null) return;

            string enabled = mod.PathToEnabledPlugin;
            string disabled = mod.PathToDisabledPlugin;
            if (File.Exists(disabled))
            {
                if (!File.Exists(enabled))
                    File.Move(disabled, enabled);
                else
                    File.Delete(disabled);
            }
        }

        public void Disable()
        {
            if (MainForm.BlasRootFolder == null) return;

            string enabled = mod.PathToEnabledPlugin;
            string disabled = mod.PathToDisabledPlugin;
            if (File.Exists(enabled))
            {
                if (!File.Exists(disabled))
                    File.Move(enabled, disabled);
                else
                    File.Delete(enabled);
            }
        }

        // Click methods

        private void ClickedInstall(object sender, EventArgs e)
        {
            if (_downloading) return;

            if (mod.Installed)
            {
                if (MessageBox.Show("Are you sure you want to uninstall this mod?", nameText.Text, MessageBoxButtons.OKCancel) == DialogResult.OK)
                    Uninstall();
            }
            else
            {
                Install();
            }
        }

        private void ClickedEnable(object sender, EventArgs e)
        {
            if (mod.Enabled)
                Disable();
            else
                Enable();

            UpdateUI();
        }

        private void ClickedUpdate(object sender, EventArgs e)
        {
            Uninstall();
            Install();
        }

        private void ClickedReadme(object sender, EventArgs e)
        {
            try { Process.Start(mod.GithubLink); }
            catch (Exception) { MessageBox.Show("Link does not exist!", "Invalid Link"); }
        }

        // UI methods

        public void UpdateUI()
        {
            // Text
            nameText.Text = $"{mod.Name} (v{(mod.Installed ? mod.LocalVersion.ToString(3) : mod.LatestVersion)})";
            nameText.Size = new Size(nameText.PreferredWidth, 30);
            authorText.Text = "by " + mod.Author;
            authorText.Location = new Point(nameText.PreferredWidth + 15, authorText.Location.Y);

            // Install button
            bool modInstalled = mod.Installed;
            installButton.Text = modInstalled ? "Installed" : "Not installed";
            installButton.ForeColor = modInstalled ? Colors.GREEN : Colors.RED;
            installButton.FlatAppearance.BorderColor = modInstalled ? Colors.GREEN : Colors.RED;

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
        }

        public ModRow(Mod mod, Panel parentPanel, int modIdx)
        {
            this.mod = mod;
            Color backgroundColor = modIdx % 2 == 0 ? Colors.DARK_GRAY : Colors.LIGHT_GRAY;
            parentPanel.AutoScroll = false;

            // Panels

            outerPanel = new Panel
            {
                Name = mod.Name,
                Parent = parentPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                BackColor = Color.Black,
                Location = new Point(0, (Sizes.MOD_HEIGHT - 2) * modIdx - 2),
                Size = new Size(parentPanel.Width, Sizes.MOD_HEIGHT),
            };

            innerPanel = new Panel
            {
                Name = mod.Name,
                Parent = outerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                BackColor = backgroundColor,
                Location = new Point(0, 2),
                Size = new Size(parentPanel.Width, Sizes.MOD_HEIGHT - 4),
            };

            // Left stuff

            nameText = new Label
            {
                Name = mod.Name,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(10, 8),
                Size = new Size(100, 30),
                ForeColor = Color.LightGray,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = Fonts.SKIN_NAME,
            };

            authorText = new Label
            {
                Name = mod.Name,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(200, 13),
                Size = new Size(200, 20),
                ForeColor = Color.LightGray,
                TextAlign = ContentAlignment.BottomLeft,
                Font = Fonts.SKIN_AUTHOR,
            };

            // Right stuff

            infoButton = new Button
            {
                Name = mod.Name,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(parentPanel.Width - 290, 11),
                Size = new Size(70, 24),
                BackColor = Colors.BLUE,
                Font = Fonts.BUTTON,
                Text = "README",
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TabStop = false,
            };
            infoButton.FlatAppearance.BorderColor = Color.Black;
            infoButton.Click += ClickedReadme;
            infoButton.MouseUp += MainForm.Instance.RemoveButtonFocus;
            infoButton.MouseLeave += MainForm.Instance.RemoveButtonFocus;

            installButton = new Button
            {
                Name = mod.Name,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(parentPanel.Width - 190, 11),
                Size = new Size(100, 24),
                BackColor = backgroundColor,
                Font = Fonts.BUTTON,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TabStop = false,
            };
            installButton.Click += ClickedInstall;
            installButton.MouseUp += MainForm.Instance.RemoveButtonFocus;
            installButton.MouseLeave += MainForm.Instance.RemoveButtonFocus;

            enableButton = new Button
            {
                Name = mod.Name,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(parentPanel.Width - 80, 11),
                Size = new Size(70, 24),
                BackColor = backgroundColor,
                Font = Fonts.BUTTON,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TabStop = false,
            };
            enableButton.Click += ClickedEnable;
            enableButton.MouseUp += MainForm.Instance.RemoveButtonFocus;
            enableButton.MouseLeave += MainForm.Instance.RemoveButtonFocus;

            updateText = new Label
            {
                Name = mod.Name,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(parentPanel.Width - 400, 17),
                Size = new Size(200, 15),
                ForeColor = Color.LightGray,
                Font = Fonts.BUTTON,
                TextAlign = ContentAlignment.TopCenter,
                Text = string.Empty,
            };

            updateButton = new Button
            {
                Name = mod.Name,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(parentPanel.Width - 334, 40),
                Size = new Size(72, 25),
                BackColor = Color.White,
                Font = Fonts.BUTTON,
                Text = "Download",
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            updateButton.Click += ClickedUpdate;
            updateButton.MouseUp += MainForm.Instance.RemoveButtonFocus;
            updateButton.MouseLeave += MainForm.Instance.RemoveButtonFocus;
            updateButton.TabStop = false;

            parentPanel.AutoScroll = true;
            MainForm.Instance.BlasModPage.AdjustPageWidth();
            UpdateUI();
        }
    }
}
