using com.huangbin.excel.core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NPOI.SS.UserModel;



namespace com.huangbin.excel.impl
{
    class ExcelReaderImpl<T> : ExcelReader<T>
    {
        public ExcelParseResult<T> ParseExcel(Stream stream, ExcelReadStrategy<T> strategy)
        {
            IWorkbook wb = WorkbookFactory.Create(stream);
            ISheet sheet = wb.GetSheetAt(strategy.SheetIdx);

            IRow title = sheet.GetRow(strategy.TitleRowIdx);
            if (title == null)
            {
                throw new FormatException("excel未包含标题行");
            }

            ExcelParseHandler<T> handler = strategy.ParseHandler;
            if (handler == null)
            {
                throw new ArgumentNullException("strategy's ExcelParseHandler can not be null");
            }
            handler.ParseTitile(title);

            ExcelParseResult<T> result = new ExcelParseResult<T>();
            result.Data = new List<T>(sheet.PhysicalNumberOfRows);
            result.Errors = new List<ExcelResultError>(0);
            int startIdx = strategy.DataRowIdx < 0 ? 1 : strategy.DataRowIdx;
            for (int i = startIdx; i < sheet.PhysicalNumberOfRows; i++)
            {
                IRow row = sheet.GetRow(i);
                if (row == null || IsBlankRow(row))
                {
                    continue;
                } else
                {
                    (T data, List<ExcelResultError> errors) = handler.ParseDataRow(row);
                    if (errors == null || errors.Count == 0)
                    {
                        result.Data.Add(data);
                    } else
                    {
                        result.Errors.AddRange(errors.AsEnumerable());
                    }
                   
                }
            }

            return result;
        }

        public ExcelParseResult<T> ParseExcel(string filePath, ExcelReadStrategy<T> strategy)
        {
            using(Stream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                return ParseExcel(fileStream, strategy);
            }
        }

        private bool IsBlankRow(IRow row)
        {
           
            for (int i = 0; i <= row.LastCellNum; i++)
            {
                ICell cell = row.GetCell(i);
                if (cell != null)
                {
                    bool isNotBlank = Utils.IsNotBlankString(cell.StringCellValue) || Utils.IsNotBlankString(cell.StringCellValue);
                    if (isNotBlank)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

       
    }




}
