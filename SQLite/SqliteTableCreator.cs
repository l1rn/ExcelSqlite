using System.Text;
using System.Data;
using Microsoft.Data.Sqlite;
using ExcelToSqlite.Library.Mapping;

namespace ExcelToSqlite.Library.SQLite;

#pragma warning disable 1591
public class SqliteTableCreator : IDisposable
{
    private readonly SqliteConnection conn;
    public SqliteTableCreator(string connectionString)
    {
        conn = new SqliteConnection($"Data Source={connectionString}");
        conn.Open();
    }
    public void Create(
        string sql
    )
    {
        using var cmd =
            conn.CreateCommand();

        cmd.CommandText =
            sql.ToString();

        cmd.ExecuteNonQuery();
    }

    public void Insert(
        InsertOption iopts,
        DataTable dt
    )
    {
        using var tr = 
            conn.BeginTransaction();
        
        using var cmd = 
            conn.CreateCommand();
        cmd.CommandText = iopts.Sql;
        cmd.Transaction = tr;

        foreach(var p in iopts.Parameters)
        {
            cmd.Parameters.Add(
                new SqliteParameter(p, null)
            );
        }

        foreach(DataRow row in dt.Rows)
        {
            for(int i = 0; i < iopts.Columns.Count; i++)
            {
                cmd.Parameters[i].Value =
                    row[i] == DBNull.Value
                        ? DBNull.Value
                        : row[i];
            }


            cmd.ExecuteNonQuery();
        }
        tr.Commit();
    }

    public void EasyCreateAndInsert(string dbName, List<DataTable> dataTables)
    {
        var builder = new SqliteSchemaBuilder();
        InsertOption insertSql;
        var creator = new SqliteTableCreator(dbName);

        foreach(var dt in dataTables)
        {
            string creatSql = builder.BuildCreate(dt.TableName, dt);
            insertSql = builder.BuildInsert(dt.TableName, dt);
            creator.Create(creatSql);
            creator.Insert(insertSql, dt);
        }
    }
    public void Dispose()
    {
        conn.Dispose();
    }
}