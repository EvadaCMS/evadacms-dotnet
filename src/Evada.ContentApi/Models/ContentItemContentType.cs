using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evada.ContentApi.Models
{
    public class ContentItemContentType
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }
}
