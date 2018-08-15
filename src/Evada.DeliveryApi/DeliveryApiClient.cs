using Evada.DeliveryApi.Clients;
using Evada.Core.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Evada.DeliveryApi
{
    public class DeliveryApiClient : IDeliveryApiClient
    {
        private readonly ApiConnection _apiConnection;

        public IItemsClient Items { get; }

        /// <summary>
        /// Gets information about the last API call
        /// </summary>
        public ApiInfo GetLastApiInfo()
        {
            return _apiConnection.ApiInfo;
        }

        public DeliveryApiClient(
            string containerId,
            string baseUrl,
            DiagnosticsHeader diagnostics,
            HttpMessageHandler handler)
        {
            // If no diagnostics header structure was specified, then revert to the default one
            if (diagnostics == null)
            {
                diagnostics = DiagnosticsHeader.Default;
            }

            _apiConnection = new ApiConnection(string.Empty, baseUrl, diagnostics, handler);

            Items = new ItemsClient(_apiConnection, containerId);
        }

        public DeliveryApiClient(string containerId, string baseUrl)
            : this(containerId, baseUrl, null, null)
        {
        }

        public DeliveryApiClient(string containerId)
            : this(containerId, string.Empty, null, null)
        {
        }
    }
}
