using System;

namespace Evada.QueryParameters
{
    public class PublishAtParameter : QueryParameter
    {
        public DateTime PublishAt { get; set; }
        public ParameterOperator ParameterOperator { get; set; }

        public PublishAtParameter(ParameterOperator parameterOperator, DateTime publishAt)
        {
            ParameterOperator = parameterOperator;
            PublishAt = publishAt;
        }

        public override string Name
        {
            get
            {
                return $"system.publish_at{ParameterOperator.ToOperatorString()}";
            }
        }

        public override string Value
        {
            get { return PublishAt.ToString(); }
        }
    }
}
