using Newtonsoft.Json;
using System;

namespace Evada.ManagementApi.Models
{
    public class ContainerBase
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("subscription")]
        public ContainerSubscription Subscription { get; set; }
    }
}
