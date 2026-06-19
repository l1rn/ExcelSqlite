namespace ExcelToSqlite.Library.Models;
#pragma warning disable 1591

public class InsertOption
{
    public required string Sql { get; init; }

    public required IReadOnlyList<string> Columns { get; init; }

    public required IReadOnlyList<string> Parameters { get; init; }
}