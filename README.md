Requirement C# 12+ & .NET 8+
Usage:
```c#
List<TableOption> tables =
[
    new TableOption
    {
        Name = "Products",
        ExcelPath = "products.xlsx",
    },
    new TableOption
    {
        Name = "PickUpPoints",
        ExcelPath = "pickUpPoints.xlsx"
    },
    new TableOption
    {
        Name = "Users",
        ExcelPath = "users.xlsx",
        UniqueColumns =
        [
            "ФИО"
        ]
    },
    new TableOption
    {
        Name = "Orders",
        ExcelPath = "orders.xlsx",
        ForeignKeys = [
            new ForeignKeyOption(
                "Адрес пункта выдачи",
                "PickUpPoints",
                "Id"
            ),
            new ForeignKeyOption(
                "ФИО авторизированного клиента",
                "Users",
                "ФИО"
            )
        ]
    }
];

var creator = new SqliteTableCreator("demo.sqlite");
creator.EasyCreateAndInsert("demo.sqlite", tables);
```