using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Evada.DeliveryApi.Models
{
    public class ItemModule
    {
        [JsonProperty("system")]
        public ItemModuleSystem System { get; set; }

        [JsonProperty("value")]
        public JToken Value { get; set; }
    }
}
