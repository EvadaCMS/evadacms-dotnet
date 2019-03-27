using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Evada.Models
{
    [JsonObject]
    public class ItemCollection<T> : IEnumerable<T>
    {
        public IEnumerable<T> Items { get; set; }
        public IEnumerable<Item<dynamic>> ReferencedItems { get; set; }
        public IEnumerable<Asset> ReferencedAssets { get; set; }
        public ItemPagination Pagination { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
