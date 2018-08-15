using System;

namespace Evada.ContentApi.Models
{
    public class Asset
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public long Size { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
