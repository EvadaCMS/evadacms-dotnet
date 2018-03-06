using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evada.ContentApi.Models
{
    public class ContentItem
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("last_updated_by")]
        public string LastUpdatedBy { get; set; }

        [JsonProperty("last_udpated_by_initials")]
        public string LastUpdatedByInitials { get; set; }

        [JsonProperty("modules")]
        public List<ContentItemModule> Modules { get; set; }
        
        [JsonProperty("content_type")]
        public ContentItemContentType ContentType { get; set; }

        [JsonProperty("language")]
        public ContentItemLanguage Language { get; set; }

        [JsonProperty("workflow_step")]
        public ContentItemWorkflowStep WorkflowStep { get; set; }

        [JsonProperty("references")]
        public List<ContentItem> References { get; set; }

        public ContentItemModule GetModule(string slug)
        {
            return Modules.FirstOrDefault(m => m.Slug == slug);
        }

        public string GetString(string slug)
        {
            var module = GetModule(slug);
            return (module == null) ? string.Empty : (string)module.Value;
        }

        public List<ContentItem> GetReferenceItems(string slug)
        {
            var module = GetModule(slug);
            if (module == null)
            {
                return null;
            }

            List<ContentItem> references = new List<ContentItem>();
            if (module.Value == null)
            {
                return null;
            }
            foreach (var id in (JArray)module.Value)
            {
                var match = References.Where(r => r.Id == id.ToObject<Guid>()).FirstOrDefault();
                if (match != null)
                {
                    references.Add(match);
                }
            }

            return references;
        }

        public List<Asset> GetAssets(string slug)
        {
            var assets = new List<Asset>();

            var module = GetModule(slug);
            if (module == null)
            {
                return assets;    
            }

            foreach (var asset in (JArray)module.Value)
            {
                assets.Add(asset.ToObject<Asset>());
            }

            return assets;
        }
    }
}
