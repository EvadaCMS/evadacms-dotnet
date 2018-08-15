namespace Evada.Core.QueryParameters
{
    public class TotalParameter : IQueryParameter
    {
        public bool Total { get; }

        public TotalParameter(bool total)
        {
            Total = total;
        }

        public string Name { get; } = "total";

        public string Value
        {
            get { return Total.ToString().ToLowerInvariant(); }
        }
    }
}
