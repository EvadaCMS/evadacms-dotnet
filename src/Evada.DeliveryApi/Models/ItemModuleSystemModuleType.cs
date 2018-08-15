using Newtonsoft.Json;

namespace Evada.DeliveryApi.Models
{
    public class ItemModuleSystemModuleType
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        public override string ToString()
        {
            return Type;
        }
    }
}
