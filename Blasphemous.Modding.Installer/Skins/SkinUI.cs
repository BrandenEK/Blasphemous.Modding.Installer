using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.Prompts;
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
    private readonly Button previewButton;

    private readonly RowColorer _colorer;

    private readonly Skin _skin;

    public void UpdateUI(string name, string author, bool installed, bool canUpdate)
    {
        // Text
        nameText.Text = name;
        nameText.Size = new Size(nameText.PreferredWidth, nameText.Height);
        authorText.Text = "by " + author;
        authorText.Location = new Point(nameText.PreferredWidth + 15, authorText.Location.Y);
        authorText.Size = new Size(authorText.PreferredWidth, authorText.Height);

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

    public void SetVisibility(bool visible)
    {
        outerPanel.Visible = visible;
    }

    public SkinUI(Skin skin)
    {
        Panel parentPanel = Core.UIHandler.DataHolder;
        parentPanel.AutoScroll = false;
        _skin = skin;

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
            Location = new Point(10, 0),
            Size = new Size(100, 45),
            ForeColor = Color.LightGray,
            TextAlign = ContentAlignment.MiddleLeft,
            Font = Fonts.SKIN_NAME,
        };

        authorText = new Label
        {
            Name = skin.Data.name,
            Parent = innerPanel,
            Anchor = AnchorStyles.Top | AnchorStyles.Left,
            Location = new Point(200, 0),
            Size = new Size(100, 45),
            ForeColor = Color.LightGray,
            TextAlign = ContentAlignment.MiddleLeft,
            Font = Fonts.SKIN_AUTHOR,
        };

        // Right side

        updateButton = new Button
        {
            Name = skin.Data.name,
            Parent = innerPanel,
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Location = new Point(parentPanel.Width - 340, 10),
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
        updateButton.Click += skin.ClickedUpdate;
        updateButton.MouseUp += Core.UIHandler.RemoveButtonFocus;
        updateButton.MouseLeave += Core.UIHandler.RemoveButtonFocus;

        previewButton = new Button
        {
            Name = skin.Data.name,
            Parent = innerPanel,
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Location = new Point(parentPanel.Width - 200, 10),
            Size = new Size(80, 25),
            BackColor = Colors.BLUE,
            Font = Fonts.BUTTON,
            Text = "Preview",
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand,
            TabStop = false,
        };
        previewButton.FlatAppearance.BorderColor = Color.Black;
        previewButton.Click += OnClickPreview;
        previewButton.MouseUp += Core.UIHandler.RemoveButtonFocus;
        previewButton.MouseLeave += Core.UIHandler.RemoveButtonFocus;

        installButton = new Button
        {
            Name = skin.Data.name,
            Parent = innerPanel,
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Location = new Point(parentPanel.Width - 110, 10),
            Size = new Size(100, 25),
            Font = Fonts.BUTTON,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand,
            TabStop = false,
        };
        installButton.Click += skin.ClickedInstall;
        installButton.MouseUp += Core.UIHandler.RemoveButtonFocus;
        installButton.MouseLeave += Core.UIHandler.RemoveButtonFocus;

        _colorer = new RowColorer(innerPanel, new Control[] { installButton });
        parentPanel.AutoScroll = true;
    }

    private void OnClickPreview(object? _, EventArgs __)
    {
        Logger.Info($"Opening skin preview for {_skin.Data.id}");

        var prompt = new SkinPreviewPrompt(_skin, 2);
        prompt.ShowDialog();
    }
}
