using Newtonsoft.Json;

namespace Evada.Services.Assets
{
    public class AssetMetadata
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
