
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

    public string BuildCreate(
        string tn,
        DataTable dt
    )
    {
        var sql = new StringBuilder();

        sql.Append(
            $"CREATE TABLE IF NOT EXISTS [{tn}] ("
        );

        sql.Append(
            $"[Id] INTEGER PRIMARY KEY AUTOINCREMENT"
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

    public InsertOption BuildInsert(
        string tn,
        DataTable dt
    )
    {
        List<string> columns = dt.Columns
            .Cast<DataColumn>()
            .Select(c => c.ColumnName)
            .ToList();
        
        List<string> parameters = columns
            .Select((_, i) => $"@p{i}")
            .ToList();

        string sql = 
            $"""
            INSERT INTO [{tn}]
            (
                {string.Join(",", columns.Select(c => $"[{c}]"))}
            )
            VALUES
            (
                {string.Join(",", parameters)}
            );
            """;
        
        return new InsertOption
        {
            Sql = sql,
            Columns = columns,
            Parameters = parameters
        };
    }
}