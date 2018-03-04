using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evada.ContentApi.Models
{
    public class ContentItemLanguage
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
