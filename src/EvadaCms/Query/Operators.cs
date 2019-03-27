namespace Evada.Query
{
    public enum Operator
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

    internal static class OperatorExtensions
    {
        public static string ToOperatorString(this Operator op)
        {
            switch (op)
            {
                case Operator.Equals: return "";
                case Operator.NotEqual: return "[ne]";
                case Operator.Match: return "[match]";
                case Operator.LessThan: return "[lt]";
                case Operator.LessThanOrEqual: return "[lte]";
                case Operator.GreatherThan: return "[gt]";
                case Operator.GreatherThanOrEqual: return "[gte]";
                case Operator.All: return "[all]";
                case Operator.In: return "[in]";
                case Operator.NotIn: return "[nin]";
                case Operator.Exists: return "[exists]";
                default: return "=";
            }
        }
    }
}