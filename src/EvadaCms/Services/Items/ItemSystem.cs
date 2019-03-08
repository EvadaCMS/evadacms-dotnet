using Newtonsoft.Json;
using System;

namespace Evada.Services.Items
{
    public class ItemSystem
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedDate { get; set; }

        [JsonProperty("published")]
        public bool Published { get; set; }

        [JsonProperty("publishDate")]
        public DateTime? PublishDate { get; set; }

        [JsonProperty("firstPublishedAt")]
        public DateTime? FirstPublishedDate { get; set; }

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
