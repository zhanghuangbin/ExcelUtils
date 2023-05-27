using com.huangbin.excel.core;
using System;
using System.Collections.Generic;
using NPOI.SS.UserModel;



namespace com.huangbin.excel.impl
{


    public delegate void ApplyAction<T>(string val, T data, List<ExcelResultError> errors);
    public abstract class AbstracrDefaultExcelParseHandler<T> : ExcelParseHandler<T>
    {

        protected Type modelType;

        protected Dictionary<int, ApplyAction<T>> parseRules = new Dictionary<int, ApplyAction<T>>();

        protected AbstracrDefaultExcelParseHandler(Type modelType)
        {
            this.modelType = modelType;
        }

        public void ParseTitile(IRow title)
        {
            for (int i = 0; i <= title.LastCellNum; i++)
            {
                ICell cell = title.GetCell(i);
                if (cell == null)
                {
                    continue;
                }
                String val = GetCellValue(cell);
                parseRules.Add(i, CreateParseRule(i, val));
            }
        }
      
        public (T, List<ExcelResultError>) ParseDataRow(IRow row)
        {
            T data = (T)Activator.CreateInstance(modelType);
            List<ExcelResultError> errors = new List<ExcelResultError>();

            for (int i = 0; i <= row.LastCellNum; i++)
            {
                ICell cell = row.GetCell(i);
                if (cell == null)
                {
                    continue;
                }
                String val = GetCellValue(cell);
                if (parseRules.ContainsKey(cell.ColumnIndex))
                {
                    ApplyAction<T> doAction = parseRules[cell.ColumnIndex];
                    doAction(val, data, errors);
                }  
            }

            return (data, errors);
        }


        protected String GetCellValue(ICell cell)
        {
            // TODO 
            return cell.StringCellValue;
        }


        protected abstract ApplyAction<T> CreateParseRule(int i, string title);
    }




}
