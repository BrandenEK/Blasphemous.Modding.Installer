using Blasphemous.Modding.Installer.PageComponents.UIHolders;
using Blasphemous.Modding.Installer.Skins;

namespace Blasphemous.Modding.Installer.PageComponents.Sorters;

internal class SkinSorter : ISorter
{
    private readonly IUIHolder _uiHolder;
    private readonly List<Skin> _skins;
    private readonly SectionType _section;

    public SkinSorter(IUIHolder uiHolder, List<Skin> skins, SectionType section)
    {
        _uiHolder = uiHolder;
        _skins = skins;
        _section = section;
    }

    public void Sort()
    {
        var comparer = new SkinPropertyComparer(Core.SettingsHandler.Properties.GetSort(_section));

        var sorted = _skins
            .OrderBy(mod => mod, comparer)
            .ThenBy(mod => mod.Data.name)
            .ToArray();

        _skins.Clear();
        _skins.AddRange(sorted);

        _uiHolder.SectionPanel.VerticalScroll.Value = 0;

        int idx = 0;
        foreach (Skin skin in _skins)
        {
            skin.SetUIPosition(idx++);
        }
    }

    class SkinPropertyComparer : IComparer<Skin>
    {
        private readonly SortType _sort;

        public SkinPropertyComparer(SortType sort)
        {
            _sort = sort;
        }

        public int Compare(Skin? x, Skin? y)
        {
            if (x == null || y == null)
                throw new ArgumentException("Null skin when sorting");

            if (x.Equals(y))
                return 0;

            return _sort switch
            {
                SortType.Name => x.Data.name.CompareTo(y.Data.name),
                SortType.Author => x.Data.author.CompareTo(y.Data.author),
                _ => 0
            };
        }
    }
}
