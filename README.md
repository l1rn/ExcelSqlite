Usage:
```c#
List<CreateDataTableOption> opts = new List<CreateDataTableOption>
{
    new("products.xlsx", "Products"),
};

List<DataTable> dataTables = ExcelReader.CreateDataTables(opts);
var creator = new SqliteTableCreator("demo.sqlite");

creator.EasyCreateAndInsert("demo.sqlite", dataTables);
```