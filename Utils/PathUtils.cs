using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adr.GlobalUtils.Utils {
    public class PathUtils {
        public static string ConvertToRelative(string absolutePath, string rootDirectory) {
            if (string.IsNullOrEmpty(absolutePath) || string.IsNullOrEmpty(rootDirectory)) {
                return absolutePath;
            }

            try {
                if (!rootDirectory.EndsWith(Path.DirectorySeparatorChar.ToString())) {
                    rootDirectory += Path.DirectorySeparatorChar;
                }

                var absoluteUri = new Uri(absolutePath);
                var rootUri = new Uri(rootDirectory);

                var relativeUri = rootUri.MakeRelativeUri(absoluteUri);
                var relativePath = Uri.UnescapeDataString(relativeUri.ToString());

                return relativePath.Replace('/', Path.DirectorySeparatorChar);
            }
            catch {
                return absolutePath;
            }
        }

        public static string NormalizePath(string path) {
            if (string.IsNullOrEmpty(path)) {
                return path;
            }

            return path.Replace('\\', '/');
        }
    }
}