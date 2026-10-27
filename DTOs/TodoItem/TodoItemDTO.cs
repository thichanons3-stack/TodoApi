namespace TodoApiV2.DTOs.TodoItem;

using System.ComponentModel.DataAnnotations;
using TodoApiV2.Models;

public class TodoItemDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "กรุณาระบุหัวข้องาน")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "หัวข้องานต้องมีความยาวระหว่าง 3 ถึง 100 ตัวอักษร")]
    public string? Title { get; set; }

    public bool IsComplete { get; set; }
    public DateTime? DueDate { get; set; }

    [Required(ErrorMessage = "กรุณาระบุรหัสหมวดหมู่")]
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public TodoItemDTO() { }


    //public TodoItemDTO(TodoItem todo) => (Id, Title, IsComplete, DueDate, CategoryId, CategoryName) = (todo.Id, todo.Title, todo.IsComplete, todo.DueDate, todo.CategoryId, todo.Category?.Name);

    public TodoItemDTO(TodoItem todo)
    {
        Id = todo.Id;
        Title = todo.Title;
        IsComplete = todo.IsComplete;
        DueDate = todo.DueDate;
        CategoryId = todo.CategoryId;
        CategoryName = todo.Category?.Name;

        if (todo.Category != null)
        {
            CategoryName = todo.Category.Name;
        }
        else
        {
            CategoryName = null;
        }
    }
}