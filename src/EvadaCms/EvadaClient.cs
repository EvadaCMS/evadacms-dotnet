using Evada.Configuration;
using Evada.Http;
using Evada.Services.Items;
using System;
using System.Net.Http;

namespace Evada
{
    public class EvadaClient
    {
        public string DeliveryApiUrl => "https://cdn.evadacms.com/v1/";
        public string PreviewApiUrl => "https://preview-api.evadacms.com/v1/";

        private readonly ApiConnection _apiConnection;

        public ItemService Items { get; }

        /// <summary>
        /// Gets information about the last API call
        /// </summary>
        public ApiInfo GetLastApiInfo()
        {
            return _apiConnection.ApiInfo;
        }

        public EvadaClient(
            HttpClient httpClient,
            string token,
            string containerId,
            string defaultLanguageCode,
            bool usePreviewApi,
            string baseUrl,
            DiagnosticsHeader diagnostics,
            HttpMessageHandler handler)
        {
            if (httpClient == null)
            {
                throw new ArgumentNullException(nameof(httpClient));
            }

            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException(nameof(token));
            }

            if (string.IsNullOrEmpty(containerId))
            {
                throw new ArgumentNullException(nameof(containerId));
            }

            var url = !string.IsNullOrEmpty(baseUrl) ? baseUrl : usePreviewApi ? PreviewApiUrl : DeliveryApiUrl;

            // If no diagnostics header structure was specified, then revert to the default one
            if (diagnostics == null)
            {
                diagnostics = DiagnosticsHeader.Default;
            }

            _apiConnection = new ApiConnection(
                httpClient,
                token,
                url,
                diagnostics,
                handler);

            Items = new ItemService(_apiConnection, containerId, defaultLanguageCode);
        }

        public EvadaClient(HttpClient httpClient, string token, string containerId, string defaultLanguageCode, bool usePreviewApi, string baseUrl)
            : this(httpClient, token, containerId, defaultLanguageCode, usePreviewApi, baseUrl, null, null)
        {
        }

        public EvadaClient(HttpClient httpClient, string token, string containerId, string defaultLanguageCode, bool usePreviewApi)
            : this(httpClient, token, containerId, defaultLanguageCode, usePreviewApi, string.Empty, null, null)
        {
        }

        public EvadaClient(HttpClient httpClient, string token, string containerId)
            : this(httpClient, token, containerId, string.Empty, false, string.Empty, null, null)
        {
        }

        public EvadaClient(HttpClient httpClient, EvadaOptions options)
            : this(httpClient, options.UsePreviewApi ? options.PreviewApiToken : options.DeliveryApiToken, options.ContainerId, options.DefaultLanguageCode, options.UsePreviewApi, options.BaseUrl)
        {
        }
    }
}
