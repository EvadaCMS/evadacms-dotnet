using Evada.DeliveryApi.Models;
using Evada.Core;
using Evada.Core.Http;
using Evada.Core.QueryParameters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evada.DeliveryApi.Clients
{
    public class ItemsClient : ClientBase, IItemsClient
    {
        private readonly string _containerId;

        /// <summary>
        /// Creates a new instance of the <see cref="ItemsClient"/> class.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        /// <param name="containerId">The container ID</param>
        public ItemsClient(IApiConnection connection, string containerId)
            : base(connection)
        {
            _containerId = containerId;
        }

        /// <summary>
        /// Retrieves as list of all items matching the parameters.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>A list of <see cref="Item"/> objects.</returns>
        public Task<ItemsResult> GetAsync(params IQueryParameter[] parameters)
        {
            return GetAsync((IEnumerable<IQueryParameter>)parameters);
        }

        public Task<ItemsResult> GetAsync(IEnumerable<IQueryParameter> parameters)
        {
            return Connection.GetAsync<ItemsResult>("{containerId}/items",
                new Dictionary<string, string>
                {
                    { "containerId", _containerId }
                },
                parameters.ToDictionary(x => x.Name, x => x.Value), null, null);

            /*var result = await Connection.GetAsync<Dictionary<string, List<ContentItem>>>("{containerId}/content-items",
                new Dictionary<string, string>
                {
                    { "containerId", _containerId }
                },
                parameters.ToDictionary(x => x.Name, x => x.Value), null, null);

            return result["content_items"];*/
        }

        public async Task<Item> GetSingleAsync(string slug, IEnumerable<IQueryParameter> parameters = null)
        {
            if (parameters == null)
            {
                parameters = new List<IQueryParameter>();
            }

            var result = await Connection.GetAsync<Dictionary<string, Item>>("{containerId}/items/{slug}",
                new Dictionary<string, string>
                {
                    { "containerId", _containerId },
                    { "slug", slug }
                },
                parameters.ToDictionary(x => x.Name, x => x.Value), null, null);

            return result["item"];
        }

        public async Task<Item> GetSingleAsync(Guid id, IEnumerable<IQueryParameter> parameters = null)
        {
            if (parameters == null)
            {
                parameters = new List<IQueryParameter>();
            }

            var result = await Connection.GetAsync<Dictionary<string, Item>>("{containerId}/items/{id}",
                new Dictionary<string, string>
                {
                    { "containerId", _containerId },
                    { "id", id.ToString() }
                },
                parameters.ToDictionary(x => x.Name, x => x.Value), null, null);

            return result["item"];
        }
    }
}
