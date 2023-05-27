using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.huangbin.excel.core
{
    class Utils
    {
        public static bool IsNotBlankString(string content)
        {
            return content != null && !content.Trim().Equals("");
        }
    }
}
