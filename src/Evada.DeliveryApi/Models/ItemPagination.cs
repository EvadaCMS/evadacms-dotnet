using Newtonsoft.Json;

namespace Evada.DeliveryApi.Models
{
    public class ItemPagination
    {
        [JsonProperty("skip")]
        public int Skip { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("total")]
        public int? Total { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }
    }
}
