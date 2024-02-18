using Blasphemous.Modding.Installer.Properties;
using Newtonsoft.Json;

namespace Blasphemous.Modding.Installer;

internal class SettingsHandler
{
    private readonly string _configPath;

    public Config Config { get; private set; }

    public SettingsHandler(string configPath)
    {
        _configPath = configPath;

        LoadConfigSettings();
    }

    public void LoadConfigSettings()
    {
        if (File.Exists(_configPath))
        {
            Config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(_configPath));
        }
        else
        {
            Config = new Config();
            SaveConfigSettings();
        }
    }

    public void SaveConfigSettings()
    {
        File.WriteAllText(_configPath, JsonConvert.SerializeObject(Config, Formatting.Indented));
    }

    public void LoadWindowSettings()
    {
        Core.UIHandler.WindowState = Settings.Default.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
        Core.UIHandler.Location = Settings.Default.Location;
        Core.UIHandler.Size = Settings.Default.Size;
    }

    public void SaveWindowSettings()
    {
        FormWindowState windowState = Core.UIHandler.WindowState;
        Rectangle windowBounds = Core.UIHandler.RestoreBounds;

        if (windowState == FormWindowState.Maximized)
        {
            Settings.Default.Location = windowBounds.Location;
            Settings.Default.Size = windowBounds.Size;
            Settings.Default.Maximized = true;
        }
        else if (windowState == FormWindowState.Minimized)
        {
            Settings.Default.Location = windowBounds.Location;
            Settings.Default.Size = windowBounds.Size;
            Settings.Default.Maximized = false;
        }
        else
        {
            Settings.Default.Location = Core.UIHandler.Location;
            Settings.Default.Size = Core.UIHandler.Size;
            Settings.Default.Maximized = false;
        }

        Settings.Default.Save();
    }

    public string GetRootPathBySection(SectionType section)
    {
        switch (section)
        {
            case SectionType.Blas1Mods: return Config.Blas1RootFolder;
            case SectionType.Blas1Skins: return Config.Blas1RootFolder;
            case SectionType.Blas2Mods: return Config.Blas2RootFolder;
            default: return null;
        }
    }

    public SortType CurrentSortType
    {
        get
        {
            switch (Config.LastSection)
            {
                case SectionType.Blas1Mods: return Config.Blas1ModSort;
                case SectionType.Blas1Skins: return Config.Blas1SkinSort;
                case SectionType.Blas2Mods: return Config.Blas2ModSort;
                default: return SortType.Name;
            }
        }
        set
        {
            switch (Config.LastSection)
            {
                case SectionType.Blas1Mods: Config.Blas1ModSort = value; break;
                case SectionType.Blas1Skins: Config.Blas1SkinSort = value; break;
                case SectionType.Blas2Mods: Config.Blas2ModSort = value; break;
            }
        }
    }
}
