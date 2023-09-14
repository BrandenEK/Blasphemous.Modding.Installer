using System.IO;

namespace BlasModInstaller.Validation
{
    internal class Blas2Validator : IValidator
    {
        private readonly string _exeName = "Blasphemous 2.exe";

        public bool IsRootFolderValid
        {
            get
            {
                string path = Core.SettingsHandler.Config.Blas2RootFolder;
                if (File.Exists(path + "\\" + _exeName))
                {
                    Directory.CreateDirectory(path + "\\Modding\\disabled");
                    return true;
                }

                return false;
            }
        }

        public bool AreModdingToolsInstalled
        {
            get
            {
                return Directory.Exists(Core.SettingsHandler.Config.Blas1RootFolder + "\\MelonLoader");
            }
        }

        public string ExeName => _exeName;
    }
}
