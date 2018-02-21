using Newtonsoft.Json;

namespace Evada.Core
{
    public abstract class DelegatedTokenBase
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

    }
}
