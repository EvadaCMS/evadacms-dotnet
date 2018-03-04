using Evada.ContentApi.Clients;
using Evada.Core.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Evada.ContentApi
{
    public class ContentApiClient : IContentApiClient
    {
        private readonly ApiConnection _apiConnection;

        public IContentItemsClient ContentItems { get; }

        /// <summary>
        /// Gets information about the last API call
        /// </summary>
        public ApiInfo GetLastApiInfo()
        {
            return _apiConnection.ApiInfo;
        }

        public ContentApiClient(string containerId, string token, string baseUrl, DiagnosticsHeader diagnostics, HttpMessageHandler handler)
        {
            // If no diagnostics header structure was specified, then revert to the default one
            if (diagnostics == null)
            {
                diagnostics = DiagnosticsHeader.Default;
            }

            _apiConnection = new ApiConnection(token, baseUrl, diagnostics, handler);

            ContentItems = new ContentItemsClient(_apiConnection, containerId);
        }

        public ContentApiClient(string containerId, string token, string baseUrl)
            : this(containerId, token, baseUrl, null, null)
        {
        }

        public ContentApiClient(string containerId, string token)
            : this(containerId, token, string.Empty, null, null)
        {
        }

        public ContentApiClient(string containerId)
            :this(containerId, string.Empty, string.Empty, null, null)
        {
        }
    }
}
