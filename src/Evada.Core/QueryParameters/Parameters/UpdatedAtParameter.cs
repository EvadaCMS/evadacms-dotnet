using System;

namespace Evada.Core.QueryParameters
{
    public class UpdatedAtParameter : IQueryParameter
    {
        public DateTime UpdatedAt { get; set; }
        public ParameterOperator ParameterOperator { get; set; }

        public UpdatedAtParameter(ParameterOperator parameterOperator, DateTime updatedAt)
        {
            ParameterOperator = parameterOperator;
            UpdatedAt = updatedAt;
        }

        public string Name
        {
            get
            {
                return $"system.updated_at{ParameterOperator.ToOperatorString()}";
            }
        }

        public string Value
        {
            get { return UpdatedAt.ToString(); }
        }
    }
}
