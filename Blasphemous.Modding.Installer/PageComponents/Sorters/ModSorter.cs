using Blasphemous.Modding.Installer.Mods;
using Blasphemous.Modding.Installer.PageComponents.UIHolders;

namespace Blasphemous.Modding.Installer.PageComponents.Sorters;

internal class ModSorter : ISorter
{
    private readonly IUIHolder _uiHolder;
    private readonly List<Mod> _mods;
    private readonly SectionType _section;

    public ModSorter(IUIHolder uiHolder, List<Mod> mods, SectionType section)
    {
        _uiHolder = uiHolder;
        _mods = mods;
        _section = section;
    }

    public void Sort()
    {
        var comparer = new ModPropertyComparer(Core.SettingsHandler.Properties.GetSort(_section));

        var sorted = _mods
            .OrderBy(mod => GetModPriority(mod))
            .ThenBy(mod => mod, comparer)
            .ThenBy(mod => mod.Data.name)
            .ToArray();

        _mods.Clear();
        _mods.AddRange(sorted);

        _uiHolder.SectionPanel.VerticalScroll.Value = 0;

        int idx = 0;
        foreach (Mod mod in _mods)
        {
            mod.SetUIPosition(idx++);
        }
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
