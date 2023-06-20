using System;

namespace BlasModInstaller
{
    [Serializable]
    public class Config
    {
        public string BlasRootFolder { get; set; }
        public string BlasIIRootFolder { get; set; }
        public string GithubToken { get; set; }
        public SectionType LastSection { get; set; }
    }
}
