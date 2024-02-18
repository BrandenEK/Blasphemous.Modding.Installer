namespace Blasphemous.Modding.Installer;

[Serializable]
public class OldConfig
{
    public string? Blas1RootFolder { get; set; }
    public string? Blas2RootFolder { get; set; }
    public string? GithubToken { get; set; }

    public static OldConfig TempCreateFromSetttings(InstallerSettings settings)
    {
        return new OldConfig()
        {
            Blas1RootFolder = settings.Blas1RootFolder,
            Blas2RootFolder = settings.Blas2RootFolder,
            GithubToken = settings.GithubToken
        };
    }
    //public SectionType LastSection { get; set; }
    //public SortType Blas1ModSort { get; set; }
    //public SortType Blas1SkinSort { get; set; }
    //public SortType Blas2ModSort { get; set; }
}

public class InstallerSettings
{
    public string? Blas1RootFolder { get; set; }
    public string? Blas2RootFolder { get; set; }
    public string? GithubToken { get; set; }

    public SectionType CurrentSection { get; set; }
    public SortType Blas1ModSort { get; set; }
    public SortType Blas1SkinSort { get; set; }
    public SortType Blas2ModSort { get; set; }

    public SortType CurrentSort
    {
        get
        {
            return CurrentSection switch
            {
                SectionType.Blas1Mods => Blas1ModSort,
                SectionType.Blas1Skins => Blas1SkinSort,
                SectionType.Blas2Mods => Blas2ModSort,
                _ => SortType.Name,
            };
        }
        set
        {
            switch (CurrentSection)
            {
                case SectionType.Blas1Mods: Blas1ModSort = value; break;
                case SectionType.Blas1Skins: Blas1SkinSort = value; break;
                case SectionType.Blas2Mods: Blas2ModSort = value; break;
            }
        }
    }

    public string? GetRootPathBySection(SectionType section)
    {
        return section switch
        {
            SectionType.Blas1Mods => Blas1RootFolder,
            SectionType.Blas1Skins => Blas1RootFolder,
            SectionType.Blas2Mods => Blas2RootFolder,
            _ => null,
        };
    }
}
