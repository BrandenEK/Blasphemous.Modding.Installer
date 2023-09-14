using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlasModInstaller.Skins
{
    [Serializable]
    public class Skin : IComparable
    {
        // Data

        public string id;
        public string name;
        public string author;
        public string version; // This is the most recent version and is updated whenever loading global skins

        [JsonIgnore] private bool _downloading;
        [JsonIgnore] private SkinUI _ui;

        public void UpdateLocalData(Skin globalSkin)
        {
            // Id is already going to be the same
            name = globalSkin.name;
            author = globalSkin.author;
            version = globalSkin.version;
        }

        public override int GetHashCode() => base.GetHashCode();
        public override bool Equals(object obj)
        {
            if (obj is Skin skin)
                return id == skin.id;
            return base.Equals(obj);
        }

        [JsonIgnore] public bool Installed => File.Exists($"{Core.SettingsHandler.Config.Blas1RootFolder}\\Modding\\skins\\{id}\\info.txt");

        [JsonIgnore]
        public Version LocalVersion
        {
            get
            {
                string infoPath = PathToSkinFolder + "\\info.txt";
                if (File.Exists(infoPath))
                {
                    Skin data = JsonConvert.DeserializeObject<Skin>(File.ReadAllText(infoPath));
                    return GithubHandler.CleanSemanticVersion(data.version);
                }
                else
                {
                    return null;
                }
            }
        }

        [JsonIgnore]
        public bool UpdateAvailable
        {
            get
            {
                if (!Installed)
                    return false;

                return GithubHandler.CleanSemanticVersion(version).CompareTo(LocalVersion) > 0;
            }
        }

        // Paths

        [JsonIgnore]
        public string PathToSkinFolder => $"{Core.SettingsHandler.Config.Blas1RootFolder}\\Modding\\skins\\{id}";
        [JsonIgnore]
        public string InfoURL => $"https://raw.githubusercontent.com/BrandenEK/Blasphemous-Custom-Skins/main/{id}/info.txt";
        [JsonIgnore]
        public string TextureURL => $"https://raw.githubusercontent.com/BrandenEK/Blasphemous-Custom-Skins/main/{id}/texture.png";
        [JsonIgnore]
        public string IdlePreviewURL => $"https://github.com/BrandenEK/Blasphemous-Custom-Skins/blob/main/{id}/idlePreview.png";
        [JsonIgnore]
        public string ChargedPreviewURL => $"https://github.com/BrandenEK/Blasphemous-Custom-Skins/blob/main/{id}/chargedPreview.png";

        // Main methods

        public async Task Install()
        {
            _downloading = true;
            using (WebClient client = new WebClient())
            {
                _ui.ShowDownloadingStatus();

                string downloadPath = $"{UIHandler.DownloadsPath}{id}";
                Directory.CreateDirectory(downloadPath);

                await client.DownloadFileTaskAsync(new Uri(InfoURL), downloadPath + "\\info.txt");
                await client.DownloadFileTaskAsync(new Uri(TextureURL), downloadPath + "\\texture.png");

                string installPath = PathToSkinFolder;
                Directory.CreateDirectory(installPath);
                File.Copy(downloadPath + "\\info.txt", installPath + "\\info.txt");
                File.Copy(downloadPath + "\\texture.png", installPath + "\\texture.png");

                Directory.Delete(downloadPath, true);
            }
            _downloading = false;

            UpdateUI();
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
                if (MessageBox.Show("Are you sure you want to uninstall this skin?", name, MessageBoxButtons.OKCancel) == DialogResult.OK)
                    Uninstall();
            }
            else
            {
                Install();
            }
        }

        public void ClickedPreviewIdle(object sender, EventArgs e)
        {
            try { Process.Start(IdlePreviewURL); }
            catch (Exception) { MessageBox.Show("Link does not exist!", "Invalid Link"); }
        }

        public void ClickedPreviewCharged(object sender, EventArgs e)
        {
            try { Process.Start(ChargedPreviewURL); }
            catch (Exception) { MessageBox.Show("Link does not exist!", "Invalid Link"); }
        }

        public void ClickedUpdate(object sender, EventArgs e)
        {
            Uninstall();
            Install();
        }

        // UI methods

        public void CreateUI(Panel parentPanel, int skinIdx)
        {
            _ui = new SkinUI(this, parentPanel);
            SetUIPosition(skinIdx);
            UpdateUI();
            Core.Blas1SkinPage.AdjustPageWidth();
        }

        public void UpdateUI()
        {
            _ui.UpdateUI(name, author, Installed, UpdateAvailable);
        }

        public void SetUIPosition(int skinIdx)
        {
            _ui.SetPosition(skinIdx);
        }

        // Sorting methods

        public int CompareTo(object obj) => SortBy(obj as Skin, Core.Blas1SkinPage.CurrentSortType);

        public int SortBy(Skin skin, SortType sort)
        {
            if (sort == SortType.Name)
            {
                return name.CompareTo(skin.name);
            }
            else if (sort == SortType.Author)
            {
                int difference = author.CompareTo(skin.author);
                return difference == 0 ? SortBy(skin, SortType.Name) : difference;
            }
            return 0;
        }
    }
}
