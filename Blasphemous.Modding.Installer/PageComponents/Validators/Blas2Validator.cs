
using Blasphemous.Modding.Installer.PageComponents.Validators.IconLoaders;

namespace Blasphemous.Modding.Installer.PageComponents.Validators;

internal class Blas2Validator : StandardValidator
{
    public Blas2Validator(string cacheDir, string defaultPath, string exeName, string localVersionPath, string remoteDownloadPath, string remoteVersionPath, IIconLoader iconLoader) : base(cacheDir, defaultPath, exeName, localVersionPath, remoteDownloadPath, remoteVersionPath, iconLoader)
    {
    }

    protected override string RootFolder
    {
        get => Core.SettingsHandler.Properties.Blas2RootFolder;
        set => Core.SettingsHandler.Properties.Blas2RootFolder = value;
    }
}
