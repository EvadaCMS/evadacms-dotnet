using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evada.ContentApi.Models
{
    public class ContentItemsResult
    {
        [JsonProperty("content_items")]
        public List<ContentItem> ContentItems { get; set; }
    }
}
