using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;

namespace BlasModInstaller
{
    [Serializable]
    public class ModData
    {
        // This data will generally always stay the same
        public string Name { get; private set; }
        public string Author { get; private set; }
        public string Description { get; private set; }
        public string GithubAuthor { get; private set; }
        public string GithubRepo { get; private set; }
        public string PluginFile { get; private set; }
        public string[] RequiredDlls { get; private set; }
        // This data is set whenever loading mods from web
        public string LatestVersion { get; set; }
        public string LatestDownloadURL { get; set; }

        [JsonIgnore]
        public bool Installed => File.Exists(PathToEnabledPlugin) || File.Exists(PathToDisabledPlugin);
        [JsonIgnore]
        public bool Enabled => File.Exists(PathToEnabledPlugin);

        [JsonIgnore]
        public Version LocalVersion
        {
            get
            {
                string filePath;
                if (File.Exists(PathToEnabledPlugin))
                    filePath = PathToEnabledPlugin;
                else if (File.Exists(PathToDisabledPlugin))
                    filePath = PathToDisabledPlugin;
                else
                    return null;

                return new Version(FileVersionInfo.GetVersionInfo(filePath).FileVersion);
            }
        }

        [JsonIgnore]
        public bool UpdateAvailable
        {
            get
            {
                if (!Installed)
                    return false;

                return new Version(LatestVersion).CompareTo(LocalVersion) > 0;
            }
        }

        // Install paths
        [JsonIgnore]
        public string PathToEnabledPlugin => $"{MainForm.BlasRootFolder}\\Modding\\plugins\\{PluginFile}";
        [JsonIgnore]
        public string PathToDisabledPlugin => $"{MainForm.BlasRootFolder}\\Modding\\disabled\\{PluginFile}";
        [JsonIgnore]
        public string PathToConfigFile => $"{MainForm.BlasRootFolder}\\Modding\\config\\{Name}.cfg";
        [JsonIgnore]
        public string PathToDataFolder => $"{MainForm.BlasRootFolder}\\Modding\\data\\{Name}";
        [JsonIgnore]
        public string PathToKeybindingsFile => $"{MainForm.BlasRootFolder}\\Modding\\keybindings\\{Name}.txt";
        [JsonIgnore]
        public string PathToLevelsFolder => $"{MainForm.BlasRootFolder}\\Modding\\levels\\{Name}";
        [JsonIgnore]
        public string PathToLocalizationFile => $"{MainForm.BlasRootFolder}\\Modding\\localization\\{Name}.txt";
        [JsonIgnore]
        public string PathToLogFile => $"{MainForm.BlasRootFolder}\\Modding\\logs\\{Name}.log";
        [JsonIgnore]
        public string GithubLink => $"https://github.com/{GithubAuthor}/{GithubRepo}";

        public void UpdateLocalData(ModData globalMod)
        {
            // Name is already going to be the same
            Author = globalMod.Author;
            Description = globalMod.Description;
            GithubAuthor = globalMod.GithubAuthor;
            GithubRepo = globalMod.GithubRepo;
            PluginFile = globalMod.PluginFile;
            RequiredDlls = globalMod.RequiredDlls;
        }

        public bool RequiresDll(string dllName)
        {
            if (RequiredDlls == null) return false;

            foreach (string dll in RequiredDlls)
            {
                if (dll == dllName)
                    return true;
            }
            return false;
        }

        public ModData(string name, string author, string description, string githubAuthor, string githubRepo, string pluginFile, string[] requiredDlls)
        {
            Name = name;
            Author = author;
            Description = description;
            GithubAuthor = githubAuthor;
            GithubRepo = githubRepo;
            PluginFile = pluginFile;
            RequiredDlls = requiredDlls;
        }

        public override bool Equals(object obj)
        {
            if (obj is ModData mod)
                return Name == mod.Name;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static string CleanSemanticVersion(string version)
        {
            return version.ToLower().Replace("v", "");
        }
    }
}
