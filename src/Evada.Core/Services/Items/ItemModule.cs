using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Evada.Core.Services.Items
{
    public class ItemModule
    {
        [JsonProperty("system")]
        public ItemModuleSystem System { get; set; }

        [JsonProperty("value")]
        public JToken Value { get; set; }
    }
}
