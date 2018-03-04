using Evada.Core;
using Evada.Core.Http;
using Evada.ManagementApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evada.ManagementApi.Clients
{
    public class AuthorizationClient : ClientBase, IAuthorizationClient
    {
        /// <summary>
        /// Creates a new instance of the <see cref="ContainersClient"/> class.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public AuthorizationClient(IApiConnection connection)
            : base(connection)
        {
        }

        public async Task<Authorization> CreateTokenAsync(string clientId, string clientSecret)
        {
            return await Connection.PostAsync<Authorization>("/connect/token", null,
                new Dictionary<string, object>
                {
                    { "grant_type", "client_credentials" },
                    { "client_id", clientId },
                    { "client_secret", clientSecret }
                }
            , null, null, null, null);
        }
    }
}
