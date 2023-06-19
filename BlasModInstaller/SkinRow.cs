using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace BlasModInstaller
{
    public class SkinRow
    {
        private readonly Skin skin;

        private readonly Panel outerPanel;
        private readonly Panel innerPanel;

        private readonly Label nameText;
        private readonly Label authorText;

        private readonly Button installButton;
        private readonly Button previewIdleButton;
        private readonly Button previewChargedButton;

        private void ClickedInstall(object sender, EventArgs e)
        {

        }

        private void ClickedPreviewIdle(object sender, EventArgs e)
        {
            try { Process.Start(skin.IdlePreviewURL); }
            catch (Exception) { MessageBox.Show("Link does not exist!", "Invalid Link"); }
        }

        private void ClickedPreviewCharged(object sender, EventArgs e)
        {
            try { Process.Start(skin.ChargedPreviewURL); }
            catch (Exception) { MessageBox.Show("Link does not exist!", "Invalid Link"); }
        }

        public SkinRow(Skin skin, Panel parentPanel, int skinIdx)
        {
            this.skin = skin;
            Color backgroundColor = skinIdx % 2 == 0 ? Colors.DARK_GRAY : Colors.LIGHT_GRAY;
            parentPanel.AutoScroll = false;

            outerPanel = new Panel
            {
                Name = skin.name,
                Parent = parentPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                BackColor = Color.Black,
                Location = new Point(0, (Sizes.SKIN_HEIGHT - 2) * skinIdx - 2),
                Size = new Size(parentPanel.Width, Sizes.SKIN_HEIGHT),
            };

            innerPanel = new Panel
            {
                Name = skin.name,
                Parent = outerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                BackColor = backgroundColor,
                Location = new Point(0, 2),
                Size = new Size(parentPanel.Width, Sizes.SKIN_HEIGHT - 4),
            };

            nameText = new Label
            {
                Name = skin.name,
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
                Name = skin.name,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(200, 13),
                Size = new Size(200, 20),
                ForeColor = Color.LightGray,
                TextAlign = ContentAlignment.BottomLeft,
                Font = Fonts.SKIN_AUTHOR,
            };

            installButton = new Button
            {
                Name = skin.name,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(parentPanel.Width - 95, 11),
                Size = new Size(85, 24),
                BackColor = backgroundColor,
                Font = Fonts.BUTTON,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TabStop = false
            };
            installButton.Click += ClickedInstall;
            installButton.MouseUp += MainForm.Instance.RemoveButtonFocus;
            installButton.MouseLeave += MainForm.Instance.RemoveButtonFocus;

            previewIdleButton = new Button
            {
                Name = skin.name,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(parentPanel.Width - 360, 11),
                Size = new Size(110, 24),
                BackColor = Colors.BLUE,
                Font = Fonts.BUTTON,
                Text = "Preview Idle",
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TabStop = false,
            };
            previewIdleButton.FlatAppearance.BorderColor = Color.Black;
            previewIdleButton.Click += ClickedPreviewIdle;
            previewIdleButton.MouseUp += MainForm.Instance.RemoveButtonFocus;
            previewIdleButton.MouseLeave += MainForm.Instance.RemoveButtonFocus;

            previewChargedButton = new Button
            {
                Name = skin.name,
                Parent = innerPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(parentPanel.Width - 230, 11),
                Size = new Size(110, 24),
                BackColor = Colors.BLUE,
                Font = Fonts.BUTTON,
                Text = "Preview Charged",
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TabStop = false,
            };
            previewChargedButton.FlatAppearance.BorderColor = Color.Black;
            previewChargedButton.Click += ClickedPreviewCharged;
            previewChargedButton.MouseUp += MainForm.Instance.RemoveButtonFocus;
            previewChargedButton.MouseLeave += MainForm.Instance.RemoveButtonFocus;

            parentPanel.AutoScroll = true;
            MainForm.Instance.BlasSkinPage.AdjustPageWidth();
            Update();
        }

        public void Update()
        {
            nameText.Text = skin.name;
            nameText.Size = new Size(nameText.PreferredWidth, 30);
            authorText.Text = "by " + skin.author;
            authorText.Location = new Point(nameText.PreferredWidth + 15, authorText.Location.Y);

            // Install button
            bool installed = false;
            installButton.Text = installed ? "Installed" : "Not installed";
            installButton.ForeColor = installed ? Colors.GREEN : Colors.RED;
            installButton.FlatAppearance.BorderColor = installed ? Colors.GREEN : Colors.RED;
        }
    }
}
