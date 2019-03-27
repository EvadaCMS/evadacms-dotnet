using Newtonsoft.Json;

namespace Evada.Models
{
    public class ItemWorkflowStep
    {
        [JsonProperty("label")]
        public string Label { get; set; }
    }
}
