using System;

namespace Evada.Query
{
    public static class StringHelpers
    {
        public static string ToCamelCase(this string value)
        {
            if (value == null || value.Length < 2)
                return value;

            // Split the string into words.
            string[] words = value.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);

            // Combine the words.
            string result = words[0].ToLower();
            for (int i = 1; i < words.Length; i++)
            {
                result += words[i].Substring(0, 1).ToUpper() + words[i].Substring(1);
            }

            return result;
        }
    }
}
