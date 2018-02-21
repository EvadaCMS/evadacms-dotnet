using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evada.ManagementApi.Models
{
    public class ContainerSubscription
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
    }
}
