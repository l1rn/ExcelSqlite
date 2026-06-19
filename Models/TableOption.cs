using System.Collections.Generic;

namespace ExcelToSqlite.Library.Models;
#pragma warning disable 1591

public class TableOption
{
    public required string Name { get; init; }

    public required string ExcelPath { get; init; }

    public List<ForeignKeyOption> ForeignKeys { get; init; }
        = [];

    public List<string> UniqueColumns { get; init; }
        = [];
}