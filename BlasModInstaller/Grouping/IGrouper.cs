
namespace BlasModInstaller.Grouping
{
    internal interface IGrouper
    {
        void InstallAll();

        void UninstallAll();

        void EnableAll();

        void DisableAll();
    }
}
