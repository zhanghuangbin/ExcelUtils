namespace com.huangbin.excel.core
{
    /**
     * Excel读取策略 
     * @see AttributeExcelReadStrategy
     */
    public class ExcelReadStrategy<T>
    {
        
        int sheetIdx;
        int titleRowIdx;
        int dataRowIdx;
        ExcelParseHandler<T> parseHandler;

        public ExcelReadStrategy(ExcelParseHandler<T> handler): this(0, 0, 1, handler){}

        public ExcelReadStrategy(int sheetIdx, int titleRowIdx, int dataRowIdx, ExcelParseHandler<T> handler)
        {
            this.sheetIdx = sheetIdx;
            this.titleRowIdx = titleRowIdx;
            this.dataRowIdx = dataRowIdx;
            this.parseHandler = handler;
        }

        public int TitleRowIdx { get => titleRowIdx; set => titleRowIdx = value; }
        public int SheetIdx { get => sheetIdx; set => sheetIdx = value; }
        public int DataRowIdx { get => dataRowIdx; set => dataRowIdx = value; }
        public ExcelParseHandler<T> ParseHandler { get => parseHandler; set => parseHandler = value; }
    }
}
