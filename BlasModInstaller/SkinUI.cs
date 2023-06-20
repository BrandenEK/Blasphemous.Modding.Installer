using System.Drawing;
using System.Windows.Forms;

namespace BlasModInstaller
{
    public class SkinUI
    {
        private readonly Panel outerPanel;
        private readonly Panel innerPanel;

        private readonly Label nameText;
        private readonly Label authorText;

        private readonly Button updateButton;
        private readonly Button previewIdleButton;
        private readonly Button previewChargedButton;
        private readonly Button installButton;

        public void UpdateUI(string name, string author, bool installed, bool canUpdate)
        {
            // Text
            nameText.Text = name;
            nameText.Size = new Size(nameText.PreferredWidth, 30);
            authorText.Text = "by " + author;
            authorText.Location = new Point(nameText.PreferredWidth + 15, authorText.Location.Y);

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

        public SkinUI(Skin skin, int skinIdx, Panel parentPanel)
        {
            string uiName = skin.name;
            Color backgroundColor = skinIdx % 2 == 0 ? Colors.DARK_GRAY : Colors.LIGHT_GRAY;
            parentPanel.AutoScroll = false;

            // Panels

            outerPanel = new Panel
            {
                Name = uiName,
                Parent = parentPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                BackColor = Color.Black,
                Location = new Point(0, (Sizes.SKIN_HEIGHT - 2) * skinIdx - 2),
                Size = new Size(parentPanel.Width, Sizes.SKIN_HEIGHT),
            };

            innerPanel = new Panel
            {
                Name = uiName,
                Parent = outerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                BackColor = backgroundColor,
                Location = new Point(0, 2),
                Size = new Size(parentPanel.Width, Sizes.SKIN_HEIGHT - 4),
            };

            // Left side

            nameText = new Label
            {
                Name = uiName,
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
                Name = uiName,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(200, 13),
                Size = new Size(200, 20),
                ForeColor = Color.LightGray,
                TextAlign = ContentAlignment.BottomLeft,
                Font = Fonts.SKIN_AUTHOR,
            };

            // Right side

            updateButton = new Button
            {
                Name = uiName,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(parentPanel.Width - 550, 11),
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
            updateButton.MouseUp += MainForm.Instance.RemoveButtonFocus;
            updateButton.MouseLeave += MainForm.Instance.RemoveButtonFocus;

            previewIdleButton = new Button
            {
                Name = uiName,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(parentPanel.Width - 390, 11),
                Size = new Size(110, 24),
                BackColor = Colors.BLUE,
                Font = Fonts.BUTTON,
                Text = "Preview Idle",
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TabStop = false,
            };
            previewIdleButton.FlatAppearance.BorderColor = Color.Black;
            previewIdleButton.Click += skin.ClickedPreviewIdle;
            previewIdleButton.MouseUp += MainForm.Instance.RemoveButtonFocus;
            previewIdleButton.MouseLeave += MainForm.Instance.RemoveButtonFocus;

            previewChargedButton = new Button
            {
                Name = uiName,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(parentPanel.Width - 260, 11),
                Size = new Size(110, 24),
                BackColor = Colors.BLUE,
                Font = Fonts.BUTTON,
                Text = "Preview Charged",
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TabStop = false,
            };
            previewChargedButton.FlatAppearance.BorderColor = Color.Black;
            previewChargedButton.Click += skin.ClickedPreviewCharged;
            previewChargedButton.MouseUp += MainForm.Instance.RemoveButtonFocus;
            previewChargedButton.MouseLeave += MainForm.Instance.RemoveButtonFocus;

            installButton = new Button
            {
                Name = uiName,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(parentPanel.Width - 110, 11),
                Size = new Size(100, 24),
                BackColor = backgroundColor,
                Font = Fonts.BUTTON,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TabStop = false,
            };
            installButton.Click += skin.ClickedInstall;
            installButton.MouseUp += MainForm.Instance.RemoveButtonFocus;
            installButton.MouseLeave += MainForm.Instance.RemoveButtonFocus;

            parentPanel.AutoScroll = true;
        }
    }
}
