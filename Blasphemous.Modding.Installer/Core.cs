using Basalt.BetterForms;
using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.Mods;
using Blasphemous.Modding.Installer.PageComponents.Groupers;
using Blasphemous.Modding.Installer.PageComponents.Listers;
using Blasphemous.Modding.Installer.PageComponents.Loaders;
using Blasphemous.Modding.Installer.PageComponents.Previewers;
using Blasphemous.Modding.Installer.PageComponents.Sorters;
using Blasphemous.Modding.Installer.PageComponents.Starters;
using Blasphemous.Modding.Installer.PageComponents.Validators;
using Blasphemous.Modding.Installer.Properties;
using Blasphemous.Modding.Installer.Skins;

namespace Blasphemous.Modding.Installer;

static class Core
{
    [STAThread]
    static void Main()
    {
        BasaltApplication.Run<UIHandler, InstallerCommand>(InitializeCore, "Blasphemous Mod Installer", new string[]
        {
            InstallerFolder, CacheFolder
        });
    }

    /// <summary>
    /// When the app is started, clear cache that used to exist in root data folder.
    /// Get rid of this method after enough time.  Added in 1.6
    /// </summary>
    static void TemporaryClearDataFolder()
    {
        // Delete all files other than the log
        foreach (var file in Directory.GetFiles(InstallerFolder).Where(x => Path.GetExtension(x) != ".log"))
        {
            Logger.Debug($"Deleting {file} from the installer folder");
            File.Delete(file);
        }

        // Delete all directories other than the cache
        foreach (var dir in Directory.GetDirectories(InstallerFolder).Where(x => Path.GetFileName(x) != "cache"))
        {
            Logger.Debug($"Deleting {dir} from the installer folder");
            Directory.Delete(dir, true);
        }
    }

    static void InitializeCore(UIHandler form, InstallerCommand cmd)
    {
        TemporaryClearDataFolder();

        UIHandler = form;
        SettingsHandler = new SettingsHandler();
        GithubHandler = new GithubHandler(cmd.GithubToken);
        TempIgnoreTime = cmd.IgnoreTime;

        List<Mod> blas1mods = new List<Mod>();
        List<Skin> blas1skins = new List<Skin>();
        List<Mod> blas2mods = new List<Mod>();

        string blas1modTitle = "Blasphemous Mods";
        string blas1skinTitle = "Blasphemous Skins";
        string blas2modTitle = "Blasphemous II Mods";

        // Groupers
        var blas1modGrouper = new ModGrouper(blas1modTitle, blas1mods);
        var blas1skinGrouper = new SkinGrouper(blas1skinTitle, blas1skins);
        var blas2modGrouper = new ModGrouper(blas2modTitle, blas2mods);

        // Sorters
        var blas1modSorter = new ModSorter(SectionType.Blas1Mods);
        var blas1skinSorter = new SkinSorter(SectionType.Blas1Skins);
        var blas2modSorter = new ModSorter(SectionType.Blas2Mods);

        // Listers
        var blas1modLister = new ModLister(UIHandler.DataHolder, blas1mods, blas1modSorter);
        var blas1skinLister = new ModLister(UIHandler.DataHolder, blas2mods, blas2modSorter);
        var blas2modLister = new ModLister(UIHandler.DataHolder, blas2mods, blas2modSorter);

        // Loaders
        var blas1modLoader = new ModLoader(
            Path.Combine(CacheFolder, "blas1mods.json"),
            "https://raw.githubusercontent.com/BrandenEK/Blasphemous.Modding.Installer/main/BlasphemousMods.json",
            blas1modLister,
            blas1mods,
            SectionType.Blas1Mods);
        var blas1skinLoader = new SkinLoader(
            Path.Combine(CacheFolder, "blas1skins.json"),
            "blasphemous1",
            blas1skinLister,
            blas1skins,
            SectionType.Blas1Skins);
        var blas2modLoader = new ModLoader(
            Path.Combine(CacheFolder, "blas2mods.json"),
            "https://raw.githubusercontent.com/BrandenEK/Blasphemous.Modding.Installer/main/BlasphemousIIMods.json",
            blas2modLister,
            blas2mods,
            SectionType.Blas2Mods);

        // Validators
        var blas1Validator = new Blas1Validator(
            "blas1tools",
            Path.Combine("C:", "Program Files (x86)", "Steam", "steamapps", "common", "Blasphemous"),
            "Blasphemous.exe",
            Path.Combine("BepInEx", "patchers", "BepInEx.MultiFolderLoader.dll"),
            "https://github.com/BrandenEK/Blasphemous.ModdingTools/raw/main/modding-tools-windows.zip",
            "https://raw.githubusercontent.com/BrandenEK/Blasphemous.ModdingTools/main/modding-tools-windows.version");
        var blas2Validator = new Blas2Validator(
            "blas2tools",
            Path.Combine("C:", "Program Files (x86)", "Steam", "steamapps", "common", "Blasphemous 2"),
            "Blasphemous 2.exe",
            Path.Combine("MelonLoader", "net6", "MelonLoader.dll"),
            "https://github.com/BrandenEK/BlasII.ModdingTools/raw/main/modding-tools-windows.zip",
            "https://raw.githubusercontent.com/BrandenEK/BlasII.ModdingTools/main/modding-tools-windows.version");

        // Starters
        var blas1Starter = new Blas1Starter(blas1Validator);
        var blas2Starter = new Blas2Starter(blas2Validator);

        // Previewers
        var modPreviewer = new ModPreviewer(UIHandler.PreviewName, UIHandler.PreviewDescription, UIHandler.PreviewVersion);
        var skinPreviewer = new SkinPreviewer(UIHandler.PreviewBackground);

        var blas1modPage = new InstallerPage(blas1modTitle, Resources.background1,
            blas1modGrouper,
            blas1modLister,
            blas1modLoader,
            modPreviewer,
            blas1Validator,
            blas1Starter);

        var blas1skinPage = new InstallerPage(blas1skinTitle, Resources.background1,
            blas1skinGrouper,
            blas1skinLister,
            blas1skinLoader,
            skinPreviewer,
            blas1Validator,
            blas1Starter);

        var blas2modPage = new InstallerPage(blas2modTitle, Resources.background2,
            blas2modGrouper,
            blas2modLister,
            blas2modLoader,
            modPreviewer,
            blas2Validator,
            blas2Starter);

        _pages.Add(SectionType.Blas1Mods, blas1modPage);
        _pages.Add(SectionType.Blas1Skins, blas1skinPage);
        _pages.Add(SectionType.Blas2Mods, blas2modPage);
    }

    public static bool TempIgnoreTime { get; private set; }

    public static UIHandler UIHandler { get; private set; }
    public static SettingsHandler SettingsHandler { get; private set; }
    public static GithubHandler GithubHandler { get; private set; }

    private static readonly Dictionary<SectionType, InstallerPage> _pages = new();

    public static InstallerPage CurrentPage => _pages[SettingsHandler.Properties.CurrentSection];
    public static IEnumerable<InstallerPage> AllPages => _pages.Values;

    public static InstallerPage Blas1ModPage => _pages[SectionType.Blas1Mods];
    public static InstallerPage Blas1SkinPage => _pages[SectionType.Blas1Skins];
    public static InstallerPage Blas2ModPage => _pages[SectionType.Blas2Mods];

    public static string InstallerFolder { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BlasModInstaller");
    public static string CacheFolder { get; } = Path.Combine(InstallerFolder, "cache");
}
