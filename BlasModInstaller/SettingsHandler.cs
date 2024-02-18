using Newtonsoft.Json;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BlasModInstaller
{
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
            Core.UIHandler.WindowState = Properties.Settings.Default.Maximized ? FormWindowState.Maximized : FormWindowState.Normal;
            Core.UIHandler.Location = Properties.Settings.Default.Location;
            Core.UIHandler.Size = Properties.Settings.Default.Size;
        }

        public void SaveWindowSettings()
        {
            FormWindowState windowState = Core.UIHandler.WindowState;
            Rectangle windowBounds = Core.UIHandler.RestoreBounds;

            if (windowState == FormWindowState.Maximized)
            {
                Properties.Settings.Default.Location = windowBounds.Location;
                Properties.Settings.Default.Size = windowBounds.Size;
                Properties.Settings.Default.Maximized = true;
            }
            else if (windowState == FormWindowState.Minimized)
            {
                Properties.Settings.Default.Location = windowBounds.Location;
                Properties.Settings.Default.Size = windowBounds.Size;
                Properties.Settings.Default.Maximized = false;
            }
            else
            {
                Properties.Settings.Default.Location = Core.UIHandler.Location;
                Properties.Settings.Default.Size = Core.UIHandler.Size;
                Properties.Settings.Default.Maximized = false;
            }

            Properties.Settings.Default.Save();
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
}
