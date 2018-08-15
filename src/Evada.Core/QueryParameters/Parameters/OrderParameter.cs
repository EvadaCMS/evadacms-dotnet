namespace Evada.Core.QueryParameters
{
    public class OrderParameter : IQueryParameter
    {
        public string OrderBy { get; set; }
        public bool Descending { get; set; }

        public OrderParameter(string orderBy, bool descending = false)
        {
            Descending = descending;
            OrderBy = orderBy;
        }

        public string Name { get; } = "order";

        public string Value
        {
            get
            {
                string direction = Descending ? "-" : string.Empty;
                return $"{direction}{OrderBy}";
            }
        }
    }
}
