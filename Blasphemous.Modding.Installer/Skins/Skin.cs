using System.Net;

namespace Blasphemous.Modding.Installer.Skins;

internal class Skin : IComparable
{
    private readonly SkinUI _ui;
    private readonly SectionType _skinType;

    private bool _downloading;

    public Skin(SkinData data, Panel panel, SectionType skinType)
    {
        Data = data;
        _skinType = skinType;
        _ui = new SkinUI(this, panel);
        SetUIPosition(-1);
        UpdateUI();
        SkinPage.UIHolder.AdjustPageWidth();
    }

    public SkinData Data { get; set; }

    private InstallerPage SkinPage => Core.Blas1SkinPage;
    private SortType SkinSort => Core.SettingsHandler.Config.Blas1SkinSort;

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

    private string RootFolder => Core.SettingsHandler.GetRootPathBySection(_skinType);
    public string PathToSkinFolder => $"{RootFolder}/Modding/skins/{Data.id}";

    private string SubFolder => "blasphemous1";
    public string InfoURL => $"https://raw.githubusercontent.com/BrandenEK/Blasphemous-Custom-Skins/main/{SubFolder}/{Data.id}/info.txt";
    public string TextureURL => $"https://raw.githubusercontent.com/BrandenEK/Blasphemous-Custom-Skins/main/{SubFolder}/{Data.id}/texture.png";
    public string PreviewURL => $"https://raw.githubusercontent.com/BrandenEK/Blasphemous-Custom-Skins/main/{SubFolder}/{Data.id}/preview.png";

    public bool ExistsInCache(string fileName, out string cachePath)
    {
        cachePath = $"{Core.DataCache}/blas1skins/{Data.id}/{Data.version}/{fileName}";
        Directory.CreateDirectory(Path.GetDirectoryName(cachePath));

        return File.Exists(cachePath) && new FileInfo(cachePath).Length > 0;
    }

    // Main methods

    public async void Install()
    {
        string installPath = PathToSkinFolder;
        Directory.CreateDirectory(installPath);

        // Check for files in the cache
        bool infoExists = ExistsInCache("info.txt", out string infoCache);
        bool textureExists = ExistsInCache("texture.png", out string textureCache);

        // If they were missing, download them from web to cache
        if (!infoExists || !textureExists)
        {
            await DownloadSkin(infoCache, textureCache);
        }

        // Copy files from cache to game folder
        File.Copy(infoCache, installPath + "/info.txt");
        File.Copy(textureCache, installPath + "/texture.png");

        UpdateUI();
    }

    private async Task DownloadSkin(string infoCache, string textureCache)
    {
        Logger.Warn($"Downloading skin texture ({Data.name}) from web");
        using (WebClient client = new WebClient())
        {
            _downloading = true;
            _ui.ShowDownloadingStatus();

            await client.DownloadFileTaskAsync(new Uri(InfoURL), infoCache);
            await client.DownloadFileTaskAsync(new Uri(TextureURL), textureCache);

            _downloading = false;
        }
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

    public void MouseEnter(object sender, EventArgs e) => SkinPage.Previewer.PreviewSkin(this);

    public void MouseLeave(object sender, EventArgs e) => SkinPage.Previewer.Clear();

    // Sorting methods

    public int CompareTo(object obj) => SortBy(obj as Skin, SkinSort);

    public int SortBy(Skin skin, SortType sort)
    {
        if (sort == SortType.Name)
        {
            return Data.name.CompareTo(skin.Data.name);
        }
        else if (sort == SortType.Author)
        {
            int difference = Data.author.CompareTo(skin.Data.author);
            return difference == 0 ? SortBy(skin, SortType.Name) : difference;
        }
        return 0;
    }
}
