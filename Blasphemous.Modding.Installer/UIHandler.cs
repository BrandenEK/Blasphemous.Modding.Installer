using Basalt.BetterForms;
using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.PageComponents.Validators;

namespace Blasphemous.Modding.Installer;

public partial class UIHandler : BasaltForm
{
    private bool _disableEvents = false;

    protected override void OnFormOpen()
    {
        ClearPreview();
        OpenSection(Core.TempConfig.LastSection);
    }

    public static bool PromptQuestion(string title, string question)
    {
        return MessageBox.Show(question, title, MessageBoxButtons.OKCancel) == DialogResult.OK;
    }

    private void RunWithoutEvents(Action action)
    {
        _disableEvents = true;
        action();
        _disableEvents = false;
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
            Core.CurrentPage.GameSettings.RootFolder = path;
            OpenSection(Core.TempConfig.LastSection);

            // Not necessary since we just opened a new section
            //OnPathChanged?.Invoke(path);
        }
    }

    // UI retrieval

    public Panel DataHolder => _bottom_holder;

    // UI focusing

    public void RemoveButtonFocus(object? sender, EventArgs e)
    {
        _top_text.Focus();
    }

    private void OpenSection(SectionType section)
    {
        Core.CurrentPage.Previewer.Clear();
        Core.CurrentPage.Lister.ClearList();

        //Core.SettingsHandler.Properties.CurrentSection = section;
        Core.TempConfig.LastSection = section;
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
        }

        // Refresh all ui elements on the page
        currentPage.Lister.RefreshList();
        currentPage.Grouper.RefreshAll();

        // Handle UI for sorting and filtering
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
        RunWithoutEvents(() =>
        {
            _left_sort_options.SelectedIndex = (int)currentPage.PageSettings.Sort;
        });

        _left_filter_options.Items.Clear();
        _left_filter_options.Items.Add("All");
        if (currentPage.Grouper.CanInstall)
        {
            _left_filter_options.Items.Add("Not installed");
            _left_filter_options.Items.Add("Installed");
        }
        if (currentPage.Grouper.CanEnable)
        {
            _left_filter_options.Items.Add("Disabled");
            _left_filter_options.Items.Add("Enabled");
        }
        RunWithoutEvents(() =>
        {
            _left_filter_options.SelectedIndex = (int)currentPage.PageSettings.Filter;
        });

        // Handle UI for grouping
        _left_all.Visible = validated;
        _left_all_install.Visible = currentPage.Grouper.CanInstall;
        _left_all_uninstall.Visible = currentPage.Grouper.CanInstall;
        _left_all_enable.Visible = currentPage.Grouper.CanEnable;
        _left_all_disable.Visible = currentPage.Grouper.CanEnable;

        // Handle UI for previewing
        _left_details.Visible = validated;

        // Handle UI for starting
        LaunchSettings launch = currentPage.GameSettings.Launch;
        _left_start.Visible = validated;
        RunWithoutEvents(() =>
        {
            _left_start_modded.Checked = launch.RunModded;
            _left_start_console.Checked = launch.RunConsole;
        });

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

        _middle_tools_text.Text = text;
        _middle_tools_icon.BackgroundImage = icon;
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

    // Side section paging

    private void ClickedBlas1Mods(object sender, EventArgs e) => OpenSection(SectionType.Blas1Mods);

    private void ClickedBlas1Skins(object sender, EventArgs e) => OpenSection(SectionType.Blas1Skins);

    private void ClickedBlas2Mods(object sender, EventArgs e) => OpenSection(SectionType.Blas2Mods);

    // Side section previewing

    public void UpdatePreview(string name, string description, string version, Bitmap? image)
    {
        _left_details_name.Text = name;
        _left_details_name.Visible = !string.IsNullOrEmpty(name);

        _left_details_desc.Text = description;
        _left_details_desc.Visible = !string.IsNullOrEmpty(description);

        _left_details_version.Text = version;
        _left_details_version.Visible = !string.IsNullOrEmpty(version);

        _left_details_inner.BackgroundImage?.Dispose();
        _left_details_inner.BackgroundImage = image;
    }

    public void ClearPreview()
    {
        UpdatePreview(string.Empty, string.Empty, string.Empty, null);
    }

    // Side section sorting

    private void ChangedSortOption(object sender, EventArgs e)
    {
        if (_disableEvents)
            return;

        int index = _left_sort_options.SelectedIndex;
        Logger.Info($"Changing sort to {index}");

        Core.CurrentPage.PageSettings.Sort = (SortType)index;
        Core.CurrentPage.Lister.RefreshList();
    }

    private void ChangedFilterOption(object sender, EventArgs e)
    {
        if (_disableEvents)
            return;

        int index = _left_filter_options.SelectedIndex;
        Logger.Info($"Changing filter to {index}");

        Core.CurrentPage.PageSettings.Filter = (FilterType)index;
        Core.CurrentPage.Lister.RefreshList();
    }

    // Side section grouping

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

    // Side section starting

    private void CheckedStartOption(object sender, EventArgs e)
    {
        if (_disableEvents)
            return;

        Logger.Info("Updating launch options");
        Core.CurrentPage.GameSettings.Launch.RunModded = _left_start_modded.Checked;
        Core.CurrentPage.GameSettings.Launch.RunConsole = _left_start_console.Checked;
    }

    private void ClickedStart(object sender, EventArgs e)
    {
        if (!Core.CurrentPage.Validator.AreModdingToolsInstalled)
        {
            Logger.Warn("Tried to start game without modding tools");
            MessageBox.Show("You need to install the modding tools first!", $"Can not launch {Core.CurrentPage.Validator.ExeName}");
            return;
        }

        Logger.Info($"Starting {Core.CurrentPage.Title} game");
        Core.CurrentPage.GameStarter.Start();
    }

    // Side section links

    private void ClickedDiscordLink(object sender, EventArgs e)
    {
        Logger.Info("Opening discord link!");
    }

    private void ClickedGithubLink(object sender, EventArgs e)
    {
        Logger.Info("Opening github link!");
    }

    // Events

    internal delegate void PageDelegate(InstallerPage page);
    internal static PageDelegate? OnPageOpened;

    internal delegate void PathDelegate(string path);
    internal static PathDelegate? OnPathChanged;
}
