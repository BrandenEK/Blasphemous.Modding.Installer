using System;

namespace BlasModInstaller
{
    [Serializable]
    public class Mod
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public string Description { get; private set; }
        public string GithubAuthor { get; private set; }
        public string GithubRepo { get; private set; }
        public string PluginFile { get; private set; }
        public string[] RequiredDlls { get; private set; }

        public string Version { get; set; }

        public Mod(string name, string author, string description, string githubAuthor, string githubRepo, string pluginFile, string[] requiredDlls)
        {
            Name = name;
            Author = author;
            Description = description;
            GithubAuthor = githubAuthor;
            GithubRepo = githubRepo;
            PluginFile = pluginFile;
            RequiredDlls = requiredDlls;
        }

        public void CopyData(Mod other)
        {
            // Name is already going to be the same
            Author = other.Author;
            Description = other.Description;
            GithubAuthor = other.GithubAuthor;
            GithubRepo = other.GithubRepo;
            PluginFile = other.PluginFile;
            RequiredDlls = other.RequiredDlls;
        }

        // Install paths
        public string PathToEnabledPlugin => $"{MainForm.BlasExePath}\\Modding\\plugins\\{PluginFile}";
        public string PathToDisabledPlugin => $"{MainForm.BlasExePath}\\Modding\\disabled\\{PluginFile}";
        public string PathToConfigFile => $"{MainForm.BlasExePath}\\Modding\\config\\{Name}.cfg";
        public string PathToLocalizationFile => $"{MainForm.BlasExePath}\\Modding\\localization\\{Name}.txt";
        public string PathToLogFile => $"{MainForm.BlasExePath}\\Modding\\logs\\{Name}.log";
        public string PathToDataFolder => $"{MainForm.BlasExePath}\\Modding\\data\\{Name}";
        public string PathToLevelsFolder => $"{MainForm.BlasExePath}\\Modding\\levels\\{Name}";
    }
}
