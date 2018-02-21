using Newtonsoft.Json;

namespace Evada.ManagementApi.Models
{
    public class ContainerUpdateRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
