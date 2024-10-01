
namespace Blasphemous.Modding.Installer;

public class OldSettings
{
    public string Blas1RootFolder { get; set; } = string.Empty;
    public string Blas2RootFolder { get; set; } = string.Empty;
    //public SectionType CurrentSection { get; set; }

    public LaunchOptions Blas1Launch { get; set; }
    public LaunchOptions Blas2Launch { get; set; }

    //public SortType Blas1ModSort { get; set; }
    //public SortType Blas1SkinSort { get; set; }
    //public SortType Blas2ModSort { get; set; }

    //public FilterType Blas1ModFilter { get; set; }
    //public FilterType Blas1SkinFilter { get; set; }
    //public FilterType Blas2ModFilter { get; set; }

    public DateTime Blas1ModTime { get; set; }
    public DateTime Blas1SkinTime { get; set; }
    public DateTime Blas2ModTime { get; set; }

    // Root path

    public string GetRootPath(SectionType section)
    {
        return section switch
        {
            SectionType.Blas1Mods => Blas1RootFolder,
            SectionType.Blas1Skins => Blas1RootFolder,
            SectionType.Blas2Mods => Blas2RootFolder,
            _ => throw new ArgumentException("Invalid section type", nameof(section))
        };
    }

    public void SetRootPath(SectionType section, string path)
    {
        switch (section)
        {
            case SectionType.Blas1Mods: Blas1RootFolder = path; break;
            case SectionType.Blas1Skins: Blas1RootFolder = path; break;
            case SectionType.Blas2Mods: Blas2RootFolder = path; break;
            default: throw new ArgumentException("Invalid section type", nameof(section));
        }
    }

    public string CurrentRootPath
    {
        get => GetRootPath(Core.TempConfig.LastSection);
        set => SetRootPath(Core.TempConfig.LastSection, value);
    }

    // Launch options

    public LaunchOptions GetLaunchOptions(SectionType section)
    {
        return section switch
        {
            SectionType.Blas1Mods => Blas1Launch,
            SectionType.Blas1Skins => Blas1Launch,
            SectionType.Blas2Mods => Blas2Launch,
            _ => throw new ArgumentException("Invalid section type", nameof(section))
        };
    }

    public void SetLaunchOptions(SectionType section, LaunchOptions launch)
    {
        switch (section)
        {
            case SectionType.Blas1Mods: Blas1Launch = launch; break;
            case SectionType.Blas1Skins: Blas1Launch = launch; break;
            case SectionType.Blas2Mods: Blas2Launch = launch; break;
            default: throw new ArgumentException("Invalid section type", nameof(section));
        }
    }

    public LaunchOptions CurrentLaunchOptions
    {
        get => GetLaunchOptions(Core.TempConfig.LastSection);
        set => SetLaunchOptions(Core.TempConfig.LastSection, value);
    }

    // Sort type

    //public SortType GetSort(SectionType section)
    //{
    //    return section switch
    //    {
    //        SectionType.Blas1Mods => Blas1ModSort,
    //        SectionType.Blas1Skins => Blas1SkinSort,
    //        SectionType.Blas2Mods => Blas2ModSort,
    //        _ => throw new ArgumentException("Invalid section type", nameof(section))
    //    };
    //}

    //public void SetSort(SectionType section, SortType sort)
    //{
    //    switch (section)
    //    {
    //        case SectionType.Blas1Mods: Blas1ModSort = sort; break;
    //        case SectionType.Blas1Skins: Blas1SkinSort = sort; break;
    //        case SectionType.Blas2Mods: Blas2ModSort = sort; break;
    //        default: throw new ArgumentException("Invalid section type", nameof(section));
    //    }
    //}

    //public SortType CurrentSort
    //{
    //    get => GetSort(Core.TempConfig.LastSection);
    //    set => SetSort(Core.TempConfig.LastSection, value);
    //}

    // Filter type

    //public FilterType GetFilter(SectionType section)
    //{
    //    return section switch
    //    {
    //        SectionType.Blas1Mods => Blas1ModFilter,
    //        SectionType.Blas1Skins => Blas1SkinFilter,
    //        SectionType.Blas2Mods => Blas2ModFilter,
    //        _ => throw new ArgumentException("Invalid section type", nameof(section))
    //    };
    //}

    //public void SetFilter(SectionType section, FilterType filter)
    //{
    //    switch (section)
    //    {
    //        case SectionType.Blas1Mods: Blas1ModFilter = filter; break;
    //        case SectionType.Blas1Skins: Blas1SkinFilter = filter; break;
    //        case SectionType.Blas2Mods: Blas2ModFilter = filter; break;
    //        default: throw new ArgumentException("Invalid section type", nameof(section));
    //    }
    //}

    //public FilterType CurrentFilter
    //{
    //    get => GetFilter(Core.TempConfig.LastSection);
    //    set => SetFilter(Core.TempConfig.LastSection, value);
    //}

    // Update time

    public DateTime GetTime(SectionType section)
    {
        return section switch
        {
            SectionType.Blas1Mods => Blas1ModTime,
            SectionType.Blas1Skins => Blas1SkinTime,
            SectionType.Blas2Mods => Blas2ModTime,
            _ => throw new ArgumentException("Invalid section type", nameof(section))
        };
    }

    public void SetTime(SectionType section, DateTime time)
    {
        switch (section)
        {
            case SectionType.Blas1Mods: Blas1ModTime = time; break;
            case SectionType.Blas1Skins: Blas1SkinTime = time; break;
            case SectionType.Blas2Mods: Blas2ModTime = time; break;
            default: throw new ArgumentException("Invalid section type", nameof(section));
        }
    }

    public DateTime CurrentTime
    {
        get => GetTime(Core.TempConfig.LastSection);
        set => SetTime(Core.TempConfig.LastSection, value);
    }
}

public struct LaunchOptions
{
    public bool RunModded { get; set; }
    public bool RunConsole { get; set; }

    public LaunchOptions(bool runModded, bool runConsole)
    {
        RunModded = runModded;
        RunConsole = runConsole;
    }
}
