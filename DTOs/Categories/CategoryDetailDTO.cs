using TodoApiV2.Models;
using TodoApiV2.DTOs.TodoItem;
namespace TodoApiV2.DTOs.Categories;

public class CategoryDetailDTO
{
    public int Id {get; set;}
    public string? Name {get; set;}
    public List<TodoItemDTO> TodoItems {get; set;} = new();

    public CategoryDetailDTO(Category category)
    {
        Id = category.Id;
        Name = category.Name;
        TodoItems = category.todoItems.Select(t => new TodoItemDTO(t)).ToList();
    }
}