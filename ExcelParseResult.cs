using System.Collections.Generic;


namespace com.huangbin.excel.core
{

    public struct ExcelResultError
    {
        public int SheetIdx;

        public int RowIdx;

        public int ColumnIdx;

        public List<string> Errors;


    }

    public struct ExcelParseResult<T>
    {
        public List<T> Data;


        public List<ExcelResultError> Errors;

        public bool hasErrors()
        {
            return Errors == null || Errors.Count == 0;
        }
    }
}
