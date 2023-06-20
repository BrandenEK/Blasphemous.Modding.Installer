using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlasModInstaller
{
    [Serializable]
    public class Skin
    {
        // Data

        public string id;
        public string name;
        public string author;

        [JsonIgnore]
        private bool _downloading;
        [JsonIgnore]
        private SkinUI _ui;

        public void UpdateLocalData(Skin globalSkin)
        {
            // Id is already going to be the same
            name = globalSkin.name;
            author = globalSkin.author;
        }

        public override int GetHashCode() => base.GetHashCode();
        public override bool Equals(object obj)
        {
            if (obj is Skin skin)
                return id == skin.id;
            return base.Equals(obj);
        }

        [JsonIgnore]
        public bool Installed => File.Exists($"{MainForm.BlasRootFolder}\\Modding\\skins\\{id}\\info.txt");

        [JsonIgnore]
        public Version LocalVersion
        {
            get
            {
                return null;
            }
        }

        [JsonIgnore]
        public bool UpdateAvailable
        {
            get
            {
                return false;
            }
        }

        // Paths

        [JsonIgnore]
        public string PathToSkinFolder => $"{MainForm.BlasRootFolder}\\Modding\\skins\\{id}";
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
            if (MainForm.BlasRootFolder == null) return;

            _downloading = true;
            using (WebClient client = new WebClient())
            {
                _ui.ShowDownloadingStatus();

                string downloadPath = $"{MainForm.DownloadsPath}{id}";
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

        private void Uninstall()
        {
            if (MainForm.BlasRootFolder == null) return;

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
            _ui = new SkinUI(this, skinIdx, parentPanel);
            UpdateUI();
            MainForm.Instance.BlasSkinPage.AdjustPageWidth();
        }

        public void UpdateUI()
        {
            _ui.UpdateUI(name, author, Installed, UpdateAvailable);
        }
    }
}
