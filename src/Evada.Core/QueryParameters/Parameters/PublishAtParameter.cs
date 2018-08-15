using System;

namespace Evada.Core.QueryParameters
{
    public class PublishAtParameter : IQueryParameter
    {
        public DateTime PublishAt { get; set; }
        public ParameterOperator ParameterOperator { get; set; }

        public PublishAtParameter(ParameterOperator parameterOperator, DateTime publishAt)
        {
            ParameterOperator = parameterOperator;
            PublishAt = publishAt;
        }

        public string Name
        {
            get
            {
                return $"system.publish_at{ParameterOperator.ToOperatorString()}";
            }
        }

        public string Value
        {
            get { return PublishAt.ToString(); }
        }
    }
}
