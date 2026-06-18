namespace ExcelToSqlite.Library.Mapping;

#pragma warning disable 1591
public class SqliteTypeMapper{
    public string Map(Type type)
    {
        if(type == typeof(int) ||
            type == typeof(bool) ||
            type == typeof(long) ||
            type == typeof(short))
        {
            return "INTEGER";
        }

        if(type == typeof(double) ||
           type == typeof(float) ||
           type == typeof(decimal))
        {
            return "REAL";
        }

        return "TEXT";
    }
}