using System;

namespace BlasModInstaller
{
    [Serializable]
    public class Config
    {
        public string Blas1RootFolder { get; set; }
        public string Blas2RootFolder { get; set; }
        public string GithubToken { get; set; }
        public SectionType LastSection { get; set; }
        public SortType Blas1ModSort { get; set; }
        public SortType Blas1SkinSort { get; set; }
        public SortType Blas2ModSort { get; set; }
    }
}
