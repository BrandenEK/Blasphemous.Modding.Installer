﻿using System;
using System.Windows.Forms;
using System.Drawing;

namespace BlasModInstaller
{
    public class ModHolder
    {
        private const int MOD_HEIGHT = 80;
        private Mod mod;

        private Panel rowBox;
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
            authorText.Text = "Author: " + mod.Author;
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

        public void CreateUI(Panel modHolder, int formWidth, int modIdx)
        {
            modHolder.AutoScroll = false;
            Color backgroundColor = modIdx % 2 == 0 ? Color.FromArgb(52, 52, 52) : Color.FromArgb(64, 64, 64);

            Panel background = new Panel();
            background.Name = mod.Name;
            background.BackColor = Color.Black;
            background.Parent = modHolder;
            background.Size = new Size(formWidth - 50, MOD_HEIGHT);
            //rowBox.Location = new Point(15, 12 + (12 + MOD_HEIGHT) * modIdx);
            background.Location = new Point(0, MOD_HEIGHT * modIdx);
            background.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            rowBox = new Panel();
            rowBox.Name = mod.Name;
            rowBox.BackColor = backgroundColor;
            rowBox.Parent = background;
            rowBox.Size = new Size(formWidth - 52, MOD_HEIGHT - 2);
            //rowBox.Location = new Point(15, 12 + (12 + MOD_HEIGHT) * modIdx);
            rowBox.Location = new Point(1, 1);
            rowBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            nameText = new Label();
            nameText.Name = mod.Name;
            nameText.Parent = rowBox;
            nameText.ForeColor = Color.LightGray;
            nameText.Size = new Size(400, 15);
            nameText.Location = new Point(10, 8);
            nameText.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            authorText = new Label();
            authorText.Name = mod.Name;
            authorText.Parent = rowBox;
            authorText.ForeColor = Color.LightGray;
            authorText.Size = new Size(400, 15);
            authorText.Location = new Point(10, 25);
            authorText.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            descriptionText = new Label();
            descriptionText.Name = mod.Name;
            descriptionText.Parent = rowBox;
            descriptionText.ForeColor = Color.LightGray;
            descriptionText.Size = new Size(450, 15);
            descriptionText.Location = new Point(10, 42);
            descriptionText.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            linkText = new LinkLabel();
            linkText.Name = mod.Name;
            linkText.Text = "Github Repo";
            linkText.Parent = rowBox;
            linkText.LinkColor = Color.FromArgb(0, 128, 255);
            linkText.Size = new Size(400, 15);
            linkText.Location = new Point(10, 59);
            linkText.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            linkText.LinkClicked += ClickedGithub;

            installButton = new Button();
            installButton.Name = mod.Name;
            installButton.Parent = rowBox;
            installButton.FlatStyle = FlatStyle.Flat;
            installButton.FlatAppearance.BorderColor = Color.White;
            installButton.Size = new Size(70, 30);
            installButton.Location = new Point(rowBox.Width - 155, 23);
            installButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            installButton.Click += ClickedInstall;

            enableButton = new Button();
            enableButton.Name = mod.Name;
            enableButton.Parent = rowBox;
            enableButton.FlatStyle = FlatStyle.Flat;
            enableButton.BackColor = backgroundColor;
            enableButton.Size = new Size(60, 22);
            enableButton.Location = new Point(rowBox.Width - 72, 27);
            enableButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            enableButton.Click += ClickedEnable;

            updateText = new Label();
            updateText.Name = mod.Name;
            updateText.Text = string.Empty;
            updateText.TextAlign = ContentAlignment.TopCenter;
            updateText.Parent = rowBox;
            updateText.ForeColor = Color.LightGray;
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
