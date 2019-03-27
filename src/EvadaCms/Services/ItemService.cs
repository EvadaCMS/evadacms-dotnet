using Evada.Configuration;
using Evada.Http;
using Evada.Models;
using Evada.Query;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evada.Services
{
    public class ItemService : ServiceBase
    {
        private readonly string _containerId;

        /// <summary>
        /// Creates a new instance of the <see cref="ItemService"/> class.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        /// <param name="options">Evada options</param>
        public ItemService(IApiConnection connection, EvadaOptions options)
            : base(connection)
        {
            _containerId = options.ContainerId;
        }

        public async Task<ItemCollection<T>> GetAsync<T>(ItemQueryBuilder<T> queryBuilder)
        {
            return await GetAsync<T>(queryBuilder.ToDictionary()).ConfigureAwait(false);
        }

        public async Task<ItemCollection<T>> GetAsync<T>(Dictionary<string, string> queryStrings)
        {
            var responseString = await Connection.GetAsync<string>("{containerId}/items",
                new Dictionary<string, string>
                {
                    { "containerId", _containerId }
                },
                queryStrings,
                null,
                null);

            var fullJson = JObject.Parse(responseString);
            var processedIds = new HashSet<string>();

            foreach (var item in fullJson.SelectTokens("$.items[*]").OfType<JObject>())
            {
                ResolveReferences(fullJson, item, processedIds);
            }

            var itemTokens = fullJson.SelectTokens("$.items[*]..modules").ToList();

            for (var i = itemTokens.Count - 1; i >= 0; i--)
            {
                var token = itemTokens[i];
                var grandparent = token.Parent.Parent;

                token.Parent.Remove();
                grandparent.Add(token.Children());
            }

            var collection = fullJson.ToObject<ItemCollection<T>>(Serializer);
            collection.Items = fullJson.SelectToken("$.items").ToObject<IEnumerable<T>>(Serializer);
            collection.ReferencedItems = fullJson.SelectTokens("$.references.item[*]")?.Select(x => x.ToObject<Item<dynamic>>(Serializer));
            collection.ReferencedAssets = fullJson.SelectTokens("$.references.asset[*]")?.Select(x => x.ToObject<Asset>(Serializer));

            return collection;
        }

        public async Task<T> GetSingleAsync<T>(string itemId, ItemQueryBuilder<T> queryBuilder)
        {
            return await GetSingleAsync<T>(itemId, queryBuilder.ToDictionary()).ConfigureAwait(false);
        }

        public async Task<T> GetSingleAsync<T>(string itemId, Dictionary<string, string> queryStrings)
        {
            if (string.IsNullOrEmpty(itemId))
            {
                throw new ArgumentNullException(nameof(itemId));
            }

            if (!Guid.TryParse(itemId, out var _))
            {
                throw new FormatException("itemId is not in the correct format.");
            }

            var responseString = await Connection.GetAsync<string>("{containerId}/items/{itemId}",
                new Dictionary<string, string>
                {
                    { "containerId", _containerId },
                    { "itemId", itemId }
                },
                queryStrings,
                null,
                null);

            var fullJson = JObject.Parse(responseString);
            var processedIds = new HashSet<string>();

            var itemToken = fullJson.SelectTokens("$.item").OfType<JObject>().First();
            ResolveReferences(fullJson, itemToken, processedIds);

            var deepModuleTokens = fullJson.SelectTokens("$.item..modules..modules").ToList();

            for (var i = 0; i < deepModuleTokens.Count - 1; i++)
            {
                var token = deepModuleTokens[i];
                var grandparent = (JObject)token.Parent.Parent;

                token.Parent.Remove();
                grandparent.Add(token.Children());
            }

            var systemToken = fullJson.SelectToken("$.item.system");
            var modulesToken = fullJson.SelectToken("$.item.modules");
            modulesToken["system"] = systemToken;

            return modulesToken.ToObject<T>(Serializer);
        }

        private void ResolveReferences(JObject fullJson, JObject itemToken, HashSet<string> processedIds)
        {
            var id = ((JValue)itemToken.SelectToken("$.system.id"))?.Value?.ToString();
            if (id == null)
            {
                return;
            }

            if (!processedIds.Contains(id))
            {
                itemToken.AddFirst(new JProperty("$id", new JValue(id)));
                processedIds.Add(id);
            }

            foreach (var referenceToken in itemToken.SelectTokens("$.modules..system").ToList())
            {
                var propName = (referenceToken.Parent.Parent.Ancestors().FirstOrDefault(x => x is JProperty) as JProperty)?.Name;
                var referenceId = ((JValue)referenceToken["id"]).Value.ToString();
                JToken updatedToken = null;
                if (processedIds.Contains(referenceId))
                {
                    updatedToken = new JObject
                    {
                        ["$ref"] = referenceId
                    };
                }
                else if (!string.IsNullOrEmpty(referenceToken["referenceType"]?.ToString()))
                {
                    var path = $"$.references.{referenceToken["referenceType"]}[?(@.system.id=='{referenceId}')]";
                    updatedToken = fullJson.SelectTokens(path).FirstOrDefault()
                        ?? fullJson.SelectTokens($"$.items.[?(@.system.id=='{referenceId}')]").FirstOrDefault();
                }

                var grandparent = (JObject)referenceToken.Parent.Parent;

                if (updatedToken != null)
                {
                    grandparent.RemoveAll();
                    grandparent.Add(updatedToken.Children());

                    if (!processedIds.Contains(referenceId))
                    {
                        ResolveReferences(fullJson, grandparent, processedIds);
                    }
                }
            }
        }
    }
}
