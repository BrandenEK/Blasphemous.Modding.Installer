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

        public string Version { get; set; }

        public Mod(string name, string author, string description, string githubAuthor, string githubRepo, string pluginFile)
        {
            Name = name;
            Author = author;
            Description = description;
            GithubAuthor = githubAuthor;
            GithubRepo = githubRepo;
            PluginFile = pluginFile;
        }

        public void CopyData(Mod other)
        {
            // Name is already going to be the same
            Author = other.Author;
            Description = other.Description;
            GithubAuthor = other.GithubAuthor;
            GithubRepo = other.GithubRepo;
            PluginFile = other.PluginFile;
        }
    }
}
