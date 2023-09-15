using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BlasModInstaller.UIHolding
{
    internal class GenericUIHolder<T> : IUIHolder
    {
        private readonly Panel _panel;
        private readonly IEnumerable<T> _data;

        public GenericUIHolder(Panel panel, IEnumerable<T> data)
        {
            _panel = panel;
            _data = data;
        }

        public void AdjustPageWidth()
        {
            bool scrollVisible = _panel.VerticalScroll.Visible;
            _panel.Width = Core.UIHandler.MainSectionWidth + (scrollVisible ? 2 : -15);
        }

        public void SetBackgroundColor()
        {
            _panel.BackColor = _data.Count() % 2 == 0 ? Colors.DARK_GRAY : Colors.LIGHT_GRAY;
        }

        public Panel SectionPanel => _panel;
    }
}
