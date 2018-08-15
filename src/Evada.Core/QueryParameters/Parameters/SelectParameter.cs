using System.Collections.Generic;

namespace Evada.Core.QueryParameters
{
    public class SelectParameter : IQueryParameter
    {
        public List<string> Fields { get; } = new List<string>();

        public string Name { get; } = "select";

        public string Value
        {
            get { return string.Join(",", Fields); }
        }

        public SelectParameter(IEnumerable<string> fields)
        {
            Fields.AddRange(fields);
        }
    }
}
