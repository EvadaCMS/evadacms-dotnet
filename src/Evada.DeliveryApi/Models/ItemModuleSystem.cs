using Newtonsoft.Json;
using System;

namespace Evada.DeliveryApi.Models
{
    public class ItemModuleSystem
    {
        [JsonProperty("module_type")]
        public ItemModuleSystemModuleType ModuleType { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
