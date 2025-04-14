using Basalt.Framework.Logging;
using Blasphemous.Modding.Installer.Extensions;
using Newtonsoft.Json;

namespace Blasphemous.Modding.Installer.Skins;

internal class Skin
{
    private readonly SkinUI _ui;
    private readonly SectionType _skinType;
    private readonly GameSettings _settings;

    private bool _downloading;

    public Skin(SkinData data, SectionType skinType, GameSettings settings)
    {
        Data = data;
        _skinType = skinType;
        _settings = settings;
        _ui = new SkinUI(this);
        SetUIVisibility(false);
        SetUIPosition(-1);
        UpdateUI();
    }

    public SkinData Data { get; set; }

    private InstallerPage SkinPage => _skinType == SectionType.Blas1Skins
        ? Core.Blas1SkinPage
        : Core.Blas2SkinPage;

    public bool Installed => File.Exists(PathToSkinFolder + "/info.txt");

    public Version LocalVersion
    {
        get
        {
            string infoPath = PathToSkinFolder + "/info.txt";
            if (Installed)
            {
                SkinData data = JsonConvert.DeserializeObject<SkinData>(File.ReadAllText(infoPath));
                return GithubHandler.CleanSemanticVersion(data.version);
            }
            else
            {
                return null;
            }
        }
    }

    public bool UpdateAvailable
    {
        get
        {
            if (!Installed)
                return false;

            return GithubHandler.CleanSemanticVersion(Data.version).CompareTo(LocalVersion) > 0;
        }
    }

    // Paths

    private string RootFolder => _settings.RootFolder;
    public string PathToSkinFolder => $"{RootFolder}/Modding/skins/{Data.id}";

    public string GithubSubFolder => _skinType == SectionType.Blas1Skins ? "blasphemous1" : "blasphemous2";
    public string CacheSubFolder => _skinType == SectionType.Blas1Skins ? "blas1skins" : "blas2skins";

    public string InfoURL => $"https://raw.githubusercontent.com/BrandenEK/Blasphemous.Community.Skins/main/{GithubSubFolder}/{Data.id}/info.txt";
    public string TextureURL => $"https://raw.githubusercontent.com/BrandenEK/Blasphemous.Community.Skins/main/{GithubSubFolder}/{Data.id}/texture.png";
    public string PreviewURL => $"https://raw.githubusercontent.com/BrandenEK/Blasphemous.Community.Skins/main/{GithubSubFolder}/{Data.id}/preview.png";

    public bool ExistsInCache(string fileName, out string cachePath)
    {
        cachePath = $"{Core.CacheFolder}/{CacheSubFolder}/{Data.id}/{Data.version}/{fileName}";
        Directory.CreateDirectory(Path.GetDirectoryName(cachePath));

        return File.Exists(cachePath) && new FileInfo(cachePath).Length > 0;
    }

    // Main methods

    public async void Install()
    {
        // Very hacky solution to blas2 skins being downloaded differently, but I didn't have time to implement it good
        // Ideally there will be an IWorker with two different implementors for the skins

        if (_skinType == SectionType.Blas1Skins)
        {
            InstallBlas1Skin();
        }
        else if (_skinType == SectionType.Blas2Skins)
        {
            InstallBlas2Skin();
        }
    }

    private async void InstallBlas1Skin()
    {
        string installPath = PathToSkinFolder;
        Directory.CreateDirectory(installPath);

        // Check for files in the cache
        bool infoExists = ExistsInCache("info.txt", out string infoCache);
        bool textureExists = ExistsInCache("texture.png", out string textureCache);

        // If they were missing, download them from web to cache
        if (!infoExists || !textureExists)
        {
            await DownloadBlas1Skin(infoCache, textureCache);
        }

        // Copy files from cache to game folder
        File.Copy(infoCache, installPath + "/info.txt");
        File.Copy(textureCache, installPath + "/texture.png");

        UpdateUI();
    }

    private async Task DownloadBlas1Skin(string infoCache, string textureCache)
    {
        Logger.Warn($"Downloading skin texture ({Data.name}) from web");
        using var client = new HttpClient();

        _downloading = true;
        _ui.ShowDownloadingStatus();

        await client.DownloadFileAsync(new Uri(InfoURL), infoCache);
        await client.DownloadFileAsync(new Uri(TextureURL), textureCache);

        _downloading = false;
    }

    private async void InstallBlas2Skin()
    {
        Logger.Warn("Downloading blas2skin" + Data.name);
    }

    public void Uninstall()
    {
        if (Directory.Exists(PathToSkinFolder))
            Directory.Delete(PathToSkinFolder, true);

        UpdateUI();
    }

    // Click methods

    public void ClickedInstall(object sender, EventArgs e)
    {
        if (_downloading) return;

        if (Installed)
        {
            if (MessageBox.Show("Are you sure you want to uninstall this skin?", Data.name, MessageBoxButtons.OKCancel) == DialogResult.OK)
                Uninstall();
        }
        else
        {
            Install();
        }
    }

    public void ClickedUpdate(object sender, EventArgs e)
    {
        Uninstall();
        Install();
    }

    // UI methods

    public void UpdateUI()
    {
        _ui.UpdateUI(Data.name, Data.author, Installed, UpdateAvailable);
    }

    public void SetUIPosition(int skinIdx)
    {
        _ui.SetPosition(skinIdx);
    }

    public void SetUIVisibility(bool visible)
    {
        _ui.SetVisibility(visible);
    }
}
