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
            Application.Run(new MainForm());

            GithubHandler = new GithubHandler(null);
        }

        public static GithubHandler GithubHandler { get; private set; }
    }
}
