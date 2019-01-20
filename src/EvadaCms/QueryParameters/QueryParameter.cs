namespace Evada.Core.QueryParameters
{
    public abstract class QueryParameter : IQueryParameter
    {
        public abstract string Value { get; }
        public abstract string Name { get; }
    }
}
