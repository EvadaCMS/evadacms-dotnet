using Evada.DeliveryApi.Clients;
using Evada.Core.Http;

namespace Evada.DeliveryApi
{
    /// <summary>
    /// Represents the Delivery API client.
    /// </summary>
    public interface IDeliveryApiClient
    {
        /// <summary>
        /// Contains all the methods to call the /content-items endpoints
        /// </summary>
        IItemsClient Items { get; }

        /// <summary>
        /// Gets information about the last API call
        /// </summary>
        ApiInfo GetLastApiInfo();
    }
}
