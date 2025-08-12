using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextDataAnalyzerProject
{
    //Extension method for FileInfo
    public static class FileInfoExtensions
    {
        public static bool IsTextFile(this FileInfo file)
        {

            if (file.Extension.Equals(".txt", StringComparison.OrdinalIgnoreCase)
)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsCsvFile(this FileInfo file)
        {

            if (file.Extension.Equals(".csv", StringComparison.OrdinalIgnoreCase)
)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
