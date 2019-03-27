using Newtonsoft.Json;

namespace Evada
{
    /// <summary>
    /// Contains information about an error returned from the API.
    /// </summary>
    public class ApiError
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }
    }
}
