using Newtonsoft.Json;

namespace Evada.Services.Items
{
    public class ItemSystemLanguage
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
