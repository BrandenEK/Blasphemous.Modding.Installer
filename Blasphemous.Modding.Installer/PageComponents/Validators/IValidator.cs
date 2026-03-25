namespace Blasphemous.Modding.Installer.PageComponents.Validators;

internal interface IValidator
{
    void OnClickToolStatus();
    void OnClickDownloadAfterFailedLaunch();

    string ExeName { get; }
    string DefaultPath { get; }

    bool IsRootFolderValid { get; }
    bool AreModdingToolsInstalled { get; }
    bool AreModdingToolsUpdated { get; }
}
