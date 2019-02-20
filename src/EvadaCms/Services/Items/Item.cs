using Evada.Services.Assets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Evada.Services.Items
{
    public class Item
    {
        [JsonProperty("system")]
        public ItemSystem System { get; set; }

        [JsonProperty("modules")]
        public Dictionary<string, ItemModule> Modules { get; set; } = new Dictionary<string, ItemModule>();

        [JsonProperty("references")]
        public List<Item> References { get; } = new List<Item>();

        [JsonProperty("assets")]
        public List<Asset> Assets { get; } = new List<Asset>();

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

        public List<T> GetList<T>(string slug)
        {
            return GetValue<List<T>>(slug);
        }

        public List<Guid> GetAssetIds(string slug)
        {
            return GetList<Guid>(slug);
        }

        public List<Asset> GetAssets(string slug)
        {
            var ids = GetValue<List<Guid>>(slug);
            if (ids == null)
            {
                return new List<Asset>();
            }
            return Assets.Where(a => ids.Any(x => x == a.System.Id)).ToList();
        }

        public List<Guid> GetReferenceIds(string slug)
        {
            return GetList<Guid>(slug);
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
