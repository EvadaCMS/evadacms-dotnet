using System;
using System.Collections.Generic;
using System.Linq;

namespace Evada.Core.QueryParameters
{
    public class TypesParameter : IQueryParameter
    {
        public IReadOnlyList<string> TypeSlugs { get; set; }

        public TypesParameter(params string[] typeSlugs)
        {
            TypeSlugs = typeSlugs;
        }

        public string Name { get; } = "type";

        public string Value
        {
            get
            {
                return string.Join(Uri.EscapeDataString(","), TypeSlugs.Select(Uri.EscapeDataString));
            }
        }
    }
}