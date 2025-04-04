﻿using Basalt.BetterForms;
using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.Mods;
using Blasphemous.Modding.Installer.PageComponents.Filters;
using Blasphemous.Modding.Installer.PageComponents.Groupers;
using Blasphemous.Modding.Installer.PageComponents.Listers;
using Blasphemous.Modding.Installer.PageComponents.Loaders;
using Blasphemous.Modding.Installer.PageComponents.Sorters;
using Blasphemous.Modding.Installer.PageComponents.Starters;
using Blasphemous.Modding.Installer.PageComponents.Validators;
using Blasphemous.Modding.Installer.PageComponents.Validators.IconLoaders;
using Blasphemous.Modding.Installer.Properties;
using Blasphemous.Modding.Installer.Skins;

namespace Blasphemous.Modding.Installer;

static class Core
{
    [STAThread]
    static void Main()
    {
        BasaltApplication.Run<UIHandler, InstallerCommand, InstallerSettings>(InitializeCore, "Blasphemous Mod Installer", new string[]
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
        foreach (var file in Directory.GetFiles(InstallerFolder).Where(x => Path.GetExtension(x) != ".log" && Path.GetExtension(x) != ".cfg"))
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

    static void InitializeCore(UIHandler form, InstallerCommand cmd, InstallerSettings settings)
    {
        TemporaryClearDataFolder();

        TempConfig = settings;
        var blas1gameSettings = settings.GetGameSettings("blas1");
        var blas2gameSettings = settings.GetGameSettings("blas2");
        var blas1modPageSettings = settings.GetPageSettings("blas1mods");
        var blas1skinPageSettings = settings.GetPageSettings("blas1skins");
        var blas2modPageSettings = settings.GetPageSettings("blas2mods");

        UIHandler = form;
        GithubHandler = new GithubHandler(cmd.GithubToken);

        IIconLoader iconLoader = new EmbeddedIconLoader();

        List<Mod> blas1mods = new List<Mod>();
        List<Skin> blas1skins = new List<Skin>();
        List<Mod> blas2mods = new List<Mod>();

        string blas1modTitle = "Blasphemous Mods";
        string blas1skinTitle = "Blasphemous Skins";
        string blas2modTitle = "Blasphemous II Mods";

        // Sorters
        var blas1modSorter = new ModSorter(blas1modPageSettings);
        var blas1skinSorter = new SkinSorter(blas1skinPageSettings);
        var blas2modSorter = new ModSorter(blas2modPageSettings);

        // Filters
        var blas1modFilter = new ModFilter(blas1modPageSettings);
        var blas1skinFilter = new SkinFilter(blas1skinPageSettings);
        var blas2modFilter = new ModFilter(blas2modPageSettings);

        // Groupers
        var blas1modGrouper = new ModGrouper(blas1modTitle, blas1mods, blas1modFilter);
        var blas1skinGrouper = new SkinGrouper(blas1skinTitle, blas1skins, blas1skinFilter);
        var blas2modGrouper = new ModGrouper(blas2modTitle, blas2mods, blas2modFilter);

        // Listers
        var blas1modLister = new ModLister(UIHandler.DataHolder, blas1mods, blas1modSorter, blas1modFilter);
        var blas1skinLister = new SkinLister(UIHandler.DataHolder, blas1skins, blas1skinSorter, blas1skinFilter);
        var blas2modLister = new ModLister(UIHandler.DataHolder, blas2mods, blas2modSorter, blas2modFilter);

        // Loaders
        var blas1modLoader = new ModLoader(
            "https://raw.githubusercontent.com/BrandenEK/Blasphemous.Modding.Installer/main/BlasphemousMods.json",
            cmd.IgnoreTime,
            blas1modLister,
            blas1mods,
            SectionType.Blas1Mods,
            blas1modPageSettings,
            blas1gameSettings);
        var blas1skinLoader = new SkinLoader(
            "blasphemous1",
            cmd.IgnoreTime,
            blas1skinLister,
            blas1skins,
            SectionType.Blas1Skins,
            blas1skinPageSettings,
            blas1gameSettings);
        var blas2modLoader = new ModLoader(
            "https://raw.githubusercontent.com/BrandenEK/Blasphemous.Modding.Installer/main/BlasphemousIIMods.json",
            cmd.IgnoreTime,
            blas2modLister,
            blas2mods,
            SectionType.Blas2Mods,
            blas2modPageSettings,
            blas2gameSettings);

        // Validators
        var blas1Validator = new StandardValidator(
            Path.Combine("C:", "Program Files (x86)", "Steam", "steamapps", "common", "Blasphemous"),
            "Blasphemous.exe",
            Path.Combine("BepInEx", "patchers", "BepInEx.MultiFolderLoader.dll"),
            "https://github.com/BrandenEK/Blasphemous.ModdingTools/raw/main/modding-tools-windows.zip",
            "https://raw.githubusercontent.com/BrandenEK/Blasphemous.ModdingTools/main/modding-tools-windows.version",
            iconLoader,
            blas1gameSettings);
        var blas2Validator = new StandardValidator(
            Path.Combine("C:", "Program Files (x86)", "Steam", "steamapps", "common", "Blasphemous 2"),
            "Blasphemous 2.exe",
            Path.Combine("MelonLoader", "net6", "MelonLoader.dll"),
            "https://github.com/BrandenEK/BlasII.ModdingTools/raw/main/modding-tools-windows.zip",
            "https://raw.githubusercontent.com/BrandenEK/BlasII.ModdingTools/main/modding-tools-windows.version",
            iconLoader, blas2gameSettings);

        // Starters
        var blas1Starter = new Blas1Starter(blas1Validator, blas1gameSettings);
        var blas2Starter = new Blas2Starter(blas2Validator, blas2gameSettings);

        var blas1modPage = new InstallerPage(blas1modTitle, Resources.background1,
            blas1modGrouper,
            blas1modLister,
            blas1modLoader,
            blas1Validator,
            blas1Starter,
            blas1modPageSettings,
            blas1gameSettings);

        var blas1skinPage = new InstallerPage(blas1skinTitle, Resources.background1,
            blas1skinGrouper,
            blas1skinLister,
            blas1skinLoader,
            blas1Validator,
            blas1Starter,
            blas1skinPageSettings,
            blas1gameSettings);

        var blas2modPage = new InstallerPage(blas2modTitle, Resources.background2,
            blas2modGrouper,
            blas2modLister,
            blas2modLoader,
            blas2Validator,
            blas2Starter,
            blas2modPageSettings,
            blas2gameSettings);

        _pages.Add(SectionType.Blas1Mods, blas1modPage);
        _pages.Add(SectionType.Blas1Skins, blas1skinPage);
        _pages.Add(SectionType.Blas2Mods, blas2modPage);
    }

    // Config

    public static InstallerSettings TempConfig { get; private set; } = new();

    public static UIHandler UIHandler { get; private set; }
    public static GithubHandler GithubHandler { get; private set; }

    private static readonly Dictionary<SectionType, InstallerPage> _pages = new();

    public static InstallerPage CurrentPage => _pages[TempConfig.LastSection];
    public static IEnumerable<InstallerPage> AllPages => _pages.Values;

    public static InstallerPage Blas1ModPage => _pages[SectionType.Blas1Mods];
    public static InstallerPage Blas1SkinPage => _pages[SectionType.Blas1Skins];
    public static InstallerPage Blas2ModPage => _pages[SectionType.Blas2Mods];

    public static string InstallerFolder { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BlasModInstaller");
    public static string CacheFolder { get; } = Path.Combine(InstallerFolder, "cache");
}
