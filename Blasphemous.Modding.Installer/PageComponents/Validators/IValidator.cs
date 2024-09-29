namespace Blasphemous.Modding.Installer.PageComponents.Validators;

internal interface IValidator
{
    void OnClickToolStatus();

    void SetRootPath(string path);

    string ExeName { get; }
    string DefaultPath { get; }

    bool IsRootFolderValid { get; }
}
