
namespace Blasphemous.Modding.Installer.PageComponents.Filters;

internal interface IFilter<T>
{
    public IEnumerable<T> Filter(IEnumerable<T> list);
}
