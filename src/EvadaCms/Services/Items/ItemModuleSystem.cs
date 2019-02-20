using Newtonsoft.Json;
using System;

namespace Evada.Services.Items
{
    public class ItemModuleSystem
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
