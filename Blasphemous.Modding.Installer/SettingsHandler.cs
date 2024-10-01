using Blasphemous.Modding.Installer.Properties;

namespace Blasphemous.Modding.Installer;

internal class SettingsHandler
{
    public OldSettings Properties { get; private set; } = new();

    public void Save()
    {
        Settings.Default.Blas1RootFolder = Properties.Blas1RootFolder;
        Settings.Default.Blas2RootFolder = Properties.Blas2RootFolder;

        //Settings.Default.Blas1ModSort = (byte)Properties.Blas1ModSort;
        //Settings.Default.Blas1SkinSort = (byte)Properties.Blas1SkinSort;
        //Settings.Default.Blas2ModSort = (byte)Properties.Blas2ModSort;

        //Settings.Default.Blas1ModFilter = (byte)Properties.Blas1ModFilter;
        //Settings.Default.Blas1SkinFilter = (byte)Properties.Blas1SkinFilter;
        //Settings.Default.Blas2ModFilter = (byte)Properties.Blas2ModFilter;

        //Settings.Default.Blas1ModTime = Properties.Blas1ModTime;
        //Settings.Default.Blas1SkinTime = Properties.Blas1SkinTime;
        //Settings.Default.Blas2ModTime = Properties.Blas2ModTime;

        //Settings.Default.Blas1LaunchMods = Properties.Blas1Launch.RunModded;
        //Settings.Default.Blas2LaunchMods = Properties.Blas2Launch.RunModded;
        //Settings.Default.Blas1LaunchConsole = Properties.Blas1Launch.RunConsole;
        //Settings.Default.Blas2LaunchConsole = Properties.Blas2Launch.RunConsole;

        Settings.Default.Save();
    }

    public void Load()
    {

        Properties = new OldSettings()
        {
            Blas1RootFolder = Settings.Default.Blas1RootFolder,
            Blas2RootFolder = Settings.Default.Blas2RootFolder,

            //Blas1ModSort = (SortType)Settings.Default.Blas1ModSort,
            //Blas1SkinSort = (SortType)Settings.Default.Blas1SkinSort,
            //Blas2ModSort = (SortType)Settings.Default.Blas2ModSort,

            //Blas1ModFilter = (FilterType)Settings.Default.Blas1ModFilter,
            //Blas1SkinFilter = (FilterType)Settings.Default.Blas1SkinFilter,
            //Blas2ModFilter = (FilterType)Settings.Default.Blas2ModFilter,

            //Blas1ModTime = Settings.Default.Blas1ModTime,
            //Blas1SkinTime = Settings.Default.Blas1SkinTime,
            //Blas2ModTime = Settings.Default.Blas2ModTime,

            //Blas1Launch = new LaunchOptions()
            //{
            //    RunModded = Settings.Default.Blas1LaunchMods,
            //    RunConsole = Settings.Default.Blas1LaunchConsole,
            //},
            //Blas2Launch = new LaunchOptions()
            //{
            //    RunModded = Settings.Default.Blas2LaunchMods,
            //    RunConsole = Settings.Default.Blas2LaunchConsole,
            //},
        };
    }
}
