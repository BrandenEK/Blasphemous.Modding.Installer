using Blasphemous.Modding.Installer.Extensions;
using Blasphemous.Modding.Installer.UIComponents;

namespace Blasphemous.Modding.Installer.Skins;

internal class SkinUI
{
    private readonly Panel outerPanel;
    private readonly Panel innerPanel;

    private readonly Label nameText;
    private readonly Label authorText;

    private readonly Button updateButton;
    private readonly Button installButton;
    //private readonly Button previewIdleButton;
    //private readonly Button previewChargedButton;

    private readonly RowColorer _colorer;

    public void UpdateUI(string name, string author, bool installed, bool canUpdate)
    {
        // Text
        nameText.Text = name;
        nameText.Size = new Size(nameText.PreferredWidth, 30);
        authorText.Text = "by " + author;
        authorText.Location = new Point(nameText.PreferredWidth + 15, authorText.Location.Y);
        authorText.Size = new Size(authorText.PreferredWidth, 20);

        // Install button
        installButton.Text = installed ? "Installed" : "Not installed";
        installButton.ForeColor = installed ? Colors.GREEN : Colors.RED;
        installButton.FlatAppearance.BorderColor = installed ? Colors.GREEN : Colors.RED;

        // Update button
        updateButton.Visible = canUpdate;
    }

    public void ShowDownloadingStatus()
    {
        installButton.Text = "Downloading...";
        installButton.ForeColor = Colors.ORANGE;
        installButton.FlatAppearance.BorderColor = Colors.ORANGE;
    }

    public void SetPosition(int skinIdx)
    {
        _colorer.UpdatePosition(skinIdx);
        outerPanel.Location = new Point(0, (Sizes.SKIN_HEIGHT - 2) * skinIdx - 2);
    }

    public SkinUI(Skin skin, Panel parentPanel)
    {
        parentPanel.AutoScroll = false;

        // Panels

        outerPanel = new Panel
        {
            Name = skin.Data.name,
            Parent = parentPanel,
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
            BackColor = Color.Black,
            Size = new Size(parentPanel.Width, Sizes.SKIN_HEIGHT),
        };

        innerPanel = new Panel
        {
            Name = skin.Data.name,
            Parent = outerPanel,
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
            Location = new Point(0, 2),
            Size = new Size(parentPanel.Width, Sizes.SKIN_HEIGHT - 4),
        };

        // Left side

        nameText = new Label
        {
            Name = skin.Data.name,
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
            Name = skin.Data.name,
            Parent = innerPanel,
            Anchor = AnchorStyles.Top | AnchorStyles.Left,
            Location = new Point(200, 13),
            Size = new Size(100, 20),
            ForeColor = Color.LightGray,
            TextAlign = ContentAlignment.BottomLeft,
            Font = Fonts.SKIN_AUTHOR,
        };

        // Right side

        updateButton = new Button
        {
            Name = skin.Data.name,
            Parent = innerPanel,
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Location = new Point(parentPanel.Width - 300, 11),
            Size = new Size(130, 24),
            BackColor = Color.Black,
            ForeColor = Color.White,
            Font = Fonts.BUTTON,
            Text = "Download update",
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand,
            TabStop = false,
        };
        updateButton.FlatAppearance.BorderColor = Color.White;
        updateButton.Click += skin.ClickedUpdate;
        updateButton.MouseUp += Core.UIHandler.RemoveButtonFocus;
        updateButton.MouseLeave += Core.UIHandler.RemoveButtonFocus;

        //previewIdleButton = new Button
        //{
        //    Name = skin.Data.name,
        //    Parent = innerPanel,
        //    Anchor = AnchorStyles.Top | AnchorStyles.Right,
        //    Location = new Point(parentPanel.Width - 390, 11),
        //    Size = new Size(110, 24),
        //    BackColor = Colors.BLUE,
        //    Font = Fonts.BUTTON,
        //    Text = "Preview Idle",
        //    FlatStyle = FlatStyle.Flat,
        //    Cursor = Cursors.Hand,
        //    TabStop = false,
        //};
        //previewIdleButton.FlatAppearance.BorderColor = Color.Black;
        //previewIdleButton.Click += skin.ClickedPreviewIdle;
        //previewIdleButton.MouseUp += Core.UIHandler.RemoveButtonFocus;
        //previewIdleButton.MouseLeave += Core.UIHandler.RemoveButtonFocus;

        //previewChargedButton = new Button
        //{
        //    Name = skin.Data.name,
        //    Parent = innerPanel,
        //    Anchor = AnchorStyles.Top | AnchorStyles.Right,
        //    Location = new Point(parentPanel.Width - 260, 11),
        //    Size = new Size(110, 24),
        //    BackColor = Colors.BLUE,
        //    Font = Fonts.BUTTON,
        //    Text = "Preview Charged",
        //    FlatStyle = FlatStyle.Flat,
        //    Cursor = Cursors.Hand,
        //    TabStop = false,
        //};
        //previewChargedButton.FlatAppearance.BorderColor = Color.Black;
        //previewChargedButton.Click += skin.ClickedPreviewCharged;
        //previewChargedButton.MouseUp += Core.UIHandler.RemoveButtonFocus;
        //previewChargedButton.MouseLeave += Core.UIHandler.RemoveButtonFocus;

        installButton = new Button
        {
            Name = skin.Data.name,
            Parent = innerPanel,
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Location = new Point(parentPanel.Width - 110, 11),
            Size = new Size(100, 24),
            Font = Fonts.BUTTON,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand,
            TabStop = false,
        };
        installButton.Click += skin.ClickedInstall;
        installButton.MouseUp += Core.UIHandler.RemoveButtonFocus;
        installButton.MouseLeave += Core.UIHandler.RemoveButtonFocus;

        _colorer = new RowColorer(innerPanel, new Control[] { installButton });
        innerPanel.AddMouseEnterEvent(skin.OnStartHover);
        innerPanel.AddMouseLeaveEvent(skin.OnEndHover);
        parentPanel.AutoScroll = true;
    }
}
