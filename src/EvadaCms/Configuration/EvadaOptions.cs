namespace Evada.Configuration
{
    public class EvadaOptions
    {
        public string ContainerId { get; set; }
        public string DeliveryApiToken { get; set; }
        public string PreviewApiToken { get; set; }
        public bool UsePreviewApi { get; set; }
        public string BaseUrl { get; set; }
        public string DefaultLanguageCode { get; set; }
    }
}
