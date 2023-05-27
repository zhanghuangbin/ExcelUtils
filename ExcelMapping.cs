using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.huangbin.excel.impl
{
    [AttributeUsage(AttributeTargets.Field |AttributeTargets.Property,AllowMultiple = false)]
    class ExcelMapping: Attribute
    {

        public string Titile
        {
            get;
        }
    }
}
