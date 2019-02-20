using Newtonsoft.Json;
using System;

namespace Evada.Services.Items
{
    public class ItemSystemType
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
