namespace Evada.QueryParameters
{
    public class LimitParameter : QueryParameter
    {
        public int Limit { get; }

        public LimitParameter(int limit)
        {
            Limit = limit;
        }

        public override string Name { get; } = "limit";

        public override string Value
        {
            get { return Limit.ToString(); }
        }
    }
}
