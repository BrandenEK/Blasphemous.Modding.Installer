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
        _mods.Sort();

        // Move modding api to the top always
        for (int i = 0; i < _mods.Count; i++)
        {
            if (_mods[i].Data.name == "Modding API")
            {
                Mod api = _mods[i];
                _mods.RemoveAt(i);
                _mods.Insert(0, api);
                break;
            }
        }

        _uiHolder.SectionPanel.VerticalScroll.Value = 0;

        int idx = 0;
        foreach (Mod mod in _mods)
        {
            mod.SetUIPosition(idx++);
        }
    }
}
