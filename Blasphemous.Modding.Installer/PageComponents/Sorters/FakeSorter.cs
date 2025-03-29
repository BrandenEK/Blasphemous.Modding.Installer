
namespace Blasphemous.Modding.Installer.PageComponents.Sorters;

internal class FakeSorter<T> : ISorter<T>
{
    public IEnumerable<T> Sort(IEnumerable<T> list)
    {
        return list;
    }
}
