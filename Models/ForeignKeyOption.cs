namespace ExcelToSqlite.Library.Models;

#pragma warning disable 1591
public record ForeignKeyOption(
    string Column,
    string ReferencedTable,
    string ReferencedColumn
);