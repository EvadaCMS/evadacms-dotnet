using Evada.Configuration;
using Evada.Http;
using Evada.Services;
using System;
using System.Net.Http;

namespace Evada
{
    public class EvadaClient : ClientBase, IEvadaClient
    {
        public string DeliveryApiUrl => "https://delivery-api.evadacms.com/v1/";
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

        public EvadaClient(HttpClient httpClient, EvadaOptions options)
        {
            if (httpClient == null)
            {
                throw new ArgumentNullException(nameof(httpClient));
            }

            _options = options ?? throw new ArgumentNullException(nameof(options));

            var url = !string.IsNullOrEmpty(options.BaseUrl) ? options.BaseUrl : options.UsePreviewApi ? PreviewApiUrl : DeliveryApiUrl;
            var token = options.UsePreviewApi ? options.PreviewApiToken : options.DeliveryApiToken;

            _apiConnection = new ApiConnection(httpClient, token, url, DiagnosticsHeader.Default, null);

            Items = new ItemService(_apiConnection, options);
        }
    }
}
