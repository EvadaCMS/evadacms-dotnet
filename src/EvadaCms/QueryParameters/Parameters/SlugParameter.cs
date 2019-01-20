namespace Evada.Core.QueryParameters
{
    public class SlugParameter : QueryParameter
    {
        public string Slug { get; set; }
        public ParameterOperator ParameterOperator { get; set; }

        public SlugParameter(ParameterOperator parameterOperator, string slug)
        {
            ParameterOperator = parameterOperator;
            Slug = slug;
        }

        public override string Name
        {
            get
            {
                return $"system.slug{ParameterOperator.ToOperatorString()}";
            }
        }

        public override string Value
        {
            get { return Slug; }
        }
    }
}
