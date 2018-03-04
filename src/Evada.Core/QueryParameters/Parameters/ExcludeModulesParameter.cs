namespace Evada.Core.QueryParameters
{
    public class ExcludeModulesParameter : IQueryParameter
    {
        public bool ExcludeModules { get; }

        public ExcludeModulesParameter(bool excludeModules)
        {
            ExcludeModules = excludeModules;
        }

        public string Name => "excludeModules";

        public string Value
        {
            get { return ExcludeModules.ToString().ToLowerInvariant(); }
        }
    }
}
