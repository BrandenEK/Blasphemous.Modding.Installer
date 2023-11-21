using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlasModInstaller.Skins
{
    internal class Skin : IComparable
    {
        private readonly SkinUI _ui;
        private readonly SectionType _skinType;

        private bool _downloading;

        public Skin(SkinData data, Panel panel, int initialIndex, SectionType skinType)
        {
            Data = data;
            _skinType = skinType;
            _ui = new SkinUI(this, panel);
            SetUIPosition(initialIndex);
            UpdateUI();
            SkinPage.UIHolder.AdjustPageWidth();
        }

        public SkinData Data { get; set; }

        private InstallerPage SkinPage => Core.Blas1SkinPage;
        private SortType SkinSort => Core.SettingsHandler.Config.Blas1SkinSort;

        public bool Installed => File.Exists($"{RootFolder}\\Modding\\skins\\{Data.id}\\info.txt");

        public Version LocalVersion
        {
            get
            {
                string infoPath = PathToSkinFolder + "\\info.txt";
                if (File.Exists(infoPath))
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

        private string SubFolder => "blasphemous1";
        public string PathToSkinFolder => $"{RootFolder}\\Modding\\skins\\{Data.id}";
        public string InfoURL => $"https://raw.githubusercontent.com/BrandenEK/Blasphemous-Custom-Skins/main/{SubFolder}/{Data.id}/info.txt";
        public string TextureURL => $"https://raw.githubusercontent.com/BrandenEK/Blasphemous-Custom-Skins/main/{SubFolder}/{Data.id}/texture.png";
        public string IdlePreviewURL => $"https://github.com/BrandenEK/Blasphemous-Custom-Skins/blob/main/{SubFolder}/{Data.id}/idlePreview.png";
        public string ChargedPreviewURL => $"https://github.com/BrandenEK/Blasphemous-Custom-Skins/blob/main/{SubFolder}/{Data.id}/chargedPreview.png";

        // Main methods

        public async Task Install()
        {
            _downloading = true;
            using (WebClient client = new WebClient())
            {
                _ui.ShowDownloadingStatus();

                string downloadPath = $"{UIHandler.DownloadsPath}{Data.id}";
                Directory.CreateDirectory(downloadPath);

                string installPath = PathToSkinFolder;
                Directory.CreateDirectory(installPath);

                await client.DownloadFileTaskAsync(new Uri(InfoURL), downloadPath + "\\info.txt");
                await client.DownloadFileTaskAsync(new Uri(TextureURL), downloadPath + "\\texture.png");

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
                if (MessageBox.Show("Are you sure you want to uninstall this skin?", Data.name, MessageBoxButtons.OKCancel) == DialogResult.OK)
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

        public void UpdateUI()
        {
            _ui.UpdateUI(Data.name, Data.author, Installed, UpdateAvailable);
        }

        public void SetUIPosition(int skinIdx)
        {
            _ui.SetPosition(skinIdx);
        }

        public void MouseEnter(object sender, EventArgs e) => SkinPage.Previewer.PreviewSkin(Data);

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
}
