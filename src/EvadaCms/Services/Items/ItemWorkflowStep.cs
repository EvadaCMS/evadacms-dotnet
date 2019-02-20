using Newtonsoft.Json;

namespace Evada.Services.Items
{
    public class ItemWorkflowStep
    {
        [JsonProperty("label")]
        public string Label { get; set; }
    }
}
