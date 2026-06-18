
using System.Data;
using System.Text;

namespace ExcelToSqlite.Library.Mapping;

#pragma warning disable 1591
public class SqliteSchemaBuilder
{
    private readonly SqliteTypeMapper mapper;
    public SqliteSchemaBuilder()
    {
        mapper = new SqliteTypeMapper();
    }

    public string Build(
        string tn,
        DataTable dt
    )
    {
        var sql = new StringBuilder();

        sql.Append(
            $"CREATE TABLE IF NOT EXISTS [{tn}] ("
        );

        sql.Append(
            $"[Id] INTEGET PRIMARY KEY AUTOINCREMENT"
        );


        foreach(DataColumn column in dt.Columns)
        {
            sql.Append(", ");
            sql.Append(
                $"[{column.ColumnName}] "
            );
            sql.Append(
                $"{mapper.Map(column.DataType)}"
            );
        }

        sql.Append(");");
        return sql.ToString();
    }
}