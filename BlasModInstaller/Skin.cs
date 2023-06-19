using Newtonsoft.Json;
using System;
using System.IO;

namespace BlasModInstaller
{
    [Serializable]
    public class Skin
    {
        public string id;
        public string name;
        public string author;

        public void UpdateLocalData(Skin globalSkin)
        {
            id = globalSkin.id;
            name = globalSkin.name;
            author = globalSkin.author;
        }

        public override bool Equals(object obj)
        {
            if (obj is Skin skin)
                return id == skin.id;
            return base.Equals(obj);
        }

        [JsonIgnore]
        public bool Installed => File.Exists($"{MainForm.BlasRootFolder}\\Modding\\skins\\{id}\\info.txt");

        [JsonIgnore]
        public string PathToSkinFolder => $"{MainForm.BlasRootFolder}\\Modding\\skins\\{id}";

        [JsonIgnore]
        public string InfoURL => $"https://github.com/BrandenEK/Blasphemous-Custom-Skins/blob/main/{id}/info.txt";
        [JsonIgnore]
        public string TextureURL => $"https://github.com/BrandenEK/Blasphemous-Custom-Skins/blob/main/{id}/texture.png";
        [JsonIgnore]
        public string IdlePreviewURL => $"https://github.com/BrandenEK/Blasphemous-Custom-Skins/blob/main/{id}/idlePreview.png";
        [JsonIgnore]
        public string ChargedPreviewURL => $"https://github.com/BrandenEK/Blasphemous-Custom-Skins/blob/main/{id}/chargedPreview.png";
    }
}
