using Newtonsoft.Json;

namespace Evada.DeliveryApi.Models
{
    public class ItemWorkflowStep
    {
        [JsonProperty("label")]
        public string Label { get; set; }
    }
}
