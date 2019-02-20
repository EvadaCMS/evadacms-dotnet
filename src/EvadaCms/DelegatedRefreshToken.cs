using Newtonsoft.Json;

namespace Evada
{
    /// <summary>
    /// Represents a delegated refresh token.
    /// </summary>
    public class DelegatedRefreshToken : DelegatedTokenBase
    {
        /// <summary>
        /// The refresh token.
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
