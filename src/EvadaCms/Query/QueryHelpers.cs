using Evada.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Evada.Query
{
    public static class QueryHelpers<T>
    {
        public static string ResolvePropertyName<R>(Expression<Func<T, R>> selector)
        {
            var members = new List<string>();
            var member = selector.Body as MemberExpression;
            if (member == null)
            {
                return string.Empty;
            }

            while (member != null)
            {
                if (member.Type == typeof(ItemSystem))
                {
                    members.Add("system");
                }
                else
                {
                    var propAttribute = member.Member.GetCustomAttribute<JsonPropertyAttribute>();
                    string moduleName;
                    if (propAttribute != null)
                    {
                        moduleName = propAttribute.PropertyName;
                    }
                    else
                    {
                        moduleName = member.Member.Name.ToCamelCase();
                    }
                    members.Add(moduleName);
                }

                member = member.Expression as MemberExpression;
            }

            if (members.LastOrDefault() != "system" && members.LastOrDefault() != "modules")
            {
                members.Add("modules");
            }

            return string.Join(".", members.Reverse<string>());
        }
    }
}
