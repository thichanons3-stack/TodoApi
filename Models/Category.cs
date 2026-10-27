namespace TodoApiV2.Models;

public class Category
{
    public int Id {get;set;}
    public string? Name {get; set;}

    public List<TodoItem> todoItems {get; set;} = new();
}