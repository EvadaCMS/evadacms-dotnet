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

        public IContainersClient Containers { get; }

        /// <summary>
        /// Gets information about the last API call
        /// </summary>
        public ApiInfo GetLastApiInfo()
        {
            return _apiConnection.ApiInfo;
        }

        public ManagementApiClient(string token, string baseUrl, DiagnosticsHeader diagnostics, HttpMessageHandler handler)
        {
            // If no diagnostics header structure was specified, then revert to the default one
            if (diagnostics == null)
            {
                diagnostics = DiagnosticsHeader.Default;
            }

            // TODO
            _apiConnection = new ApiConnection(token, baseUrl, diagnostics, handler);
            
            Containers = new ContainersClient(_apiConnection);
        }

        public ManagementApiClient(string token, string baseUrl)
            : this(token, baseUrl, null, null)
        {

        }
    }
}
