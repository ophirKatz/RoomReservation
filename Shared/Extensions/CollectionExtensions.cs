using System.Collections.Generic;
using System.Linq;

namespace Shared.Extensions
{
    public static class CollectionExtensions
    {
        public static Dictionary<TKey, TValue> CombineWith<TKey, TValue>(this Dictionary<TKey, TValue> dict,
            Dictionary<TKey, TValue> dict2)
        {
            var newDict = new Dictionary<TKey, TValue>(dict);
            dict2.ToList().ForEach(x => newDict[x.Key] = x.Value);
            return newDict;
        }
    }
}