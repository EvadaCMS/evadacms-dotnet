using System;

namespace Evada.Core.QueryParameters
{
    public class CreatedAtParameter : QueryParameter
    {
        public DateTime CreatedAt { get; set; }
        public ParameterOperator ParameterOperator { get; set; }

        public CreatedAtParameter(ParameterOperator parameterOperator, DateTime createdAt)
        {
            ParameterOperator = parameterOperator;
            CreatedAt = createdAt;
        }

        public override string Name
        {
            get
            {
                return $"system.created_at{ParameterOperator.ToOperatorString()}";
            }
        }

        public override string Value
        {
            get { return CreatedAt.ToString(); }
        }
    }
}
