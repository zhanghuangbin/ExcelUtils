using com.huangbin.excel.core;
using System;



namespace com.huangbin.excel.impl
{
    public class AttributeExcelReadStrategy<T> : ExcelReadStrategy<T>
    {

        public AttributeExcelReadStrategy(Type type): base(new AttributeParseHandler<T>(type))
        {
            
        }
       

        public AttributeExcelReadStrategy(Type type, int sheetIdx, int titleRowIdx, int dataRowIdx) : base(sheetIdx, titleRowIdx, dataRowIdx, new AttributeParseHandler<T>(type))
        {
        }
    }




}
