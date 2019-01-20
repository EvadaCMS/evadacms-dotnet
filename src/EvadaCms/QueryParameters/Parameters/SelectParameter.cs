using System.Collections.Generic;

namespace Evada.Core.QueryParameters
{
    public class SelectParameter : QueryParameter
    {
        public List<string> Fields { get; } = new List<string>();

        public override string Name { get; } = "select";

        public override string Value
        {
            get { return string.Join(",", Fields); }
        }

        public SelectParameter(IEnumerable<string> fields)
        {
            Fields.AddRange(fields);
        }
    }
}
