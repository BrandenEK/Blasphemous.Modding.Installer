using Blasphemous.Modding.Installer.Mods;

namespace Blasphemous.Modding.Installer.PageComponents.Sorters;

internal class ModSorter : ISorter<Mod>
{
    private readonly PageSettings _settings;

    public ModSorter(PageSettings settings)
    {
        _settings = settings;
    }

    public IEnumerable<Mod> Sort(IEnumerable<Mod> list)
    {
        var comparer = new ModPropertyComparer(_settings.Sort);

        return list
            .OrderBy(mod => GetModPriority(mod))
            .ThenBy(mod => mod, comparer)
            .ThenBy(mod => mod.Data.name)
            .ToArray();
    }

    private int GetModPriority(Mod mod)
    {
        if (mod.Data.name == "Modding API")
            return -1;

        if (mod.Data.name.EndsWith("Framework"))
            return 0;

        return 1;
    }

    class ModPropertyComparer : IComparer<Mod>
    {
        private readonly SortType _sort;

        public ModPropertyComparer(SortType sort)
        {
            _sort = sort;
        }

        public int Compare(Mod? x, Mod? y)
        {
            if (x == null || y == null)
                throw new ArgumentException("Null mod when sorting");

            if (x.Equals(y))
                return 0;

            return _sort switch
            {
                SortType.Name => x.Data.name.CompareTo(y.Data.name),
                SortType.Author => x.Data.author.CompareTo(y.Data.author),
                SortType.InitialRelease => x.Data.initialReleaseDate.CompareTo(y.Data.initialReleaseDate),
                SortType.LatestRelease => y.Data.latestReleaseDate.CompareTo(x.Data.latestReleaseDate),
                _ => 0
            };
        }
    }
}
