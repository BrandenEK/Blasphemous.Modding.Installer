namespace Blasphemous.Modding.Installer.PageComponents.Sorters;

internal interface ISorter<T>
{
    public IEnumerable<T> Sort(IEnumerable<T> list);
}
