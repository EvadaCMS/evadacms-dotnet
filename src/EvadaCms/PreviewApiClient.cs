using Evada.Http;
using Evada.Services.Items;
using System;
using System.Net.Http;

namespace Evada
{
    public class PreviewApiClient
    {
        public string PreviewApiCdn => "https://preview-api.evadacms.com/v1/";

        private readonly ApiConnection _apiConnection;

        public ItemService Items { get; }

        /// <summary>
        /// Gets information about the last API call
        /// </summary>
        public ApiInfo GetLastApiInfo()
        {
            return _apiConnection.ApiInfo;
        }

        public PreviewApiClient(
            HttpClient httpClient,
            string token,
            string containerId,
            string defaultLanguageCode,
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

            // If no diagnostics header structure was specified, then revert to the default one
            if (diagnostics == null)
            {
                diagnostics = DiagnosticsHeader.Default;
            }

            _apiConnection = new ApiConnection(
                httpClient,
                token,
                string.IsNullOrEmpty(baseUrl) ? PreviewApiCdn : baseUrl,
                diagnostics,
                handler);

            Items = new ItemService(_apiConnection, containerId, defaultLanguageCode);
        }

        public PreviewApiClient(HttpClient httpClient, string token, string containerId, string defaultLanguageCode, string baseUrl)
            : this(httpClient, token, containerId, defaultLanguageCode, baseUrl, null, null)
        {
        }

        public PreviewApiClient(HttpClient httpClient, string token, string containerId, string defaultLanguageCode)
            : this(httpClient, token, containerId, defaultLanguageCode, string.Empty, null, null)
        {
        }

        public PreviewApiClient(HttpClient httpClient, string token, string containerId)
            : this(httpClient, token, containerId, string.Empty, string.Empty, null, null)
        {
        }
    }
}
