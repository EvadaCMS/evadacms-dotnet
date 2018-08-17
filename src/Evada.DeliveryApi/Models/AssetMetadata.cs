using Newtonsoft.Json;

namespace Evada.DeliveryApi.Models
{
    public class AssetMetadata
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
