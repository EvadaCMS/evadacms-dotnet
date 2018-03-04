using Evada.ContentApi.Models;
using Evada.Core.QueryParameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evada.ContentApi.Clients
{
    public interface IContentItemsClient
    {
        Task<List<ContentItem>> GetAllAsync(params IQueryParameter[] parameters);
        Task<List<ContentItem>> GetAllAsync(IEnumerable<IQueryParameter> parameters);
        //Task<dynamic> GetAsync(string slug, IEnumerable<IQueryParameter> parameters = null);
        Task<ContentItem> GetAsync(string slug, IEnumerable<IQueryParameter> parameters = null);
    }
}
