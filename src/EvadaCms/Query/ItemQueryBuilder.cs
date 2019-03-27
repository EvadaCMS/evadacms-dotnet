using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Evada.Query
{
    public class ItemQueryBuilder<T>
    {
        protected readonly List<KeyValuePair<string, string>> _queryKeyPairs = new List<KeyValuePair<string, string>>();

        public static ItemQueryBuilder<T> Initialize => new ItemQueryBuilder<T>();

        public ItemQueryBuilder<T> AddQueryParameter(string key, string value, Operator op)
        {
            var left = key + op.ToOperatorString();
            _queryKeyPairs.Add(new KeyValuePair<string, string>(left, value));
            return this;
        }

        public ItemQueryBuilder<T> WithLanguage(string languageCode)
        {
            var keyPair = new KeyValuePair<string, string>(ItemQueryKeys.Language, languageCode);
            var index = _queryKeyPairs.FindIndex(q => q.Key == ItemQueryKeys.Language);
            if (index == -1)
            {
                _queryKeyPairs.Add(keyPair);
            }
            else
            {
                _queryKeyPairs[index] = keyPair;
            }
            return this;
        }

        public ItemQueryBuilder<T> WithType(string typeId)
        {
            if (!Guid.TryParse(typeId, out Guid parsedTypeId))
            {
                throw new FormatException("Type ID is not in the correct format.");
            }

            var keyPair = new KeyValuePair<string, string>(ItemQueryKeys.TypeId, typeId);
            var index = _queryKeyPairs.FindIndex(q => q.Key == ItemQueryKeys.TypeId);
            if (index == -1)
            {
                _queryKeyPairs.Add(keyPair);
            }
            else
            {
                _queryKeyPairs[index] = keyPair;
            }
            return this;
        }

        public ItemQueryBuilder<T> Depth(int depth)
        {
            if (depth < 0 || depth > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(depth), "Depth parameter must be between 0 and 10.");
            }

            var keyPair = new KeyValuePair<string, string>(ItemQueryKeys.Depth, depth.ToString());
            var index = _queryKeyPairs.FindIndex(q => q.Key == ItemQueryKeys.Depth);
            if (index == -1)
            {
                _queryKeyPairs.Add(keyPair);
            }
            else
            {
                _queryKeyPairs[index] = keyPair;
            }
            return this;
        }

        public ItemQueryBuilder<T> Skip(int skip)
        {
            if (skip < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(skip), "Skip must be greater than or equal to 0.");
            }

            var keyPair = new KeyValuePair<string, string>(ItemQueryKeys.Skip, skip.ToString());
            var index = _queryKeyPairs.FindIndex(q => q.Key == ItemQueryKeys.Skip);
            if (index == -1)
            {
                _queryKeyPairs.Add(keyPair);
            }
            else
            {
                _queryKeyPairs[index] = keyPair;
            }
            return this;
        }

        public ItemQueryBuilder<T> Limit(int limit)
        {
            if (limit < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(limit), "Limit must be greater than 0");
            }

            var keyPair = new KeyValuePair<string, string>(ItemQueryKeys.Limit, limit.ToString());
            var index = _queryKeyPairs.FindIndex(q => q.Key == ItemQueryKeys.Limit);
            if (index == -1)
            {
                _queryKeyPairs.Add(keyPair);
            }
            else
            {
                _queryKeyPairs[index] = keyPair;
            }
            return this;
        }

        public ItemQueryBuilder<T> OrderBy(string orderby)
        {
            _queryKeyPairs.Add(new KeyValuePair<string, string>("order", orderby));
            return this;
        }

        public ItemQueryBuilder<T> ModuleEquals(string key, string value)
        {
            return AddQueryParameter(key, value, Operator.Equals);
        }

        public ItemQueryBuilder<T> ModuleEquals<R>(Expression<Func<T, R>> selector, string value)
        {
            var propertyName = QueryHelpers<T>.ResolvePropertyName(selector);
            return ModuleEquals(propertyName, value);
        }

        public ItemQueryBuilder<T> ModuleDoesNotEqual(string key, string value)
        {
            return AddQueryParameter(key, value, Operator.NotEqual);
        }

        public ItemQueryBuilder<T> ModuleDoesNotEqual<R>(Expression<Func<T, R>> selector, string value)
        {
            var propertyName = QueryHelpers<T>.ResolvePropertyName(selector);
            return ModuleDoesNotEqual(propertyName, value);
        }

        public ItemQueryBuilder<T> ModuleEqualsAll(string key, IEnumerable<string> values)
        {
            return AddQueryParameter(key, string.Join(",", values), Operator.All);
        }

        public ItemQueryBuilder<T> ModuleEqualsAll<R>(Expression<Func<T, R>> selector, IEnumerable<string> values)
        {
            var propertyName = QueryHelpers<T>.ResolvePropertyName(selector);
            return ModuleEqualsAll(propertyName, values);
        }

        public ItemQueryBuilder<T> ModuleIncludes(string key, IEnumerable<string> values)
        {
            return AddQueryParameter(key, string.Join(",", values), Operator.In);
        }

        public ItemQueryBuilder<T> ModuleIncludes<R>(Expression<Func<T, R>> selector, IEnumerable<string> values)
        {
            var propertyName = QueryHelpers<T>.ResolvePropertyName(selector);
            return ModuleIncludes(propertyName, values);
        }

        public ItemQueryBuilder<T> ModuleExcludes(string key, IEnumerable<string> values)
        {
            return AddQueryParameter(key, string.Join(",", values), Operator.NotIn);
        }

        public ItemQueryBuilder<T> ModuleExcludes<R>(Expression<Func<T, R>> selector, IEnumerable<string> values)
        {
            var propertyName = QueryHelpers<T>.ResolvePropertyName(selector);
            return ModuleExcludes(propertyName, values);
        }

        public ItemQueryBuilder<T> ModuleExists(string key, bool exists = true)
        {
            return AddQueryParameter(key, exists.ToString().ToLower(), Operator.Exists);
        }

        public ItemQueryBuilder<T> ModuleExists<R>(Expression<Func<T, R>> selector, bool exists = true)
        {
            var propertyName = QueryHelpers<T>.ResolvePropertyName(selector);
            return ModuleExists(propertyName, exists);
        }

        public ItemQueryBuilder<T> ModuleGreaterThan(string key, string value)
        {
            return AddQueryParameter(key, value, Operator.GreatherThan);
        }

        public ItemQueryBuilder<T> ModuleGreaterThan<R>(Expression<Func<T, R>> selector, string value)
        {
            var propertyName = QueryHelpers<T>.ResolvePropertyName(selector);
            return ModuleGreaterThan(propertyName, value);
        }

        public ItemQueryBuilder<T> ModuleLessThan(string key, string value)
        {
            return AddQueryParameter(key, value, Operator.LessThan);
        }

        public ItemQueryBuilder<T> ModuleLessThan<R>(Expression<Func<T, R>> selector, string value)
        {
            var propertyName = QueryHelpers<T>.ResolvePropertyName(selector);
            return ModuleLessThan(propertyName, value);
        }

        public ItemQueryBuilder<T> ModuleLessThanOrEqualTo(string key, string value)
        {
            return AddQueryParameter(key, value, Operator.LessThanOrEqual);
        }

        public ItemQueryBuilder<T> ModuleLessThanOrEqualTo<R>(Expression<Func<T, R>> selector, string value)
        {
            var propertyName = QueryHelpers<T>.ResolvePropertyName(selector);
            return ModuleLessThanOrEqualTo(propertyName, value);
        }

        public ItemQueryBuilder<T> ModuleGreaterThanOrEqualTo(string key, string value)
        {
            return AddQueryParameter(key, value, Operator.GreatherThanOrEqual);
        }

        public ItemQueryBuilder<T> ModuleGreaterThanOrEqualTo<R>(Expression<Func<T, R>> selector, string value)
        {
            var propertyName = QueryHelpers<T>.ResolvePropertyName(selector);
            return ModuleGreaterThanOrEqualTo(propertyName, value);
        }

        public ItemQueryBuilder<T> ModuleMatches(string key, string value)
        {
            return AddQueryParameter(key, value, Operator.Match);
        }

        public ItemQueryBuilder<T> ModuleMatches<R>(Expression<Func<T, R>> selector, string value)
        {
            var propertyName = QueryHelpers<T>.ResolvePropertyName(selector);
            return ModuleMatches(propertyName, value);
        }

        public ItemQueryBuilder<T> ModuleReferencesItem(string key, string id)
        {
            return AddQueryParameter(key, id, Operator.In);
        }

        public ItemQueryBuilder<T> ModuleReferencesItem<R>(Expression<Func<T, R>> selector, string id)
        {
            var propertyName = QueryHelpers<T>.ResolvePropertyName(selector);
            return ModuleReferencesItem(propertyName, id);
        }

        public ItemQueryBuilder<T> ModuleReferencesAsset(string key, string id)
        {
            return AddQueryParameter(key, id, Operator.In);
        }

        public ItemQueryBuilder<T> ModuleReferencesAsset<R>(Expression<Func<T, R>> selector, string id)
        {
            var propertyName = QueryHelpers<T>.ResolvePropertyName(selector);
            return ModuleReferencesAsset(propertyName, id);
        }

        public string Build(bool includeEmptyParameters = false)
        {
            return _queryKeyPairs
                .Aggregate(new StringBuilder(), (sb, kvp) =>
                {
                    if (kvp.Value != null)
                    {
                        if (sb.Length > 0)
                            sb = sb.Append("&");

                        sb.AppendFormat("{0}={1}", Uri.EscapeUriString(kvp.Key),
                            Uri.EscapeDataString(kvp.Value));
                    }
                    else if (includeEmptyParameters)
                    {
                        if (sb.Length > 0)
                            sb = sb.Append("&");

                        sb.AppendFormat("{0}", Uri.EscapeUriString(kvp.Key));
                    }

                    return sb;
                }).ToString();
        }

        public Dictionary<string, string> ToDictionary()
        {
            return _queryKeyPairs.ToDictionary(k => k.Key, v => v.Value);
        }
    }
}
