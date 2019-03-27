using Newtonsoft.Json;

namespace Evada.Models
{
    public class Item<T>
    {
        [JsonProperty("system")]
        public ItemSystem System { get; set; }

        public T Modules { get; set; }
    }
}
