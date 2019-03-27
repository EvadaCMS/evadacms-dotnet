using Newtonsoft.Json;

namespace Evada.Models
{
    public class AssetMetadata
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
