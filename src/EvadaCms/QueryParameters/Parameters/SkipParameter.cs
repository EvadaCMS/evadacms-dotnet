namespace Evada.QueryParameters
{
    public class SkipParameter : QueryParameter
    {
        public int Skip { get; }

        public SkipParameter(int skip)
        {
            Skip = skip;
        }

        public override string Name { get; } = "skip";

        public override string Value
        {
            get { return Skip.ToString(); }
        }
    }
}
