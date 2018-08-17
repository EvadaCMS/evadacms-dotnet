namespace Evada.Core.QueryParameters
{
    public class OrderParameter : QueryParameter
    {
        public string OrderBy { get; set; }
        public bool Descending { get; set; }

        public OrderParameter(string orderBy, bool descending = false)
        {
            Descending = descending;
            OrderBy = orderBy;
        }

        public override string Name { get; } = "order";

        public override string Value
        {
            get
            {
                string direction = Descending ? "-" : string.Empty;
                return $"{direction}{OrderBy}";
            }
        }
    }
}
