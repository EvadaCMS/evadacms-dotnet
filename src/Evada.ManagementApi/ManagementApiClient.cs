using Evada.Core.Http;
using Evada.ManagementApi.Clients;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Evada.ManagementApi
{
    public class ManagementApiClient : IManagementApiClient
    {
        private readonly ApiConnection _apiConnection;

        private readonly string _baseUrl = "https://api.evadacms.com";

        public IContainersClient Containers { get; }
        public IAuthorizationClient Authorization { get; }

        /// <summary>
        /// Gets information about the last API call
        /// </summary>
        public ApiInfo GetLastApiInfo()
        {
            return _apiConnection.ApiInfo;
        }

        public ManagementApiClient(string token, DiagnosticsHeader diagnostics, HttpMessageHandler handler, string baseUrl = "")
        {
            // If no diagnostics header structure was specified, then revert to the default one
            if (diagnostics == null)
            {
                diagnostics = DiagnosticsHeader.Default;
            }

            if (!string.IsNullOrEmpty(baseUrl))
            {
                _baseUrl = baseUrl;
            }

            _apiConnection = new ApiConnection(token, _baseUrl, diagnostics, handler);
            
            Containers = new ContainersClient(_apiConnection);
            Authorization = new AuthorizationClient(_apiConnection);
        }

        public ManagementApiClient(string token, string baseUrl = "")
            : this(token, null, null, baseUrl)
        {
        }

        public ManagementApiClient(string token)
            : this(token, null, null)
        {
        }

        public ManagementApiClient()
            : this(string.Empty, null, null)
        {
        }

        public ManagementApiClient(DiagnosticsHeader diagnostics, HttpMessageHandler handler)
            : this(string.Empty, diagnostics, handler, string.Empty)
        {
        }
    }
}
