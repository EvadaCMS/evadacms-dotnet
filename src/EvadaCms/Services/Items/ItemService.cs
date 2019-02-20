using Evada.Http;
using Evada.QueryParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evada.Services.Items
{
    public class ItemService : ServiceBase
    {
        private readonly string _containerId;
        private readonly LanguageParameter _defaultLanguageParameter;

        /// <summary>
        /// Creates a new instance of the <see cref="ItemService"/> class.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        /// <param name="containerId">The container ID</param>
        /// <param name="languageCode">The default language to use</param>
        public ItemService(IApiConnection connection, string containerId, string languageCode = "en-US")
            : base(connection)
        {
            _containerId = containerId;
            _defaultLanguageParameter = new LanguageParameter(languageCode);
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
            parameters = EnsureLanguageIsPresent(parameters);

            return Connection.GetAsync<ItemsResult>("{containerId}/items",
                new Dictionary<string, string>
                {
                    { "containerId", _containerId }
                },
                parameters.ToDictionary(x => x.Name, x => x.Value), null, null);
        }

        public async Task<Item> GetSingleAsync(string slug, IEnumerable<IQueryParameter> parameters = null)
        {
            if (parameters == null)
            {
                parameters = new List<IQueryParameter>();
            }

            parameters = EnsureLanguageIsPresent(parameters);

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

            parameters = EnsureLanguageIsPresent(parameters);

            var result = await Connection.GetAsync<Dictionary<string, Item>>("{containerId}/items/{id}",
                new Dictionary<string, string>
                {
                    { "containerId", _containerId },
                    { "id", id.ToString() }
                },
                parameters.ToDictionary(x => x.Name, x => x.Value), null, null);

            return result["item"];
        }

        private IEnumerable<IQueryParameter> EnsureLanguageIsPresent(IEnumerable<IQueryParameter> parameters)
        {
            if (!parameters.Any(p => p is LanguageParameter))
            {
                var updatedParameters = new List<IQueryParameter>(parameters);
                updatedParameters.Add(_defaultLanguageParameter);
                return updatedParameters;
            }

            return parameters;
        }
    }
}
