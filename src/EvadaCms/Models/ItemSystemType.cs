using Newtonsoft.Json;
using System;

namespace Evada.Models
{
    public class ItemSystemType
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
