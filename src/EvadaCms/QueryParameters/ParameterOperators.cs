namespace Evada.QueryParameters
{
    public enum ParameterOperator
    {
        Equals,
        NotEqual,
        LessThan,
        LessThanOrEqual,
        GreatherThan,
        GreatherThanOrEqual,
        Exists,
        Match,
        All,
        In,
        NotIn
    }

    internal static class ParameterOperatorExtensions
    {
        public static string ToOperatorString(this ParameterOperator parameterOperator)
        {
            switch (parameterOperator)
            {
                case ParameterOperator.Equals: return "";
                case ParameterOperator.NotEqual: return "[ne]";
                case ParameterOperator.Match: return "[match]";
                case ParameterOperator.LessThan: return "[lt]";
                case ParameterOperator.LessThanOrEqual: return "[lte]";
                case ParameterOperator.GreatherThan: return "[gt]";
                case ParameterOperator.GreatherThanOrEqual: return "[gte]";
                case ParameterOperator.All: return "[all]";
                case ParameterOperator.In: return "[in]";
                case ParameterOperator.NotIn: return "[nin]";
                case ParameterOperator.Exists: return "[exists]";
                default: return "=";
            }
        }
    }
}
