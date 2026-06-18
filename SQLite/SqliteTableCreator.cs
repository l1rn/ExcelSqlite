using System.Text;
using System.Data;
using Microsoft.Data.Sqlite;

namespace ExcelToSqlite.Library.SQLite;

#pragma warning disable 1591
public class SqliteTableCreator
{
    public void Create(
        string dbPath,
        string tableName,
        DataTable dt
    )
    {
        using var conn = 
        new SqliteConnection(
            $"Data Source=${dbPath}"
        );

        
        using var cmd =
            conn.CreateCommand();

        cmd.CommandText =
            sql.ToString();

        cmd.ExecuteNonQuery();
    }
}