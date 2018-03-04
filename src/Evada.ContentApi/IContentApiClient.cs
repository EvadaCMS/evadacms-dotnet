using Evada.ContentApi.Clients;
using Evada.Core.Http;

namespace Evada.ContentApi
{
    /// <summary>
    /// Represents the Content API client.
    /// </summary>
    public interface IContentApiClient
    {
        /// <summary>
        /// Contains all the methods to call the /content-items endpoints
        /// </summary>
        IContentItemsClient ContentItems { get; }

        /// <summary>
        /// Gets information about the last API call
        /// </summary>
        ApiInfo GetLastApiInfo();
    }
}
