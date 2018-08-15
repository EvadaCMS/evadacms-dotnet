﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Evada.DeliveryApi.Models
{
    public class ItemsResult
    {
        [JsonProperty("items")]
        public List<Item> Items { get; set; }

        [JsonProperty("pagination")]
        public ItemPagination Pagination { get; set; }
    }
}
