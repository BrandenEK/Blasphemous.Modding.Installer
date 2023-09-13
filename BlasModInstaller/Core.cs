using System;
using System.Windows.Forms;

namespace BlasModInstaller
{
    static class Core
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            UIHandler = new UIHandler();
            SettingsHandler = new SettingsHandler(Environment.CurrentDirectory + "\\installer.cfg");
            GithubHandler = new GithubHandler(SettingsHandler.Config.GithubToken);

            Application.Run(UIHandler);
        }

        public static UIHandler UIHandler { get; private set; }
        public static SettingsHandler SettingsHandler { get; private set; }
        public static GithubHandler GithubHandler { get; private set; }

        // Don't forget to increase this when releasing an update!  Have to do it here
        // because I'm not sure how to increase file version for windows forms
        public static Version CurrentInstallerVersion => new Version(1, 0, 1);
    }
}
