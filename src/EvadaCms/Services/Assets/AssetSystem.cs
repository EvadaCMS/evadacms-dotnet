using Newtonsoft.Json;
using System;

namespace Evada.Services.Assets
{
    public class AssetSystem
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedDate { get; set; }
    }
}
