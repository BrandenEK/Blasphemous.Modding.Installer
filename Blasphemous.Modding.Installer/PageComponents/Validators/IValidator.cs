namespace Blasphemous.Modding.Installer.PageComponents.Validators;

internal interface IValidator
{
    Task InstallModdingTools();

    void SetRootPath(string path);

    string ExeName { get; }
    string DefaultPath { get; }

    bool IsRootFolderValid { get; }

    bool AreModdingToolsInstalled { get; }
    bool AreModdingToolsUpdated { get; }
}
