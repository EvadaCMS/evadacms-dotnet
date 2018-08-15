namespace Evada.Core.QueryParameters
{
    public class NameParameter : IQueryParameter
    {
        public string ItemName { get; set; }
        public ParameterOperator ParameterOperator { get; set; }

        public NameParameter(ParameterOperator parameterOperator, string itemName)
        {
            ParameterOperator = parameterOperator;
            ItemName = itemName;
        }

        public string Name
        {
            get
            {
                return $"system.name{ParameterOperator.ToOperatorString()}";
            }
        }

        public string Value
        {
            get { return ItemName; }
        }
    }
}
