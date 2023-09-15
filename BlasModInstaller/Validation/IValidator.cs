using System.Threading.Tasks;

namespace BlasModInstaller.Validation
{
    internal interface IValidator
    {
        Task InstallModdingTools();

        void SetRootPath(string path);

        string ExeName { get; }

        bool IsRootFolderValid { get; }

        bool AreModdingToolsInstalled { get; }
    }
}
