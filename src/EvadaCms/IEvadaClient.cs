using Evada.Http;
using Evada.Services;

namespace Evada
{
    public interface IEvadaClient
    {
        ApiInfo GetLastApiInfo();
        ItemService Items { get; }
    }
}
