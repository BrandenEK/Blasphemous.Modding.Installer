using Blasphemous.Modding.Installer.Properties;
using Newtonsoft.Json;

namespace Blasphemous.Modding.Installer;

internal class SettingsHandler
{
    private readonly string _configPath;

    public InstallerSettings Properties { get; private set; } = new();

    public SettingsHandler(string configPath)
    {
        _configPath = configPath;
    }

    public void Save()
    {
        FormWindowState windowState = Core.UIHandler.WindowState;
        Rectangle windowBounds = Core.UIHandler.RestoreBounds;

        Settings.Default.Location = windowState == FormWindowState.Normal
            ? Core.UIHandler.Location
            : windowBounds.Location;

        Settings.Default.Size = windowState == FormWindowState.Normal
            ? Core.UIHandler.Size
            : windowBounds.Size;

        Settings.Default.Maximized = windowState == FormWindowState.Maximized;

        Settings.Default.LastSection = (byte)Properties.CurrentSection;
        Settings.Default.Blas1ModSort = (byte)Properties.Blas1ModSort;
        Settings.Default.Blas1SkinSort = (byte)Properties.Blas1SkinSort;
        Settings.Default.Blas2ModSort = (byte)Properties.Blas2ModSort;

        Settings.Default.Save();
        SaveConfigSettings(OldConfig.TempCreateFromSetttings(Properties));
    }

    // Temp until these settings are stored in Properties also
    private void SaveConfigSettings(OldConfig cfg)
    {
        File.WriteAllText(_configPath, JsonConvert.SerializeObject(cfg, Formatting.Indented));
    }

    public void Load()
    {
        Core.UIHandler.WindowState = Settings.Default.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
        Core.UIHandler.Location = Settings.Default.Location;
        Core.UIHandler.Size = Settings.Default.Size;

        OldConfig cfg = LoadConfigSettings();
        Properties = new InstallerSettings()
        {
            Blas1RootFolder = cfg.Blas1RootFolder,
            Blas2RootFolder = cfg.Blas2RootFolder,
            GithubToken = cfg.GithubToken,
            CurrentSection = (SectionType)Settings.Default.LastSection,
            Blas1ModSort = (SortType)Settings.Default.Blas1ModSort,
            Blas1SkinSort = (SortType)Settings.Default.Blas1SkinSort,
            Blas2ModSort = (SortType)Settings.Default.Blas2ModSort,
        };
    }

    // Temp until these settings are stored in Properties also
    private OldConfig LoadConfigSettings()
    {
        if (File.Exists(_configPath))
        {
            return JsonConvert.DeserializeObject<OldConfig>(File.ReadAllText(_configPath))
                ?? new OldConfig();
        }
        else
        {
            OldConfig cfg = new();
            SaveConfigSettings(cfg);
            return cfg;
        }
    }
}
