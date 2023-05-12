using System;
using Newtonsoft.Json;

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

        private ModHolder m_UI;
        [JsonIgnore]
        public ModHolder UI
        {
            get
            {
                if (m_UI == null)
                    m_UI = new ModHolder(this);
                return m_UI;
            }
        }

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
        [JsonIgnore]
        public string PathToEnabledPlugin => $"{MainForm.BlasExePath}\\Modding\\plugins\\{PluginFile}";
        [JsonIgnore]
        public string PathToDisabledPlugin => $"{MainForm.BlasExePath}\\Modding\\disabled\\{PluginFile}";
        [JsonIgnore]
        public string PathToConfigFile => $"{MainForm.BlasExePath}\\Modding\\config\\{Name}.cfg";
        [JsonIgnore]
        public string PathToLocalizationFile => $"{MainForm.BlasExePath}\\Modding\\localization\\{Name}.txt";
        [JsonIgnore]
        public string PathToLogFile => $"{MainForm.BlasExePath}\\Modding\\logs\\{Name}.log";
        [JsonIgnore]
        public string PathToDataFolder => $"{MainForm.BlasExePath}\\Modding\\data\\{Name}";
        [JsonIgnore]
        public string PathToLevelsFolder => $"{MainForm.BlasExePath}\\Modding\\levels\\{Name}";
    }
}
