
namespace Blasphemous.Modding.Installer.PageComponents.Listers;

internal interface ILister
{
    public bool ShouldHaveItems { get; set; }

    public void RefreshList();

    public void ClearList();
}
