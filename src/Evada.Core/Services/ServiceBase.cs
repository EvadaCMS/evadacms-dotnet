using Evada.Core.Http;

namespace Evada.Core.Services
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

        /// <summary>
        /// Creates a new instance of the ServiceBase class.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection"/> which is used to communicate with the API.</param>
        public ServiceBase(IApiConnection connection)
        {
            Connection = connection;
        }
    }
}
