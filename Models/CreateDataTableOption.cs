namespace ExcelToSqlite.Library.Models;

#pragma warning disable 1591
public class CreateDataTableOption
{
    public string Path { set; get; }

    public string Name { set; get; }
    public CreateDataTableOption(string path, string name)
    {
        Path = path;
        Name = name;
    }
}