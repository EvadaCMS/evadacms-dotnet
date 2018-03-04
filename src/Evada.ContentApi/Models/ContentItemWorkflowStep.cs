using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evada.ContentApi.Models
{
    public class ContentItemWorkflowStep
    {
        [JsonProperty("label")]
        public string Label { get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
    }
}
