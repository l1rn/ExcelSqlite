
using System.Data;
using System.Diagnostics;
using System.Text;
using ExcelDataReader;

namespace ExcelToSqlite.Library.Excel
{
    #pragma warning disable 1591
    public static class ExcelReader
    {
        public static DataTable? Read(string filePath)
        {
            Encoding.RegisterProvider(
                CodePagesEncodingProvider.Instance
            );
            try
            {
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
            catch(Exception ex)
            {
                Console.WriteLine($"Failed to read the file: {ex.Message}");
            }
            return null;
        }
    }
}