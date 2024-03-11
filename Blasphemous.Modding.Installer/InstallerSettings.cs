
namespace Blasphemous.Modding.Installer;

public class InstallerSettings
{
    public string Blas1RootFolder { get; set; } = string.Empty;
    public string Blas2RootFolder { get; set; } = string.Empty;

    public SectionType CurrentSection { get; set; }
    public SortType Blas1ModSort { get; set; }
    public SortType Blas1SkinSort { get; set; }
    public SortType Blas2ModSort { get; set; }

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
        get => GetRootPath(CurrentSection);
        set => SetRootPath(CurrentSection, value);
    }

    // Sort type

    public SortType GetSort(SectionType section)
    {
        return section switch
        {
            SectionType.Blas1Mods => Blas1ModSort,
            SectionType.Blas1Skins => Blas1SkinSort,
            SectionType.Blas2Mods => Blas2ModSort,
            _ => throw new ArgumentException("Invalid section type", nameof(section))
        };
    }

    public void SetSort(SectionType section, SortType sort)
    {
        switch (section)
        {
            case SectionType.Blas1Mods: Blas1ModSort = sort; break;
            case SectionType.Blas1Skins: Blas1SkinSort = sort; break;
            case SectionType.Blas2Mods: Blas2ModSort = sort; break;
            default: throw new ArgumentException("Invalid section type", nameof(section));
        }
    }

    public SortType CurrentSort
    {
        get => GetSort(CurrentSection);
        set => SetSort(CurrentSection, value);
    }

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
        get => GetTime(CurrentSection);
        set => SetTime(CurrentSection, value);
    }
}
