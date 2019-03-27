using Evada.Http;
using Newtonsoft.Json;

namespace Evada.Services
{
    /// <summary>
    /// The base class from which all services inherit. Give services access to the underlying <see cref="IApiConnection"/>.
    /// </summary>
    public class ServiceBase
    {
        /// <summary>
        /// The <see cref="IApiConnection"/> which is used to make all API calls.
        /// </summary>
        public IApiConnection Connection { get; }

        public JsonSerializer Serializer => JsonSerializer.Create(SerializerSettings);
        public JsonSerializerSettings SerializerSettings { get; set; } = new JsonSerializerSettings();

        /// <summary>
        /// Creates a new instance of the ServiceBase class.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection"/> which is used to communicate with the API.</param>
        public ServiceBase(IApiConnection connection)
        {
            Connection = connection;

            SerializerSettings.TypeNameHandling = TypeNameHandling.All;
        }
    }
}
