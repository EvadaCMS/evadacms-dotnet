using Evada.Core.Http;
using Evada.ManagementApi.Clients;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evada.ManagementApi
{
    /// <summary>
    /// Represents the Management API client.
    /// </summary>
    public interface IManagementApiClient
    {
        /// <summary>
        /// Contains all the methods to call the /containers endpoints
        /// </summary>
        IContainersClient Containers { get; }

        /// <summary>
        /// Contains all the methods to call the /connect/token endpoint
        /// </summary>
        IAuthorizationClient Authorization { get; }

        /// <summary>
        /// Gets information about the last API call
        /// </summary>
        ApiInfo GetLastApiInfo();
    }
}
