using Newtonsoft.Json;

namespace Blasphemous.Modding.Installer.Mods;

internal class ModData
{
    // These properties are determined from the mod list
    [JsonProperty] public readonly string name;
    [JsonProperty] public readonly string author;
    [JsonProperty] public readonly string description;
    [JsonProperty] public readonly DateTimeOffset initialReleaseDate;
    [JsonProperty] public readonly string githubAuthor;
    [JsonProperty] public readonly string githubRepo;
    [JsonProperty] public readonly string pluginFile;
    [JsonProperty] public readonly string[] requiredDlls;
    [JsonProperty] public readonly string[] dependencies;

    // These properties are determined from the github release
    [JsonProperty] public readonly string latestVersion;
    [JsonProperty] public readonly string latestDownloadURL;
    [JsonProperty] public readonly DateTimeOffset latestReleaseDate;

    [JsonConstructor]
    public ModData(string name, string author, string description, DateTimeOffset initialReleaseDate, string githubAuthor, string githubRepo, string pluginFile, string[] requiredDlls, string[] dependencies, string latestVersion, string latestDownloadURL, DateTimeOffset latestReleaseDate)
    {
        this.name = name;
        this.author = author;
        this.description = description;
        this.initialReleaseDate = initialReleaseDate;
        this.githubAuthor = githubAuthor;
        this.githubRepo = githubRepo;
        this.pluginFile = pluginFile;
        this.requiredDlls = requiredDlls;
        this.dependencies = dependencies;
        this.latestVersion = latestVersion;
        this.latestDownloadURL = latestDownloadURL;
        this.latestReleaseDate = latestReleaseDate;
    }

    public ModData(ModData data, string latestVersion, string latestDownloadURL, DateTimeOffset latestReleaseDate)
    {
        name = data.name;
        author = data.author;
        description = data.description;
        initialReleaseDate = data.initialReleaseDate;
        githubAuthor = data.githubAuthor;
        githubRepo = data.githubRepo;
        pluginFile = data.pluginFile;
        requiredDlls = data.requiredDlls;
        dependencies = data.dependencies;
        this.latestVersion = latestVersion;
        this.latestDownloadURL = latestDownloadURL;
        this.latestReleaseDate = latestReleaseDate;
    }
}
