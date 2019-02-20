namespace Evada.QueryParameters
{
    public class TotalParameter :QueryParameter
    {
        public bool Total { get; }

        public TotalParameter(bool total)
        {
            Total = total;
        }

        public override string Name { get; } = "total";

        public override string Value
        {
            get { return Total.ToString().ToLowerInvariant(); }
        }
    }
}
