namespace Evada.ManagementApi.Models
{
    public class AuthorizationCreateRequest
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string GrantType => "client_credentials";
    }
}
