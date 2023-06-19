using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public SkinRow(Skin skin, Panel parentPanel, int skinIdx)
        {
            this.skin = skin;
            Color backgroundColor = skinIdx % 2 == 0 ? Colors.DARK_GRAY : Colors.LIGHT_GRAY;

            outerPanel = new Panel
            {
                Name = skin.name,
                Parent = parentPanel,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                BackColor = Color.Black,
                Location = new Point(0, (Sizes.SKIN_HEIGHT - 2) * skinIdx),
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

            Update();
        }

        public void Update()
        {
            nameText.Text = skin.name;
            nameText.Size = new Size(nameText.PreferredWidth, 30);
            authorText.Text = "by " + skin.author;
            authorText.Location = new Point(nameText.PreferredWidth + 15, authorText.Location.Y);
        }
    }
}
