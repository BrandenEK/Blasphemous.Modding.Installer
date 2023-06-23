using System;

namespace BlasModInstaller
{
    [Serializable]
    public class Config
    {
        public string BlasRootFolder { get; set; }
        public string BlasIIRootFolder { get; set; }
        public string GithubToken { get; set; }
        public bool DebugMode { get; set; }
        public SectionType LastSection { get; set; }
        public SortType BlasModSort { get; set; }
        public SortType BlasSkinSort { get; set; }
        public SortType BlasIIModSort { get; set; }
    }
}
