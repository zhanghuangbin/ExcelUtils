using NPOI.SS.UserModel;
using System.Collections.Generic;

namespace com.huangbin.excel.core
{
    public interface ExcelParseHandler<T>
    {

        void ParseTitile(IRow title);
        (T, List<ExcelResultError>) ParseDataRow(IRow row);
    }
}
