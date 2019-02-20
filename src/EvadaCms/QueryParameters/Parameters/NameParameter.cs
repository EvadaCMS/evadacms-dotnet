namespace Evada.QueryParameters
{
    public class NameParameter : QueryParameter
    {
        public string ItemName { get; set; }
        public ParameterOperator ParameterOperator { get; set; }

        public NameParameter(ParameterOperator parameterOperator, string itemName)
        {
            ParameterOperator = parameterOperator;
            ItemName = itemName;
        }

        public override string Name
        {
            get
            {
                return $"system.name{ParameterOperator.ToOperatorString()}";
            }
        }

        public override string Value
        {
            get { return ItemName; }
        }
    }
}
