using System.Threading.Tasks;

namespace BlasModInstaller.Validation
{
    internal interface IValidator
    {
        Task InstallModdingTools();

        string ExeName { get; }

        bool IsRootFolderValid { get; }

        bool AreModdingToolsInstalled { get; }
    }
}
