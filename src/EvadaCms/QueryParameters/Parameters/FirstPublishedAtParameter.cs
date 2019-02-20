using System;

namespace Evada.QueryParameters
{
    public class FirstPublishedAtParameter : QueryParameter
    {
        public DateTime FirstPublishedAt { get; set; }
        public ParameterOperator ParameterOperator { get; set; }

        public FirstPublishedAtParameter(ParameterOperator parameterOperator, DateTime firstPublishedAt)
        {
            ParameterOperator = parameterOperator;
            FirstPublishedAt = firstPublishedAt;
        }

        public override string Name
        {
            get
            {
                return $"system.first_published_at{ParameterOperator.ToOperatorString()}";
            }
        }

        public override string Value
        {
            get { return FirstPublishedAt.ToString(); }
        }
    }
}
