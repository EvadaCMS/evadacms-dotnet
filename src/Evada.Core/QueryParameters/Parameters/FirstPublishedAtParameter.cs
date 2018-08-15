using System;

namespace Evada.Core.QueryParameters
{
    public class FirstPublishedAtParameter : IQueryParameter
    {
        public DateTime FirstPublishedAt { get; set; }
        public ParameterOperator ParameterOperator { get; set; }

        public FirstPublishedAtParameter(ParameterOperator parameterOperator, DateTime firstPublishedAt)
        {
            ParameterOperator = parameterOperator;
            FirstPublishedAt = firstPublishedAt;
        }

        public string Name
        {
            get
            {
                return $"system.first_published_at{ParameterOperator.ToOperatorString()}";
            }
        }

        public string Value
        {
            get { return FirstPublishedAt.ToString(); }
        }
    }
}
