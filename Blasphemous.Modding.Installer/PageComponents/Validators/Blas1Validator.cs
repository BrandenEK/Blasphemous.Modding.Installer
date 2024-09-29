
namespace Blasphemous.Modding.Installer.PageComponents.Validators;

internal class Blas1Validator : StandardValidator
{
    public Blas1Validator(string cacheDir, string defaultPath, string exeName, string localVersionPath, string remoteDownloadPath, string remoteVersionPath) : base(cacheDir, defaultPath, exeName, localVersionPath, remoteDownloadPath, remoteVersionPath)
    {
    }

    protected override string RootFolder
    {
        get => Core.SettingsHandler.Properties.Blas1RootFolder;
        set => Core.SettingsHandler.Properties.Blas1RootFolder = value;
    }
}
