using Blasphemous.Modding.Installer.Validation;

namespace Blasphemous.Modding.Installer;

public partial class UIHandler : Form
{
    public int MainSectionWidth => mainSection.Width;

    public UIHandler()
    {
        Directory.CreateDirectory(Core.DataCache);

        InitializeComponent();
    }

    private void OnFormOpen(object sender, EventArgs e)
    {
        Text = "Blasphemous Mod Installer v" + Core.CurrentVersion.ToString(3);
        Core.SettingsHandler.Load();

        foreach (var page in Core.AllPages)
            page.Previewer.Clear();

        OpenSection(Core.SettingsHandler.Properties.CurrentSection);
    }

    private void OnFormClose(object sender, FormClosingEventArgs e)
    {
        Core.SettingsHandler.Save();
    }

    public static bool PromptQuestion(string title, string question)
    {
        return MessageBox.Show(question, title, MessageBoxButtons.OKCancel) == DialogResult.OK;
    }

    // Update installer

    public void UpdatePanelSetVisible(bool visible) => warningSectionOuter.Visible = visible;

    // Validation screen

    private void ClickLocationButton(object sender, EventArgs e)
    {
        IValidator validator = Core.CurrentPage.Validator;

        blasLocDialog.Title = $"Choose {validator.ExeName} location";
        blasLocDialog.FileName = validator.ExeName;
        blasLocDialog.InitialDirectory = validator.DefaultPath;

        if (blasLocDialog.ShowDialog() == DialogResult.OK)
        {
            validator.SetRootPath(Path.GetDirectoryName(blasLocDialog.FileName));
            OpenSection(Core.SettingsHandler.Properties.CurrentSection);
        }
    }

    private async void ClickToolsButton(object sender, EventArgs e)
    {
        toolsBtn.Enabled = false;
        toolsBtn.Text = "Installing...";
        await Core.CurrentPage.Validator.InstallModdingTools();
        OpenSection(Core.SettingsHandler.Properties.CurrentSection);
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

    public Label PreviewName => detailsName;
    public Label PreviewDescription => detailsDescription;
    public Label PreviewVersion => detailsVersion;
    public Panel PreviewBackground => detailsSectionInner;

    private void MainForm_SizeChanged(object sender, EventArgs e)
    {
        try
        {
            foreach (var page in Core.AllPages)
            {
                page.UIHolder.AdjustPageWidth();
            }
        }
        catch (NullReferenceException)
        {
            Logger.Error("Pages not initialized yet, skipping resizing!");
        }
    }

    public void RemoveButtonFocus(object sender, EventArgs e)
    {
        titleLabel.Focus();
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
        Core.CurrentPage.Previewer.Clear();

        Core.SettingsHandler.Properties.CurrentSection = section;
        var currentPage = Core.CurrentPage;

        // Update background and info
        titleLabel.Text = currentPage.Title;
        titleSectionInner.BackgroundImage = currentPage.Image;

        // Validate the status of mods
        bool folderValid = currentPage.Validator.IsRootFolderValid;
        bool toolsInstalled = folderValid && currentPage.Validator.AreModdingToolsInstalled;
        bool toolsUpdated = toolsInstalled && currentPage.Validator.AreModdingToolsUpdated;

        bool validated = toolsUpdated;
        Logger.Info("Modding status validation: " + validated);

        if (validated)
        {
            SetSortByBox(Core.SettingsHandler.Properties.CurrentSort);
            currentPage.Loader.LoadAllData();
            validationSection.Visible = false;
        }
        else
        {
            validationSection.Visible = true;
            locationBtn.Enabled = !folderValid;
            locationBtn.Text = "Locate " + currentPage.Validator.ExeName;
            toolsBtn.Enabled = folderValid;
            toolsBtn.Text = (toolsInstalled ? "Update" : "Install") + " modding tools";
        }

        // Show the correct page element
        currentPage.UIHolder.SectionPanel.Visible = validated;
        foreach (var page in Core.AllPages)
            if (page != currentPage)
                page.UIHolder.SectionPanel.Visible = false;

        // Only show side buttons under certain conditions
        divider1.Visible = validated;

        sortSection.Visible = validated;
        sortByName.Visible = validated && currentPage.Grouper.CanSortByCreation;
        sortByAuthor.Visible = validated && currentPage.Grouper.CanSortByCreation;
        sortByInitialRelease.Visible = currentPage.Grouper.CanSortByDate;
        sortByLatestRelease.Visible = currentPage.Grouper.CanSortByDate;

        divider2.Visible = validated;

        allInstallBtn.Visible = validated && currentPage.Grouper.CanInstall;
        allUninstallBtn.Visible = validated && currentPage.Grouper.CanInstall;
        allEnableBtn.Visible = validated && currentPage.Grouper.CanEnable;
        allDisableBtn.Visible = validated && currentPage.Grouper.CanEnable;

        divider3.Visible = validated;

        detailsSectionOuter.Visible = validated;
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
        Core.SettingsHandler.Properties.CurrentSort = SortType.Name;
        Core.CurrentPage.Sorter.Sort();
    }

    private void ClickedSortByAuthor(object sender, EventArgs e)
    {
        Core.SettingsHandler.Properties.CurrentSort = SortType.Author;
        Core.CurrentPage.Sorter.Sort();
    }

    private void ClickedSortByInitialRelease(object sender, EventArgs e)
    {
        Core.SettingsHandler.Properties.CurrentSort = SortType.InitialRelease;
        Core.CurrentPage.Sorter.Sort();
    }

    private void ClickedSortByLatestRelease(object sender, EventArgs e)
    {
        Core.SettingsHandler.Properties.CurrentSort = SortType.LatestRelease;
        Core.CurrentPage.Sorter.Sort();
    }

    #endregion Side section middle

    #region Side section bottom

    private void ClickedInstallAll(object sender, EventArgs e)
    {
        Core.CurrentPage.Grouper.InstallAll();
    }

    private void ClickedUninstallAll(object sender, EventArgs e)
    {
        Core.CurrentPage.Grouper.UninstallAll();
    }

    private void ClickedEnableAll(object sender, EventArgs e)
    {
        Core.CurrentPage.Grouper.EnableAll();
    }

    private void ClickedDisableAll(object sender, EventArgs e)
    {
        Core.CurrentPage.Grouper.DisableAll();
    }

    private void ClickInstallerUpdateLink(object sender, LinkLabelLinkClickedEventArgs e) => Core.GithubHandler.OpenInstallerLink();

    #endregion Side section bottom

    private void ClickedDisordLink(object sender, LinkLabelLinkClickedEventArgs e)
    {

    }

    private void ClickedGithubLink(object sender, LinkLabelLinkClickedEventArgs e)
    {

    }
}
