
namespace Blasphemous.Modding.Installer.PageComponents.Listers;

internal interface ILister
{
    public void RefreshList(bool resetScroll);
    public void RefreshList();

    public void ClearList();
}
