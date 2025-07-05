using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adr.GlobalUtils.Extensions {
    public static class DictionaryExtensions {
        public static void AddRange<TKey, TValue>(this Dictionary<TKey, TValue> dict, IEnumerable<KeyValuePair<TKey, TValue>> items) {
            foreach (var item in items) {
                dict[item.Key] = item.Value;
            }
        }
    }
}
