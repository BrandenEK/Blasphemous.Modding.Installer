using Octokit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlasModInstaller
{
    internal class GithubHandler
    {
        private readonly GitHubClient _client;
        private string _installerLatestReleaseLink;

        /// <summary>
        /// Initializes a new github client and checks for a newer version of the installer
        /// </summary>
        public GithubHandler(string githubToken)
        {
            _client = CreateGithubClient(githubToken);
            CheckForNewerInstallerRelease();
        }

        /// <summary>
        /// Returns the lastest release version of the specified repository
        /// </summary>
        public async Task<Release> GetLatestRelease(string owner, string repo)
        {
            return await _client.Repository.Release.GetLatest(owner, repo);
        }

        /// <summary>
        /// Returns the entire contents of the specified repository
        /// </summary>
        public async Task<IReadOnlyList<RepositoryContent>> GetRepositoryContents(string owner, string repo)
        {
            return await _client.Repository.Content.GetAllContents(owner, repo);
        }

        /// <summary>
        /// Returns the contents of a directory in a repository
        /// </summary>
        public async Task<IReadOnlyList<RepositoryContent>> GetRepositoryDirectory(string owner, string repo, string path)
        {
            return await _client.Repository.Content.GetAllContents(owner, repo, path);
        }

        /// <summary>
        /// Creates a new github client with the token
        /// </summary>
        private GitHubClient CreateGithubClient(string githubToken)
        {
            GitHubClient client = new GitHubClient(new ProductHeaderValue("BlasModInstaller"));

            if (!string.IsNullOrEmpty(githubToken))
            {
                client.Credentials = new Credentials(githubToken);
            }

            return client;
        }

        /// <summary>
        /// When starting the installer, check if there is a more recent version, and if so display the update panel
        /// </summary>
        /// <returns></returns>
        private async Task CheckForNewerInstallerRelease()
        {
            Release latestRelease = await GetLatestRelease("BrandenEK", "Blasphemous-Mod-Installer");
            Version newestVersion = CleanSemanticVersion(latestRelease.TagName);

            if (newestVersion.CompareTo(Core.CurrentInstallerVersion) > 0)
            {
                _installerLatestReleaseLink = latestRelease.HtmlUrl;
                Core.UIHandler.UpdatePanelSetVisible(true);
            }

            Core.UIHandler.Log("Remaining api calls: " + (_client.GetLastApiInfo()?.RateLimit.Remaining + 1));
        }

        /// <summary>
        /// When clicking the link in the update panel, open the installer's latest release page
        /// </summary>
        public void OpenInstallerLink()
        {
            try
            {
                Process.Start(_installerLatestReleaseLink);
            }
            catch (Exception)
            {
                MessageBox.Show("Link does not exist!", "Invalid Link");
            }
        }

        /// <summary>
        /// Strips out the 'v' and ensures it is a valid version
        /// </summary>
        public static Version CleanSemanticVersion(string version)
        {
            try
            {
                return new Version(version.ToLower().Replace("v", ""));
            }
            catch (Exception)
            {
                return new Version(0, 1, 0);
            }
        }
    }
}
