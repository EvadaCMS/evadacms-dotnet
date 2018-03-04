namespace Evada.Core.QueryParameters
{
    public class DepthParameter : IQueryParameter
    {
        public int Depth { get; }

        public DepthParameter(int depth)
        {
            Depth = depth;
        }

        public string Name { get; } = "depth";

        public string Value
        {
            get { return Depth.ToString(); }
        }
    }
}
