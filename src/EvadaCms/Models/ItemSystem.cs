using Newtonsoft.Json;
using System;

namespace Evada.Models
{
    public class ItemSystem
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("published")]
        public bool Published { get; set; }

        [JsonProperty("publishDate")]
        public DateTime? PublishAt { get; set; }

        [JsonProperty("firstPublishedAt")]
        public DateTime? FirstPublishedAt { get; set; }

        [JsonProperty("publishedVersion")]
        public int? PublishedVersion { get; set; }

        [JsonProperty("version")]
        public int Verison { get; set; }

        [JsonProperty("type")]
        public ItemSystemType Type { get; set; }

        [JsonProperty("language")]
        public ItemSystemLanguage Language { get; set; }

        [JsonProperty("workflowStep")]
        public ItemWorkflowStep WorkflowStep { get; set; }
    }
}
