
namespace Blasphemous.Modding.Installer.PageComponents.Filters;

internal class FakeFilter<T> : IFilter<T>
{
    public IEnumerable<T> Filter(IEnumerable<T> list)
    {
        return list;
    }
}
