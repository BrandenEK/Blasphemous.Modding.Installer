namespace Blasphemous.Modding.Installer.PageComponents.UIHolders;

internal class GenericUIHolder<T> : IUIHolder
{
    private readonly Panel _panel;
    private readonly IEnumerable<T> _data;

    public GenericUIHolder(Panel panel, IEnumerable<T> data)
    {
        _panel = panel;
        _data = data;
    }

    public void SetBackgroundColor()
    {
        _panel.BackColor = _data.Count() % 2 == 0 ? Colors.DARK_GRAY : Colors.LIGHT_GRAY;
    }

    public Panel SectionPanel => _panel;
}
