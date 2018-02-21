using Evada.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evada.ManagementApi.Clients
{
    public interface IContainersClient
    {
        Task<IList<Container>> GetAllAsync();
        Task<Container> GetAsync(Guid id);
        Task<Container> CreateAsync(ContainerCreateRequest request);
        Task<Container> UpdateAsync(Guid id, ContainerUpdateRequest request);
    }
}
