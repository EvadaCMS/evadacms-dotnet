﻿using Evada.Core.Http;
using Evada.Core.Services.Items;
using System.Net.Http;

namespace Evada.Core
{
    public class DeliveryApiClient
    {
        public string DeliveryApiCdn => "https://cdn.evadacms.com/v1/";

        private readonly ApiConnection _apiConnection;

        public ItemService Items { get; }

        /// <summary>
        /// Gets information about the last API call
        /// </summary>
        public ApiInfo GetLastApiInfo()
        {
            return _apiConnection.ApiInfo;
        }

        public DeliveryApiClient(
            string containerId,
            string defaultLanguageCode,
            string baseUrl,
            DiagnosticsHeader diagnostics,
            HttpMessageHandler handler)
        {
            // If no diagnostics header structure was specified, then revert to the default one
            if (diagnostics == null)
            {
                diagnostics = DiagnosticsHeader.Default;
            }

            _apiConnection = new ApiConnection(
                string.Empty,
                string.IsNullOrEmpty(baseUrl) ? DeliveryApiCdn : baseUrl,
                diagnostics,
                handler);

            Items = new ItemService(_apiConnection, containerId, defaultLanguageCode);
        }

        public DeliveryApiClient(string containerId, string defaultLanguageCode, string baseUrl)
            : this(containerId, defaultLanguageCode, baseUrl, null, null)
        {
        }

        public DeliveryApiClient(string containerId, string defaultLanguageCode)
            : this(containerId, defaultLanguageCode, string.Empty, null, null)
        {
        }

        public DeliveryApiClient(string containerId)
            : this(containerId, string.Empty, string.Empty, null, null)
        {
        }
    }
}