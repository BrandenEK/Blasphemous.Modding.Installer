using Blasphemous.Modding.Installer.Skins;

namespace Blasphemous.Modding.Installer.PageComponents.Sorters;

internal class SkinSorter : ISorter<Skin>
{
    private readonly PageSettings _settings;

    public SkinSorter(PageSettings settings)
    {
        _settings = settings;
    }

    public IEnumerable<Skin> Sort(IEnumerable<Skin> list)
    {
        var comparer = new SkinPropertyComparer(_settings.Sort);

        return list
            .OrderBy(mod => mod, comparer)
            .ThenBy(mod => mod.Data.name)
            .ToArray();
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
