using Newtonsoft.Json;
using System;

namespace Evada.DeliveryApi.Models
{
    public class ItemSystem
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedDate { get; set; }

        [JsonProperty("published")]
        public bool Published { get; set; }

        [JsonProperty("publish_date")]
        public DateTime? PublishDate { get; set; }

        [JsonProperty("first_published_date")]
        public DateTime? FirstPublishedDate { get; set; }

        [JsonProperty("type")]
        public ItemSystemType Type { get; set; }

        [JsonProperty("language")]
        public ItemSystemLanguage Language { get; set; }

        [JsonProperty("workflow_step")]
        public ItemWorkflowStep WorkflowStep { get; set; }
    }
}
