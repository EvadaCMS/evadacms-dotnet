using Evada.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evada.ManagementApi.Clients
{
    public interface IAuthorizationClient
    {
        Task<Authorization> CreateTokenAsync(string clientId, string clientSecret);
    }
}
