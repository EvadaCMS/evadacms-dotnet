using System;

namespace Evada.QueryParameters
{
    public class LanguageParameter : QueryParameter
    {
        public string Language { get; }

        public LanguageParameter(string language)
        {
            Language = language;
        }

        public override string Name { get; } = "system.language";

        public override string Value
        {
            get { return Uri.EscapeDataString(Language); }
        }
    }
}
