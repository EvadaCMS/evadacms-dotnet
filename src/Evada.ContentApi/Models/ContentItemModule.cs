using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evada.ContentApi.Models
{
    public class ContentItemModule
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        
        [JsonProperty("value")]
        public object Value { get; set; }

        [JsonProperty("created_date")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("guidelines")]
        public string Guidelines { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("min_length")]
        public int? MinLength { get; set; }

        [JsonProperty("max_length")]
        public int? MaxLength { get; set; }

        [JsonProperty("revision")]
        public int? Revision { get; set; }

        [JsonProperty("multiline")]
        public bool? Multiline { get; set; }

        [JsonProperty("options")]
        public string Options { get; set; }
    }
}
