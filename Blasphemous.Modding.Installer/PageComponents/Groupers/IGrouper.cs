namespace Blasphemous.Modding.Installer.PageComponents.Groupers;

internal interface IGrouper
{
    void InstallAll();

    void UninstallAll();

    void EnableAll();

    void DisableAll();

    void RefreshAll();

    bool CanInstall { get; }
    bool CanEnable { get; }

    bool CanSortByCreation { get; }
    bool CanSortByDate { get; }
}
