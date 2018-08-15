using Evada.DeliveryApi.Models;
using Evada.Core.QueryParameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Evada.DeliveryApi.Clients
{
    public interface IItemsClient
    {
        Task<ItemsResult> GetAsync(params IQueryParameter[] parameters);
        Task<ItemsResult> GetAsync(IEnumerable<IQueryParameter> parameters);
        Task<Item> GetSingleAsync(string slug, IEnumerable<IQueryParameter> parameters = null);
        Task<Item> GetSingleAsync(Guid id, IEnumerable<IQueryParameter> parameters = null);
    }
}
