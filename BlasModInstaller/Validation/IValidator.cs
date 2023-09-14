
namespace BlasModInstaller.Validation
{
    internal interface IValidator
    {
        string ExeName { get; }

        bool IsRootFolderValid { get; }

        bool AreModdingToolsInstalled { get; }
    }
}
