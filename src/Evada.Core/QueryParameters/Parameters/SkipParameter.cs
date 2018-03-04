namespace Evada.Core.QueryParameters
{
    public class SkipParameter : IQueryParameter
    {
        public int Skip { get; }

        public SkipParameter(int skip)
        {
            Skip = skip;
        }

        public string Name { get; } = "skip";

        public string Value
        {
            get { return Skip.ToString(); }
        }
    }
}
