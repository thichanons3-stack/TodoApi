namespace TodoApiV2.Models;


public class TodoItem
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public bool IsComplete { get; set; }
    public DateTime DueDate { get; set; }


    public int CategoryId { get; set; } // Foreinkey ชี้ไปที่ Category
    public Category? Category { get; set; } // Navigation property ไปหา Category
}