using Blasphemous.Modding.Installer.Mods;
using Blasphemous.Modding.Installer.UIHolding;

namespace Blasphemous.Modding.Installer.Sorting;

internal class ModSorter : ISorter
{
    private readonly IUIHolder _uiHolder;
    private readonly List<Mod> _mods;

    public ModSorter(IUIHolder uiHolder, List<Mod> mods)
    {
        _uiHolder = uiHolder;
        _mods = mods;
    }

    public void Sort()
    {
        //_mods.Sort();

        // Move modding api to the top always
        //for (int i = 0; i < _mods.Count; i++)
        //{
        //    if (_mods[i].Data.name == "Modding API")
        //    {
        //        Mod api = _mods[i];
        //        _mods.RemoveAt(i);
        //        _mods.Insert(0, api);
        //        break;
        //    }
        //}
        var sorted = _mods
            .OrderBy(mod => GetModPriority(mod))
            .ThenBy(mod => mod, new ModPropertyComparer())
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
}

internal class ModPropertyComparer : IComparer<Mod>
{
    public int Compare(Mod? x, Mod? y)
    {
        if (x == null || y == null)
            throw new ArgumentException("Null mod when sorting");

        if (x.Equals(y))
            return 0;

        return x.ModSort switch
        {
            SortType.Name => x.Data.name.CompareTo(y.Data.name),
            SortType.Author => x.Data.author.CompareTo(y.Data.author),
            SortType.InitialRelease => x.Data.initialReleaseDate.CompareTo(y.Data.initialReleaseDate),
            SortType.LatestRelease => y.Data.latestReleaseDate.CompareTo(x.Data.latestReleaseDate),
            _ => 0
        };
    }
}
