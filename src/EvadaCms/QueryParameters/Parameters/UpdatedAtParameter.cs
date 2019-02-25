using System;

namespace Evada.QueryParameters
{
    public class UpdatedAtParameter : QueryParameter
    {
        public DateTime UpdatedAt { get; set; }
        public ParameterOperator ParameterOperator { get; set; }

        public UpdatedAtParameter(ParameterOperator parameterOperator, DateTime updatedAt)
        {
            ParameterOperator = parameterOperator;
            UpdatedAt = updatedAt;
        }

        public override string Name
        {
            get
            {
                return $"system.updatedAt{ParameterOperator.ToOperatorString()}";
            }
        }

        public override string Value
        {
            get { return UpdatedAt.ToString(); }
        }
    }
}
