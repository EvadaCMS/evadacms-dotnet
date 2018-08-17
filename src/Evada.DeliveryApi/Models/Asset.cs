using Newtonsoft.Json;
using System.Collections.Generic;

namespace Evada.DeliveryApi.Models
{
    public class Asset
    {
        [JsonProperty("system")]
        public AssetSystem System { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("file_name")]
        public string FileName { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, AssetMetadata> Metadata { get; } = new Dictionary<string, AssetMetadata>();
    }
}
