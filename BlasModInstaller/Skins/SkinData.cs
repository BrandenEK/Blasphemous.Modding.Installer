using Newtonsoft.Json;

namespace BlasModInstaller.Skins
{
    internal class SkinData
    {
        [JsonProperty] public readonly string id;
        [JsonProperty] public readonly string name;
        [JsonProperty] public readonly string author;

        // This is the most recent version and is updated whenever loading global skins
        [JsonProperty] public readonly string version;

        [JsonConstructor]
        public SkinData(string id, string name, string author, string version)
        {
            this.id = id;
            this.name = name;
            this.author = author;
            this.version = version;
        }

        public SkinData(SkinData data)
        {
            id = data.id;
            name = data.name;
            author = data.author;
            version = data.version;
        }
    }
}
