using Newtonsoft.Json;

namespace Evada.ManagementApi.Models
{
    public class ContainerCreateRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
