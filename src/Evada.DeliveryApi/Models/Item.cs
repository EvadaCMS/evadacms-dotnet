using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Evada.DeliveryApi.Models
{
    public class Item
    {
        [JsonProperty("system")]
        public ItemSystem System { get; set; }

        [JsonProperty("modules")]
        public Dictionary<string, ItemModule> Modules { get; set; }

        [JsonProperty("references")]
        public List<Item> References { get; } = new List<Item>();

        public ItemModule GetModule(string slug)
        {
            if (Modules == null)
            {
                return null;
            }
            if (Modules.ContainsKey(slug))
            {
                return Modules[slug];
            }
            else
            {
                return null;
            }
        }

        public string GetString(string slug)
        {
            var value = GetValue<string>(slug);
            return value ?? string.Empty;
        }

        public List<Asset> GetAsset(string slug)
        {
            return GetValue<List<Asset>>(slug);
        }

        public List<Item> GetReferences(string slug)
        {
            var ids = GetValue<List<Guid>>(slug);
            if (ids == null)
            {
                return new List<Item>();
            }
            return References.Where(r => ids.Any(x => x == r.System.Id)).ToList();
        }

        public T GetValue<T>(string slug)
        {
            var module = GetModule(slug);
            if (module == null)
            {
                return default(T);
            }
            return module.Value.ToObject<T>();
        }
    }
}
