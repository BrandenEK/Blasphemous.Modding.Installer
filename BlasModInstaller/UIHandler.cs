using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BlasModInstaller
{
    public partial class UIHandler : Form
    {
        public static string DownloadsPath => Environment.CurrentDirectory + "\\downloads\\";

        public int MainSectionWidth => mainSection.Width;

        public UIHandler()
        {
            Directory.CreateDirectory(DownloadsPath);
            InitializeComponent();
        }

        private void OnFormOpen(object sender, EventArgs e)
        {
            Text = "Blasphemous Mod Installer v" + Core.CurrentInstallerVersion.ToString(3);
            Core.SettingsHandler.LoadWindowSettings();

            OpenSection(Core.SettingsHandler.Config.LastSection);
        }

        private void OnFormClose(object sender, FormClosingEventArgs e)
        {
            Core.SettingsHandler.SaveConfigSettings();
            Core.SettingsHandler.SaveWindowSettings();
        }

        public static bool PromptQuestion(string title, string question)
        {
            return MessageBox.Show(question, title, MessageBoxButtons.OKCancel) == DialogResult.OK;
        }

        // Update installer

        public void UpdatePanelSetVisible(bool visible) => warningSectionOuter.Visible = visible;

        // Debug status

        public void DebugLogSetVisible(bool visible) => debugLog.Visible = visible;

        // Location check screen

        private void ChooseBlasLocation(object sender, EventArgs e)
        {
            if (blasLocDialog.ShowDialog() == DialogResult.OK)
            {
                Core.SettingsHandler.Config.Blas1RootFolder = Path.GetDirectoryName(blasLocDialog.FileName);
                OpenSection(Core.SettingsHandler.Config.LastSection);
            }
        }

        // ...

        public Panel GetUIElementByType(SectionType type)
        {
            switch (type)
            {
                case SectionType.Blas1Mods: return blas1modSection;
                case SectionType.Blas1Skins: return blas1skinSection;
                case SectionType.Blas2Mods: return blas2modSection;
                default: return null;
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (var page in Core.AllPages)
                {
                    page.AdjustPageWidth();
                }
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
            if (Core.SettingsHandler.Config.DebugMode)
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

        private void SetSortByBox(SortType sort)
        {
            sortByName.Checked = sort == SortType.Name;
            sortByAuthor.Checked = sort == SortType.Author;
            sortByInitialRelease.Checked = sort == SortType.InitialRelease;
            sortByLatestRelease.Checked = sort == SortType.LatestRelease;
        }

        private void OpenSection(SectionType section)
        {
            Core.SettingsHandler.Config.LastSection = section;
            var currentPage = Core.CurrentPage;

            // Update background and info
            titleLabel.Text = currentPage.Title;
            titleSectionInner.BackgroundImage = currentPage.Image;
            SetSortByBox(currentPage.CurrentSortType);

            // Validate and load data
            bool validated = currentPage.ValidateDirectory();
            if (validated)
                currentPage.LoadData();

            // Show the correct page element
            currentPage.UIElement.Visible = validated;

            foreach (var page in Core.AllPages)
                if (page != currentPage)
                    page.UIElement.Visible = false;

            blas1locationSection.Visible = !validated;

            // Only show side buttons under certain conditions
            divider1.Visible = validated;
            divider2.Visible = validated;
            sortSection.Visible = validated;
            installBtn.Visible = validated && currentPage.CanInstall;
            uninstallBtn.Visible = validated && currentPage.CanInstall;
            enableBtn.Visible = validated && currentPage.CanEnable;
            disableBtn.Visible = validated && currentPage.CanEnable;
            sortByInitialRelease.Visible = currentPage.CanSortDate;
            sortByLatestRelease.Visible = currentPage.CanSortDate;
        }

        #region Side section top

        private void ClickedBlas1Mods(object sender, EventArgs e) => OpenSection(SectionType.Blas1Mods);

        private void ClickedBlas1Skins(object sender, EventArgs e) => OpenSection(SectionType.Blas1Skins);

        private void ClickedBlas2Mods(object sender, EventArgs e) => OpenSection(SectionType.Blas2Mods);

        private void ClickedSettings(object sender, EventArgs e) { }

        #endregion Side section top

        #region Side section middle

        private void ClickedSortByName(object sender, EventArgs e)
        {
            Core.CurrentPage.CurrentSortType = SortType.Name;
            Core.CurrentPage.Sort();
        }

        private void ClickedSortByAuthor(object sender, EventArgs e)
        {
            Core.CurrentPage.CurrentSortType = SortType.Author;
            Core.CurrentPage.Sort();
        }

        private void ClickedSortByInitialRelease(object sender, EventArgs e)
        {
            Core.CurrentPage.CurrentSortType = SortType.InitialRelease;
            Core.CurrentPage.Sort();
        }

        private void ClickedSortByLatestRelease(object sender, EventArgs e)
        {
            Core.CurrentPage.CurrentSortType = SortType.LatestRelease;
            Core.CurrentPage.Sort();
        }

        #endregion Side section middle

        #region Side section bottom

        private void ClickedInstallAll(object sender, EventArgs e)
        {
            Core.CurrentPage.InstallAll();
        }

        private void ClickedUninstallAll(object sender, EventArgs e)
        {
            Core.CurrentPage.UninstallAll();
        }

        private void ClickedEnableAll(object sender, EventArgs e)
        {
            Core.CurrentPage.EnableAll();
        }

        private void ClickedDisableAll(object sender, EventArgs e)
        {
            Core.CurrentPage.DisableAll();
        }

        private void ClickInstallerUpdateLink(object sender, LinkLabelLinkClickedEventArgs e) => Core.GithubHandler.OpenInstallerLink();

        #endregion Side section bottom
    }
}
