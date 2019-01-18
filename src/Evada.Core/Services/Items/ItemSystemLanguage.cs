using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evada.Core.Services.Items
{
    public class ItemSystemLanguage
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
