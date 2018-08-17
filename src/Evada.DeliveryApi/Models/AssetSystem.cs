using Newtonsoft.Json;
using System;

namespace Evada.DeliveryApi.Models
{
    public class AssetSystem
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedDate { get; set; }
    }
}
