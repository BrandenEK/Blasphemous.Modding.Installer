using BlasModInstaller.Pages;
using BlasModInstaller.Properties;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BlasModInstaller
{
    public partial class UIHandler : Form
    {
        // Don't forget to increase this when releasing an update!  Have to do it here
        // because I'm not sure how to increase file version for windows forms
        public static readonly Version currentInstallerVersion = new Version(1, 0, 1);

        public static string DownloadsPath => Environment.CurrentDirectory + "\\downloads\\";
        private string ConfigPath => Environment.CurrentDirectory + "\\installer.cfg";

        private Config config;
        public static string BlasRootFolder => Instance.config.BlasRootFolder;
        public static string BlasIIRootFolder => Instance.config.BlasIIRootFolder;
        public static SectionType CurrentSection => Instance.config.LastSection;
        public static SortType SortBlasMods => Instance.config.BlasModSort;
        public static SortType SortBlasSkins => Instance.config.BlasSkinSort;
        public static SortType SortBlasIIMods => Instance.config.BlasIIModSort;

        public int MainSectionWidth => mainSection.Width;

        public BlasModPage BlasModPage { get; private set; }
        public BlasSkinPage BlasSkinPage { get; private set; }
        public BlasIIModPage BlasIIModPage { get; private set; }

        public UIHandler()
        {
            Directory.CreateDirectory(DownloadsPath);
            InitializeComponent();

            BlasModPage = new BlasModPage(blas1modSection);
            BlasSkinPage = new BlasSkinPage(blas1skinSection);
            BlasIIModPage = new BlasIIModPage(blas2modSection);

            LoadConfig();
            OpenSection(config.LastSection);
        }

        // Config

        private void LoadConfig()
        {
            if (File.Exists(ConfigPath))
            {
                // Load config
                config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(ConfigPath));
            }
            else
            {
                // Create new config
                config = new Config();
                SaveConfig();
            }

            debugLog.Visible = config.DebugMode;
        }

        private void SaveConfig()
        {
            File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(config, Formatting.Indented));
        }

        // Update installer

        private void ClickInstallerUpdateLink(object sender, LinkLabelLinkClickedEventArgs e) => Core.GithubHandler.OpenInstallerLink();

        public void UpdatePanelSetVisible(bool visible) => warningSectionOuter.Visible = visible;

        // ...

        private void ChooseBlasLocation(object sender, EventArgs e)
        {
            if (blasLocDialog.ShowDialog() == DialogResult.OK)
            {
                config.BlasRootFolder = Path.GetDirectoryName(blasLocDialog.FileName);
                OpenSection(CurrentSection);
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                BlasModPage.AdjustPageWidth();
                BlasSkinPage.AdjustPageWidth();
                BlasIIModPage.AdjustPageWidth();
            }
            catch (NullReferenceException)
            {
                Log("Pages not initialized yet, skipping resizing!");
            }
        }

        public void RemoveButtonFocus(object sender, EventArgs e)
        {
            titleLabel.Focus();
        }

        public void Log(string message)
        {
            if (config.DebugMode)
                debugLog.Text += message + "\r\n";
        }

        private void ShowSideButtonBorder(object sender, EventArgs e)
        {
            (sender as Button).FlatAppearance.BorderColor = Color.White;
        }

        private void HideSideButtonBorder(object sender, EventArgs e)
        {
            (sender as Button).FlatAppearance.BorderColor = Color.FromArgb(30, 30, 30);
            RemoveButtonFocus(null, null);
        }

        private void ClickedBlas1Mods(object sender, EventArgs e) => OpenSection(SectionType.Blas1Mods);
        private void ClickedBlas1Skins(object sender, EventArgs e) => OpenSection(SectionType.Blas1Skins);
        private void ClickedBlas2Mods(object sender, EventArgs e) => OpenSection(SectionType.Blas2Mods);
        private void ClickedSettings(object sender, EventArgs e) { }

        private void OpenSection(SectionType section)
        {
            bool validated = false;
            if (section == SectionType.Blas1Mods)
            {
                titleLabel.Text = BlasModPage.Name;
                titleSectionInner.BackgroundImage = Resources.background1;
                SetSortByBox(SortBlasMods);

                validated = ValidateBlas1Directory(BlasRootFolder);
                if (validated)
                    BlasModPage.LoadData();

                blas1modSection.Visible = validated;
                blas1skinSection.Visible = false;
                blas2modSection.Visible = false;
                blas1locationSection.Visible = !validated;
            }
            else if (section == SectionType.Blas1Skins)
            {
                titleLabel.Text = BlasSkinPage.Name;
                titleSectionInner.BackgroundImage = Resources.background1;
                SetSortByBox(SortBlasSkins);

                validated = ValidateBlas1Directory(BlasRootFolder);
                if (validated)
                    BlasSkinPage.LoadData();

                blas1skinSection.Visible = validated;
                blas1modSection.Visible = false;
                blas2modSection.Visible = false;
                blas1locationSection.Visible = !validated;
            }
            else if (section == SectionType.Blas2Mods)
            {
                titleLabel.Text = BlasIIModPage.Name;
                titleSectionInner.BackgroundImage = Resources.background2;
                SetSortByBox(SortBlasIIMods);

                // Validate exe and load data

                blas2modSection.Visible = true;
                blas1modSection.Visible = false;
                blas1skinSection.Visible = false;
                blas1locationSection.Visible = false;
            }

            // Only show side buttons under certain conditions
            divider1.Visible = validated;
            divider2.Visible = validated;
            sortSection.Visible = validated;
            installBtn.Visible = validated;
            uninstallBtn.Visible = validated;
            enableBtn.Visible = validated && section != SectionType.Blas1Skins;
            disableBtn.Visible = validated && section != SectionType.Blas1Skins;
            sortByInitialRelease.Visible = section != SectionType.Blas1Skins;
            sortByLatestRelease.Visible = section != SectionType.Blas1Skins;

            config.LastSection = section;
        }

        private bool ValidateBlas1Directory(string blasRootPath)
        {
            if (File.Exists(blasRootPath + "\\Blasphemous.exe"))
            {
                Log("Blas1 exe path validated!");
                config.BlasRootFolder = blasRootPath;

                Directory.CreateDirectory(blasRootPath + "\\Modding\\disabled"); // Only because its not included in the API
                return true;
            }

            Log("Blas1 exe path not found!");
            return false;
        }

        // Sorting

        private void ClickedSortByName(object sender, EventArgs e)
        {
            switch (CurrentSection)
            {
                case SectionType.Blas1Mods: config.BlasModSort = SortType.Name; BlasModPage.Sort(); break;
                case SectionType.Blas1Skins: config.BlasSkinSort = SortType.Name; BlasSkinPage.Sort(); break;
                case SectionType.Blas2Mods: config.BlasIIModSort = SortType.Name; BlasIIModPage.Sort(); break;
            }
        }

        private void ClickedSortByAuthor(object sender, EventArgs e)
        {
            switch (CurrentSection)
            {
                case SectionType.Blas1Mods: config.BlasModSort = SortType.Author; BlasModPage.Sort();  break;
                case SectionType.Blas1Skins: config.BlasSkinSort = SortType.Author; BlasSkinPage.Sort(); break;
                case SectionType.Blas2Mods: config.BlasIIModSort = SortType.Author; BlasIIModPage.Sort(); break;
            }
        }

        private void ClickedSortByInitialRelease(object sender, EventArgs e)
        {
            switch (CurrentSection)
            {
                case SectionType.Blas1Mods: config.BlasModSort = SortType.InitialRelease; BlasModPage.Sort();  break;
                case SectionType.Blas1Skins: config.BlasSkinSort = SortType.InitialRelease; BlasSkinPage.Sort(); break;
                case SectionType.Blas2Mods: config.BlasIIModSort = SortType.InitialRelease; BlasIIModPage.Sort(); break;
            }
        }

        private void ClickedSortByLatestRelease(object sender, EventArgs e)
        {
            switch (CurrentSection)
            {
                case SectionType.Blas1Mods: config.BlasModSort = SortType.LatestRelease; BlasModPage.Sort();  break;
                case SectionType.Blas1Skins: config.BlasSkinSort = SortType.LatestRelease; BlasSkinPage.Sort(); break;
                case SectionType.Blas2Mods: config.BlasIIModSort = SortType.LatestRelease; BlasIIModPage.Sort(); break;
            }
        }

        private void SetSortByBox(SortType sort)
        {
            sortByName.Checked = sort == SortType.Name;
            sortByAuthor.Checked = sort == SortType.Author;
            sortByInitialRelease.Checked = sort == SortType.InitialRelease;
            sortByLatestRelease.Checked = sort == SortType.LatestRelease;
        }

        // Global download

        private void ClickedInstallAll(object sender, EventArgs e)
        {
            switch (CurrentSection)
            {
                case SectionType.Blas1Mods: BlasModPage.InstallAll(); break;
                case SectionType.Blas1Skins: BlasSkinPage.InstallAll(); break;
                case SectionType.Blas2Mods: BlasIIModPage.InstallAll(); break;
            }
        }

        private void ClickedUninstallAll(object sender, EventArgs e)
        {
            switch (CurrentSection)
            {
                case SectionType.Blas1Mods: BlasModPage.UninstallAll(); break;
                case SectionType.Blas1Skins: BlasSkinPage.UninstallAll(); break;
                case SectionType.Blas2Mods: BlasIIModPage.UninstallAll(); break;
            }
        }

        private void ClickedEnableAll(object sender, EventArgs e)
        {
            switch (CurrentSection)
            {
                case SectionType.Blas1Mods: BlasModPage.EnableAll(); break;
                case SectionType.Blas1Skins: BlasSkinPage.EnableAll(); break;
                case SectionType.Blas2Mods: BlasIIModPage.EnableAll(); break;
            }
        }

        private void ClickedDisableAll(object sender, EventArgs e)
        {
            switch (CurrentSection)
            {
                case SectionType.Blas1Mods: BlasModPage.DisableAll(); break;
                case SectionType.Blas1Skins: BlasSkinPage.DisableAll(); break;
                case SectionType.Blas2Mods: BlasIIModPage.DisableAll(); break;
            }
        }

        // Form state

        private void SaveWindowState()
        {
            if (WindowState == FormWindowState.Maximized)
            {
                Properties.Settings.Default.Location = RestoreBounds.Location;
                Properties.Settings.Default.Size = RestoreBounds.Size;
                Properties.Settings.Default.Maximized = true;
            }
            else if (WindowState == FormWindowState.Minimized)
            {
                Properties.Settings.Default.Location = RestoreBounds.Location;
                Properties.Settings.Default.Size = RestoreBounds.Size;
                Properties.Settings.Default.Maximized = false;
            }
            else
            {
                Properties.Settings.Default.Location = Location;
                Properties.Settings.Default.Size = Size;
                Properties.Settings.Default.Maximized = false;
            }
            Properties.Settings.Default.Save();
        }

        private void LoadWindowState()
        {
            WindowState = Properties.Settings.Default.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
            Location = Properties.Settings.Default.Location;
            Size = Properties.Settings.Default.Size;
        }

        private void OnFormOpen(object sender, EventArgs e)
        {
            Text = "Blasphemous Mod Installer v" + currentInstallerVersion.ToString(3);
            LoadWindowState();
        }

        private void OnFormClose(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
            SaveWindowState();
        }
    }
}
