namespace Evada.Core.QueryParameters
{
    public class LimitParameter : IQueryParameter
    {
        public int Limit { get; }

        public LimitParameter(int limit)
        {
            Limit = limit;
        }

        public string Name { get; } = "limit";

        public string Value
        {
            get { return Limit.ToString(); }
        }
    }
}
