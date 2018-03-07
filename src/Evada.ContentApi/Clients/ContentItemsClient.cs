using Evada.ContentApi.Models;
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

namespace Evada.ContentApi.Clients
{
    public class ContentItemsClient : ClientBase, IContentItemsClient
    {
        private readonly string _containerId;
        /// <summary>
        /// Creates a new instance of the <see cref="ContentItemsClient"/> class.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public ContentItemsClient(IApiConnection connection, string containerId)
            : base(connection)
        {
            _containerId = containerId;
        }

        /// <summary>
        /// Retrieves as list of all content items.
        /// </summary>
        /// <returns>A list of <see cref="ContentItem"/> objects.</returns>
        public async Task<List<ContentItem>> GetAllAsync(params IQueryParameter[] parameters)
        {
            return await GetAllAsync((IEnumerable<IQueryParameter>)parameters);
        }

        public async Task<List<ContentItem>> GetAllAsync(IEnumerable<IQueryParameter> parameters)
        {
            var result = await Connection.GetAsync<ContentItemsResult>("{containerId}/content-items",
                new Dictionary<string, string>
                {
                    { "containerId", _containerId }
                },
                parameters.ToDictionary(x => x.Name, x => x.Value), null, null);

            return result.ContentItems;
            /*var result = await Connection.GetAsync<Dictionary<string, List<ContentItem>>>("{containerId}/content-items",
                new Dictionary<string, string>
                {
                    { "containerId", _containerId }
                },
                parameters.ToDictionary(x => x.Name, x => x.Value), null, null);

            return result["content_items"];*/
        }

        //public async Task<dynamic> GetAsync(string slug, IEnumerable<IQueryParameter> parameters = null)
        public async Task<ContentItem> GetAsync(string slug, IEnumerable<IQueryParameter> parameters = null)
        {
            if (parameters == null)
            {
                parameters = new List<IQueryParameter>();
            }

            var result = await Connection.GetAsync<Dictionary<string, ContentItem>>("{containerId}/content-items/{slug}",
                new Dictionary<string, string>
                {
                    { "containerId", _containerId },
                    { "slug", slug }
                },
                parameters.ToDictionary(x => x.Name, x => x.Value), null, null);

            return result["content_item"];
        }
    }
}
