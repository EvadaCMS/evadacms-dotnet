using Newtonsoft.Json;
using System;

namespace Evada.Core.Services.Items
{
    public class ItemSystemType
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
