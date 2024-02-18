
namespace Blasphemous.Modding.Installer.Grouping;

internal interface IGrouper
{
    void InstallAll();

    void UninstallAll();

    void EnableAll();

    void DisableAll();

    bool CanInstall { get; }
    bool CanEnable { get; }

    bool CanSortByCreation { get; }
    bool CanSortByDate { get; }
}
