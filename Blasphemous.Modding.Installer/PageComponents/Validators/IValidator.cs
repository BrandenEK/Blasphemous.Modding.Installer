namespace Blasphemous.Modding.Installer.PageComponents.Validators;

internal interface IValidator
{
    void OnClickToolStatus();

    string ExeName { get; }
    string DefaultPath { get; }

    bool IsRootFolderValid { get; }
}
