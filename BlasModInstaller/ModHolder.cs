using System;
using System.Windows.Forms;
using System.Drawing;

namespace BlasModInstaller
{
    public class ModHolder
    {
        private const int MOD_HEIGHT = 78;
        private Mod mod;

        private Panel rowBox;
        private Label nameText;
        private Label authorText;
        private Label descriptionText;
        private LinkLabel linkText;

        private Button installButton;
        private CheckBox enabledCheckbox;

        private Label updateText;
        private Button updateButton;
        private ProgressBar progressBar;

        private void ClickedInstall(object sender, EventArgs e)
        {
        }

        private void ClickedEnable(object sender, EventArgs e)
        {
        }

        private void ClickedGithub(object sender, LinkLabelLinkClickedEventArgs e) => mod.ClickedGithub();

        private void ClickedUpdate(object sender, EventArgs e)
        {
        }

        public ModHolder(Mod mod)
        {
            this.mod = mod;
        }

        public void UpdateUI(bool updateAvailable)
        {
            // Text
            nameText.Text = $"{mod.Name} v{mod.Version}";
            authorText.Text = "Author: " + mod.Author;
            descriptionText.Text = mod.Description;

            // Install/Enable buttons
            bool modInstalled = mod.Installed;
            bool modEnabled = mod.Enabled;
            installButton.Enabled = true;
            installButton.Text = modInstalled ? "Uninstall" : "Install";
            installButton.BackColor = modInstalled ? Color.Beige : Color.AliceBlue;
            enabledCheckbox.Enabled = modInstalled;
            enabledCheckbox.Checked = modInstalled && modEnabled;

            // Update text/button
            updateText.Visible = updateAvailable;
            updateText.Text = updateAvailable ? "An update is available!" : string.Empty;
            updateButton.Visible = updateAvailable;
            progressBar.Visible = false;
        }

        public void CreateUI(Panel modHolder, int formWidth, int modIdx)
        {
            modHolder.AutoScroll = false;

            rowBox = new Panel();
            rowBox.Name = mod.Name;
            rowBox.BackColor = modIdx % 2 == 0 ? Color.LightGray : Color.WhiteSmoke;
            rowBox.Parent = modHolder;
            rowBox.Size = new Size(formWidth - 50, MOD_HEIGHT);
            rowBox.Location = new Point(15, 12 + (12 + MOD_HEIGHT) * modIdx);
            rowBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            nameText = new Label();
            nameText.Name = mod.Name;
            nameText.Parent = rowBox;
            nameText.Size = new Size(400, 15);
            nameText.Location = new Point(10, 8);
            nameText.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            authorText = new Label();
            authorText.Name = mod.Name;
            authorText.Parent = rowBox;
            authorText.Size = new Size(400, 15);
            authorText.Location = new Point(10, 25);
            authorText.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            descriptionText = new Label();
            descriptionText.Name = mod.Name;
            descriptionText.Parent = rowBox;
            descriptionText.Size = new Size(450, 15);
            descriptionText.Location = new Point(10, 42);
            descriptionText.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            linkText = new LinkLabel();
            linkText.Name = mod.Name;
            linkText.Text = "Github Repo";
            linkText.Parent = rowBox;
            linkText.Size = new Size(400, 15);
            linkText.Location = new Point(10, 59);
            linkText.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            linkText.LinkClicked += ClickedGithub;

            installButton = new Button();
            installButton.Name = mod.Name;
            installButton.Parent = rowBox;
            installButton.Size = new Size(70, 30);
            installButton.Location = new Point(rowBox.Width - 155, 20);
            installButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            installButton.Click += ClickedInstall;

            enabledCheckbox = new CheckBox();
            enabledCheckbox.Name = mod.Name;
            enabledCheckbox.Text = "Enabled";
            enabledCheckbox.Parent = rowBox;
            enabledCheckbox.Size = new Size(70, 40);
            enabledCheckbox.Location = new Point(rowBox.Width - 75, 17);
            enabledCheckbox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            enabledCheckbox.Click += ClickedEnable;

            updateText = new Label();
            updateText.Name = mod.Name;
            updateText.Text = string.Empty;
            updateText.TextAlign = ContentAlignment.TopCenter;
            updateText.Parent = rowBox;
            updateText.Size = new Size(120, 15);
            updateText.Location = new Point(rowBox.Width - 335, 17);
            updateText.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            updateButton = new Button();
            updateButton.Name = mod.Name;
            updateButton.Text = "Download";
            updateButton.BackColor = Color.White;
            updateButton.Parent = rowBox;
            updateButton.Size = new Size(72, 25);
            updateButton.Location = new Point(rowBox.Width - 311, 36);
            updateButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            updateButton.Click += ClickedUpdate;

            progressBar = new ProgressBar();
            progressBar.Name = mod.Name;
            progressBar.Parent = rowBox;
            progressBar.Size = new Size(130, 22);
            progressBar.Location = new Point(rowBox.Width - 343, 36);
            progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            modHolder.AutoScroll = true;
            UpdateUI(false);
        }
    }
}
