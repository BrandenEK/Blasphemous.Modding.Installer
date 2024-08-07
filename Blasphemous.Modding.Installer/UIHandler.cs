﻿using Basalt.BetterForms;
using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.PageComponents.Validators;

namespace Blasphemous.Modding.Installer;

public partial class UIHandler : BasaltForm
{
    protected override void OnFormOpenPost()
    {
        Core.SettingsHandler.Load();

        foreach (var page in Core.AllPages)
            page.Previewer.Clear();

        OpenSection(Core.SettingsHandler.Properties.CurrentSection);
    }

    protected override void OnFormClose(FormClosingEventArgs e)
    {
        Core.SettingsHandler.Save();
    }

    public static bool PromptQuestion(string title, string question)
    {
        return MessageBox.Show(question, title, MessageBoxButtons.OKCancel) == DialogResult.OK;
    }

    // Update installer

    public void UpdatePanelSetVisible(bool visible) => _top_warning_outer.Visible = visible;

    // Validation screen

    private void PromptForRootFolder()
    {
        Logger.Warn("Prompting for root folder");
        IValidator validator = Core.CurrentPage.Validator;

        OpenFileDialog dialog = new()
        {
            FileName = validator.ExeName,
            Filter = "Exe files (*.exe)|*.exe",
            InitialDirectory = validator.DefaultPath,
            Title = $"Choose {validator.ExeName} location",
        };

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            validator.SetRootPath(Path.GetDirectoryName(dialog.FileName));
            OpenSection(Core.SettingsHandler.Properties.CurrentSection);
        }
    }

    private async void DownloadTools()
    {
        _bottom_validation_tools.Enabled = false;
        _bottom_validation_tools.Text = "Installing...";
        await Core.CurrentPage.Validator.InstallModdingTools();
        OpenSection(Core.SettingsHandler.Properties.CurrentSection);
    }

    private void ClickLocationButton(object sender, EventArgs e) => PromptForRootFolder();

    private void ClickToolsButton(object sender, EventArgs e) => DownloadTools();

    // ...

    private void StartGameProcess(bool useModded)
    {
        Logger.Info($"Starting {Core.SettingsHandler.Properties.CurrentSection} game as {(useModded ? "Modded" : "Vanilla")}");

        if (useModded)
            Core.CurrentPage.GameStarter.StartModded();
        else
            Core.CurrentPage.GameStarter.StartVanilla();
    }

    public Panel GetUIElementByType(SectionType type)
    {
        return type switch
        {
            SectionType.Blas1Mods => _bottom_blas1mod,
            SectionType.Blas1Skins => _bottom_blas1skin,
            SectionType.Blas2Mods => _bottom_blas2mod,
            _ => throw new Exception("Invalid section type: " + type),
        };
    }

    public Label PreviewName => _left_details_name;
    public Label PreviewDescription => _left_details_desc;
    public Label PreviewVersion => _left_details_version;
    public Panel PreviewBackground => _left_details_inner;

    // UI focusing

    public void RemoveButtonFocus(object? sender, EventArgs e)
    {
        _top_text.Focus();
    }

    private void SetSortByBox(SortType sort)
    {
        _left_sort_name.Checked = sort == SortType.Name;
        _left_sort_author.Checked = sort == SortType.Author;
        _left_sort_initialRelease.Checked = sort == SortType.InitialRelease;
        _left_sort_latestRelease.Checked = sort == SortType.LatestRelease;
    }

    private void OpenSection(SectionType section)
    {
        Core.CurrentPage.Previewer.Clear();

        Core.SettingsHandler.Properties.CurrentSection = section;
        var currentPage = Core.CurrentPage;

        // Update background and info
        _top_text.Text = currentPage.Title;
        _top_inner.BackgroundImage = currentPage.Image;

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
            _bottom_validation.Visible = false;
        }
        else
        {
            _bottom_validation.Visible = true;
            _bottom_validation_location.Enabled = !folderValid;
            _bottom_validation_location.Text = "Locate " + currentPage.Validator.ExeName;
            _bottom_validation_tools.Enabled = folderValid;
            _bottom_validation_tools.Text = (toolsInstalled ? "Update" : "Install") + " modding tools";
        }

        // Show the correct page element
        currentPage.UIHolder.SectionPanel.Visible = validated;
        foreach (var page in Core.AllPages)
            if (page != currentPage)
                page.UIHolder.SectionPanel.Visible = false;

        // Refresh all ui elements on the page
        currentPage.Grouper.RefreshAll();

        // Only show side buttons under certain conditions
        _left_divider1.Visible = validated;

        _left_sort.Visible = validated;
        _left_sort_name.Visible = validated && currentPage.Grouper.CanSortByCreation;
        _left_sort_author.Visible = validated && currentPage.Grouper.CanSortByCreation;
        _left_sort_initialRelease.Visible = currentPage.Grouper.CanSortByDate;
        _left_sort_latestRelease.Visible = currentPage.Grouper.CanSortByDate;

        _left_divider2.Visible = validated;

        _left_all_install.Visible = validated && currentPage.Grouper.CanInstall;
        _left_all_uninstall.Visible = validated && currentPage.Grouper.CanInstall;
        _left_all_enable.Visible = validated && currentPage.Grouper.CanEnable;
        _left_all_disable.Visible = validated && currentPage.Grouper.CanEnable;

        _left_divider3.Visible = validated;

        _left_details_outer.Visible = validated;
        _left_startVanilla.ExpectedVisibility = validated;
        _left_startModded.ExpectedVisibility = validated;
        _left_changePath.ExpectedVisibility = validated;
    }

    private void ClickInstallerUpdateLink(object sender, LinkLabelLinkClickedEventArgs e) => Core.GithubHandler.OpenInstallerLink();

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

    #endregion Side section bottom

    #region Side section lower

    private void ClickedStartVanilla(object sender, EventArgs e) => StartGameProcess(false);

    private void ClickedStartModded(object sender, EventArgs e) => StartGameProcess(true);

    private void ClickedChangePath(object sender, EventArgs e) => PromptForRootFolder();

    #endregion Side section lower
}
