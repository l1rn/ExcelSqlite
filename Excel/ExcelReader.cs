
using System.Data;
using System.Diagnostics;
using System.Text;
using ExcelDataReader;

namespace ExcelToSqlite.Library.Excel
{
    #pragma warning disable 1591
    public static class ExcelReader
    {
        public static DataTable Read(string filePath)
        {
            Encoding.RegisterProvider(
                CodePagesEncodingProvider.Instance
            );
            using(var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using(var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(
                        new ExcelDataSetConfiguration
                        {
                            ConfigureDataTable = (_) => 
                                new ExcelDataTableConfiguration
                                {
                                    UseHeaderRow = true
                                }
                        }
                    );
                    return result.Tables[0];
                }
            }
        }
        
        public static DataTable CreateDataTable(string path, string name)
        {
            DataTable table = Read(path);
            table.TableName = name;
            return table;
        }
        public static List<DataTable> CreateDataTables(List<CreateDataTableOption> options)
        {
            List<DataTable> dataTables = new List<DataTable>();
            foreach(var o in options)
            {
                dataTables.Append(CreateDataTable(o.Path, o.Name));
            }
            return dataTables;
        }
    }
}