using Evada.Core;
using Evada.Core.Http;
using Evada.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evada.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /containers endpoints.
    /// </summary>
    public class ContainersClient : ClientBase, IContainersClient
    {
        /// <summary>
        /// Creates a new instance of the <see cref="ContainersClient"/> class.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public ContainersClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Retrieves as list of all containers.
        /// </summary>
        /// <returns>A list of <see cref="Container"/> objects.</returns>
        public async Task<IList<Container>> GetAllAsync()
        {
            var result = await Connection.GetAsync<Dictionary<string, IList<Container>>>("containers", null, null, null, null);
            return result["containers"];
        }

        /// <summary>
        /// Retrieves a container by its ID.
        /// </summary>
        /// <param name="id">The ID of the container to retrieve.</param>
        /// <returns>The <see cref="Container"/>.</returns>
        public async Task<Container> GetAsync(Guid id)
        {
            var result = await Connection.GetAsync<Dictionary<string, Container>>("containers/{id}",
                new Dictionary<string, string>
                {
                    { "id", id.ToString() }
                }, null, null, null);

            return result["container"];
        }

        /// <summary>
        /// Creates a new container according to the request.
        /// </summary>
        /// <param name="request">The <see cref="ContainerCreateRequest"/> containing the details of the container to create.</param>
        /// <returns>The newly created <see cref="Container"/>.</returns>
        public async Task<Container> CreateAsync(ContainerCreateRequest request)
        {
            var result = await Connection.PostAsync<Dictionary<string, Container>>("containers", request, null, null, null, null, null);
            return result["container"];
        }

        /// <summary>
        /// Updates a container.
        /// </summary>
        /// <param name="id">The ID of the container to update.</param>
        /// <param name="request">A <see cref="ContainerUpdateRequest"/> containing the information to update.</param>
        /// <returns>The <see cref="Container"/>.</returns>
        public async Task<Container> UpdateAsync(Guid id, ContainerUpdateRequest request)
        {
            var result = await Connection.PatchAsync<Dictionary<string, Container>>("containers/{id}", request,
                new Dictionary<string, string>
                {
                    { "id", id.ToString() }
                });

            return result["container"];
        }
    }
}
