namespace Evada.QueryParameters
{
    public class DepthParameter : QueryParameter
    {
        public int Depth { get; }

        public DepthParameter(int depth)
        {
            Depth = depth;
        }

        public override string Name { get; } = "depth";

        public override string Value
        {
            get { return Depth.ToString(); }
        }
    }
}
