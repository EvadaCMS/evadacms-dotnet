using Newtonsoft.Json;

namespace Evada.Models
{
    public class ItemSystemLanguage
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
