namespace Evada.Core.QueryParameters
{
    public class SlugParameter : IQueryParameter
    {
        public string Slug { get; set; }
        public ParameterOperator ParameterOperator { get; set; }

        public SlugParameter(ParameterOperator parameterOperator, string slug)
        {
            ParameterOperator = parameterOperator;
            Slug = slug;
        }

        public string Name
        {
            get
            {
                return $"system.slug{ParameterOperator.ToOperatorString()}";
            }
        }

        public string Value
        {
            get { return Slug; }
        }
    }
}
