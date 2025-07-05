using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adr.GlobalUtils.Utils {
    public class DictionaryUtils {
        public static Dictionary<string, TValue> AppendKeyPaths<TValue>(string startingPath, Dictionary<string, TValue> pairs) {
            var result = new Dictionary<string, TValue>();

            foreach (var item in pairs) {
                var newKey = Path.Combine(startingPath, item.Key);
                result[newKey] = item.Value;
            }
            
            return result;
        }

        public static Dictionary<string, TValue> NormalizeKeyPaths<TValue>(Dictionary<string, TValue> input) {
            var normalized = new Dictionary<string, TValue>();

            foreach (var kvp in input) {
                string normalizedKey = kvp.Key.Replace('\\', '/');

                if (!normalized.ContainsKey(normalizedKey)) {
                    normalized[normalizedKey] = kvp.Value;
                }
                else {
                    // conflict after normalization
                    normalized[normalizedKey] = kvp.Value; // overwrite the orig
                }
            }

            return normalized;
        }
    }
}
