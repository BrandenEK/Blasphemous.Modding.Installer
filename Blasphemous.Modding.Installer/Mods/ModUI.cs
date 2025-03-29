using Blasphemous.Modding.Installer.UIComponents;

namespace Blasphemous.Modding.Installer.Mods;

internal class ModUI
{
    private readonly Panel outerPanel;
    private readonly Panel innerPanel;

    private readonly Label nameText;
    private readonly Label authorText;
    private readonly Label descText;

    private readonly Button updateButton;
    private readonly Button readmeButton;
    private readonly Button installButton;
    private readonly Button enableButton;

    private readonly RowColorer _colorer;

    public void UpdateUI(string name, string version, string author, string desc, bool installed, bool enabled, bool canUpdate)
    {
        // Text
        nameText.Text = $"{name} (v{version})";
        nameText.Size = new Size(nameText.PreferredWidth, nameText.Height);
        authorText.Text = "by " + author;
        authorText.Location = new Point(nameText.PreferredWidth + 15, authorText.Location.Y);
        authorText.Size = new Size(authorText.PreferredWidth, authorText.Height);
        descText.Text = desc;
        descText.Size = new Size(descText.PreferredWidth, descText.Height);

        // Install button
        installButton.Text = installed ? "Installed" : "Not installed";
        installButton.ForeColor = installed ? Colors.GREEN : Colors.RED;
        installButton.FlatAppearance.BorderColor = installed ? Colors.GREEN : Colors.RED;

        // Enable button
        enableButton.Visible = installed;
        enableButton.Text = enabled ? "Enabled" : "Disabled";
        enableButton.ForeColor = enabled ? Color.Yellow : Color.White;
        enableButton.FlatAppearance.BorderColor = enabled ? Color.Yellow : Color.White;

        // Update button
        updateButton.Visible = canUpdate;
    }

    public void ShowDownloadingStatus()
    {
        installButton.Text = "Downloading...";
        installButton.ForeColor = Colors.ORANGE;
        installButton.FlatAppearance.BorderColor = Colors.ORANGE;
    }

    public void SetPosition(int modIdx)
    {
        _colorer.UpdatePosition(modIdx);
        outerPanel.Location = new Point(0, (Sizes.MOD_HEIGHT - 2) * modIdx - 2);
    }

    public void SetVisibility(bool visible)
    {
        outerPanel.Visible = visible;
    }

    private bool IsDependencyMod(Mod mod)
    {
        return mod.Data.name == "Modding API" || mod.Data.name.EndsWith("Framework");
    }

    public ModUI(Mod mod)
    {
        Panel parentPanel = Core.UIHandler.DataHolder;
        parentPanel.AutoScroll = false;

        // Panels

        outerPanel = new Panel
        {
            Name = mod.Data.name,
            Parent = parentPanel,
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
            BackColor = Color.Black,
            Size = new Size(parentPanel.Width, Sizes.MOD_HEIGHT),
        };

        innerPanel = new Panel
        {
            Name = mod.Data.name,
            Parent = outerPanel,
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
            Location = new Point(0, 2),
            Size = new Size(parentPanel.Width, Sizes.MOD_HEIGHT - 4),
        };

        // Left side

        nameText = new Label
        {
            Name = mod.Data.name,
            Parent = innerPanel,
            Anchor = AnchorStyles.Top | AnchorStyles.Left,
            Location = new Point(10, 5),
            Size = new Size(100, 35),
            ForeColor = IsDependencyMod(mod) ? Colors.SPECIAL : Color.LightGray,
            TextAlign = ContentAlignment.MiddleLeft,
            Font = Fonts.MOD_NAME,
        };

        authorText = new Label
        {
            Name = mod.Data.name,
            Parent = innerPanel,
            Anchor = AnchorStyles.Top | AnchorStyles.Left,
            Location = new Point(200, 5),
            Size = new Size(100, 35),
            ForeColor = Color.LightGray,
            TextAlign = ContentAlignment.MiddleLeft,
            Font = Fonts.MOD_AUTHOR,
        };

        descText = new Label
        {
            Name = mod.Data.name,
            Parent = innerPanel,
            Anchor = AnchorStyles.Top | AnchorStyles.Left,
            Location = new Point(12, 40),
            Size = new Size(100, 35),
            ForeColor = Color.LightGray, // Color.FromArgb(0xBF, 0xAF, 0x98),
            TextAlign = ContentAlignment.MiddleLeft,
            Font = Fonts.MOD_DESC,
        };

        // Right side

        updateButton = new Button
        {
            Name = mod.Data.name,
            Parent = innerPanel,
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Location = new Point(parentPanel.Width - 330, 10),
            Size = new Size(130, 25),
            BackColor = Color.Black,
            ForeColor = Color.White,
            Font = Fonts.BUTTON,
            Text = "Download update",
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand,
            TabStop = false,
        };
        updateButton.FlatAppearance.BorderColor = Color.White;
        updateButton.Click += mod.ClickedUpdate;
        updateButton.MouseUp += Core.UIHandler.RemoveButtonFocus;
        updateButton.MouseLeave += Core.UIHandler.RemoveButtonFocus;

        readmeButton = new Button
        {
            Name = mod.Data.name,
            Parent = innerPanel,
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Location = new Point(parentPanel.Width - 190, 10),
            Size = new Size(70, 25),
            BackColor = Colors.BLUE,
            Font = Fonts.BUTTON,
            Text = "README",
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand,
            TabStop = false,
        };
        readmeButton.FlatAppearance.BorderColor = Color.Black;
        readmeButton.Click += mod.ClickedReadme;
        readmeButton.MouseUp += Core.UIHandler.RemoveButtonFocus;
        readmeButton.MouseLeave += Core.UIHandler.RemoveButtonFocus;

        installButton = new Button
        {
            Name = mod.Data.name,
            Parent = innerPanel,
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Location = new Point(parentPanel.Width - 110, 10),
            Size = new Size(100, 25),
            Font = Fonts.BUTTON,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand,
            TabStop = false,
        };
        installButton.Click += mod.ClickedInstall;
        installButton.MouseUp += Core.UIHandler.RemoveButtonFocus;
        installButton.MouseLeave += Core.UIHandler.RemoveButtonFocus;

        enableButton = new Button
        {
            Name = mod.Data.name,
            Parent = innerPanel,
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Location = new Point(parentPanel.Width - 110, 45),
            Size = new Size(100, 25),
            Font = Fonts.BUTTON,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand,
            TabStop = false,
        };
        enableButton.Click += mod.ClickedEnable;
        enableButton.MouseUp += Core.UIHandler.RemoveButtonFocus;
        enableButton.MouseLeave += Core.UIHandler.RemoveButtonFocus;

        _colorer = new RowColorer(innerPanel, new Control[] { installButton, enableButton });
        parentPanel.AutoScroll = true;
    }
}
