using Newtonsoft.Json;

namespace Evada.Core.Services.Items
{
    public class ItemWorkflowStep
    {
        [JsonProperty("label")]
        public string Label { get; set; }
    }
}
