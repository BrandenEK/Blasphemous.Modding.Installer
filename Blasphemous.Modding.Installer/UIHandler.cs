using Basalt.BetterForms;
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

    // Maybe move this to the StandardValidator?? But it calls OpenSection
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
            string path = Path.GetDirectoryName(dialog.FileName)!;
            validator.SetRootPath(path);
            OpenSection(Core.SettingsHandler.Properties.CurrentSection);

            // Not necessary since we just opened a new section
            //OnPathChanged?.Invoke(path);
        }
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

    private void OpenSection(SectionType section)
    {
        Core.CurrentPage.Previewer.Clear();

        Core.SettingsHandler.Properties.CurrentSection = section;
        var currentPage = Core.CurrentPage;

        // Update background and info
        _top_text.Text = currentPage.Title;
        _top_inner.BackgroundImage = currentPage.Image;

        // Validate the status of mods
        bool validated = currentPage.Validator.IsRootFolderValid;
        Logger.Info("Modding status validation: " + validated);

        if (validated)
        {
            currentPage.Loader.LoadAllData();
            _bottom_validation.Visible = false;
        }
        else
        {
            _bottom_validation.Visible = true;
        }

        // Show the correct page element
        currentPage.UIHolder.SectionPanel.Visible = validated;
        foreach (var page in Core.AllPages)
            if (page != currentPage)
                page.UIHolder.SectionPanel.Visible = false;

        // Refresh all ui elements on the page
        currentPage.Grouper.RefreshAll();

        // Handle UI for sorting
        _left_sort.Visible = validated;
        _left_sort_options.Items.Clear();
        if (currentPage.Grouper.CanSortByCreation)
        {
            _left_sort_options.Items.Add("Name");
            _left_sort_options.Items.Add("Author");
        }
        if (currentPage.Grouper.CanSortByDate)
        {
            _left_sort_options.Items.Add("Initial release");
            _left_sort_options.Items.Add("Latest release");
        }
        _left_sort_options.SelectedIndex = (int)Core.SettingsHandler.Properties.CurrentSort;

        // Handle UI for grouping
        _left_all.Visible = validated;
        _left_all_install.Visible = currentPage.Grouper.CanInstall;
        _left_all_uninstall.Visible = currentPage.Grouper.CanInstall;
        _left_all_enable.Visible = currentPage.Grouper.CanEnable;
        _left_all_disable.Visible = currentPage.Grouper.CanEnable;

        // Handle UI for previewing
        _left_details.Visible = validated;

        // Handle UI for starting
        LaunchOptions launch = Core.SettingsHandler.Properties.CurrentLaunchOptions;
        _left_start.Visible = validated;
        _left_start_modded.Checked = launch.RunModded;
        _left_start_console.Checked = launch.RunConsole;

        Logger.Debug($"Opened page: {currentPage.Title}");
        OnPageOpened?.Invoke(currentPage);
    }

    // Top section

    public void UpdateVersionWarningVisibility(bool visible)
    {
        _top_warning_outer.Visible = visible;
    }

    private void ClickedVersionWarning(object sender, LinkLabelLinkClickedEventArgs e) => Core.GithubHandler.OpenInstallerLink();

    // Middle section path

    public void UpdateRootFolderText(string text)
    {
        _middle_path.Text = text;
        _middle_path.Width = _middle_path.PreferredWidth;
    }

    private void ClickedRootFolder(object sender, EventArgs e) => PromptForRootFolder();

    // Middle section tools

    public void UpdateToolStatus(string text, Bitmap icon)
    {
        Logger.Info("Updating tool status UI");
        ShowToolStatus();

        _middle_tools_icon.BackgroundImage = icon;
        _tooltip.RemoveAll();
        _tooltip.SetToolTip(_middle_tools_text, text);
        _tooltip.SetToolTip(_middle_tools_icon, text);
    }

    public void ShowToolStatus()
    {
        _middle_tools.Visible = true;
    }

    public void HideToolStatus()
    {
        _middle_tools.Visible = false;
    }

    private void ClickedToolsStatus(object sender, EventArgs e)
    {
        Core.CurrentPage.Validator.OnClickToolStatus();
    }

    // Side section top

    private void ClickedBlas1Mods(object sender, EventArgs e) => OpenSection(SectionType.Blas1Mods);

    private void ClickedBlas1Skins(object sender, EventArgs e) => OpenSection(SectionType.Blas1Skins);

    private void ClickedBlas2Mods(object sender, EventArgs e) => OpenSection(SectionType.Blas2Mods);

    // Side section middle

    private void ChangedSortOption(object sender, EventArgs e)
    {
        int index = _left_sort_options.SelectedIndex;
        Logger.Info($"Changing sort to {index}");

        Core.SettingsHandler.Properties.CurrentSort = (SortType)index;
        Core.CurrentPage.Sorter.Sort();
    }

    // Side section bottom

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

    // Side section lower

    private void CheckedStartOption(object sender, EventArgs e)
    {
        Logger.Info("Updating launch options");
        Core.SettingsHandler.Properties.CurrentLaunchOptions = new LaunchOptions()
        {
            RunModded = _left_start_modded.Checked,
            RunConsole = _left_start_console.Checked,
        };
    }

    private void ClickedStart(object sender, EventArgs e)
    {
        Logger.Info($"Starting {Core.CurrentPage.Title} game");
        Core.CurrentPage.GameStarter.Start();
    }

    // Events

    internal delegate void PageDelegate(InstallerPage page);
    internal static PageDelegate? OnPageOpened;

    internal delegate void PathDelegate(string path);
    internal static PathDelegate? OnPathChanged;
}
