using BlasModInstaller.Mods;
using BlasModInstaller.Properties;
using BlasModInstaller.Skins;
using System;
using System.Collections.Generic;
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

            var blas1mods = new ModPage(
                "Blasphemous Mods",
                Resources.background1,
                UIHandler.GetUIElementByType(SectionType.Blas1Mods),
                Environment.CurrentDirectory + "\\downloads\\BlasphemousMods.json",
                "https://raw.githubusercontent.com/BrandenEK/Blasphemous-Mod-Installer/main/BlasphemousMods.json");

            var blas1skins = new SkinPage(
                "Blasphemous Skins",
                Resources.background1,
                UIHandler.GetUIElementByType(SectionType.Blas1Skins),
                Environment.CurrentDirectory + "\\downloads\\BlasphemousSkins.json",
                string.Empty);

            var blas2mods = new ModPage(
                "Blasphemous II Mods",
                Resources.background2,
                UIHandler.GetUIElementByType(SectionType.Blas2Mods),
                Environment.CurrentDirectory + "\\downloads\\BlasphemousIIMods.json",
                "https://raw.githubusercontent.com/BrandenEK/Blasphemous-Mod-Installer/main/BlasphemousIIMods.json");

            _pages.Add(SectionType.Blas1Mods, blas1mods);
            _pages.Add(SectionType.Blas1Skins, blas1skins);
            _pages.Add(SectionType.Blas2Mods, blas2mods);

            Application.Run(UIHandler);
        }

        public static UIHandler UIHandler { get; private set; }
        public static SettingsHandler SettingsHandler { get; private set; }
        public static GithubHandler GithubHandler { get; private set; }

        private static Dictionary<SectionType, BasePage> _pages = new Dictionary<SectionType, BasePage>();

        public static BasePage CurrentPage => _pages[SettingsHandler.Config.LastSection];
        public static IEnumerable<BasePage> AllPages => _pages.Values;

        public static ModPage Blas1ModPage => _pages[SectionType.Blas1Mods] as ModPage;
        public static SkinPage Blas1SkinPage => _pages[SectionType.Blas1Skins] as SkinPage;
        public static ModPage Blas2ModPage => _pages[SectionType.Blas2Mods] as ModPage;

        // Don't forget to increase this when releasing an update!  Have to do it here
        // because I'm not sure how to increase file version for windows forms
        public static Version CurrentInstallerVersion => new Version(1, 0, 1);
    }
}
