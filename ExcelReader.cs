using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace com.huangbin.excel.core
{
    /**
     * 
     * 
     */
    public interface ExcelReader<T>
    {


        ExcelParseResult<T> ParseExcel(Stream stream, ExcelReadStrategy<T> strategy);

        ExcelParseResult<T> ParseExcel(String filePath, ExcelReadStrategy<T> strategy);
    }
}
