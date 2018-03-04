using System;

namespace Evada.Core.QueryParameters
{
    public class LanguageParameter : IQueryParameter
    {
        public string Language { get; }

        public LanguageParameter(string language)
        {
            Language = language;
        }

        public string Name { get; } = "lang";
        
        public string Value
        {
            get { return Uri.EscapeDataString(Language); }
        }
    }
}
