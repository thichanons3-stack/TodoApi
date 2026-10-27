using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApiV2.Data;
using TodoApiV2.DTOs.TodoItem;
using TodoApiV2.Models;

namespace TodoApiV2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoItemsController : ControllerBase
{
    private readonly TodoDb _context;

    public TodoItemsController(TodoDb context)
    {
        _context = context;
    }

    // GET: api/todoitems
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
    {
        // ใช้ .Include() เพื่อดึงข้อมูล Category มาด้วย (ถ้าไม่ใส่ Category จะเป็น null)
        var todos = await _context.TodoItems.Include(t => t.Category).ToListAsync();
        var result = todos.Select(t => new TodoItemDTO(t)).ToList();
        return Ok(result);
    }

    // GET: api/todoitems/id
    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItemDTO>> GetTodoItem(int id)
    {
        var todo = await _context.TodoItems.FindAsync(id);
        if (todo == null)
        {
            return NotFound(new { message = "ไม่พบงานนี้ในระบบ" });
        }

        return Ok(new TodoItemDTO(todo));
    }

    // POST: api/todoitems
    [HttpPost]
    public async Task<ActionResult<TodoItemDTO>> CreateTodoItem(TodoItemDTO dto)
    {
        var categoryExists = await _context.Categories.AnyAsync(c => c.Id == dto.CategoryId);
        if (!categoryExists)
        {
            return BadRequest(new { message = $"ไม่พบหมวดหมู่ ID: {dto.CategoryId} ในระบบกรุณาตรวจสอบอีกครั้ง" });
        }

        var todoItem = new TodoItem
        {
            Title = dto.Title,
            IsComplete = dto.IsComplete,
            DueDate = dto.DueDate ?? DateTime.UtcNow.AddDays(1),
            CategoryId = dto.CategoryId
        };

        _context.TodoItems.Add(todoItem);
        await _context.SaveChangesAsync();

        await _context.Entry(todoItem).Reference(t => t.Category).LoadAsync();


        return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, new TodoItemDTO(todoItem));
    }

    // PUT: api/todoitems/id
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTodoItem(int id, TodoItemDTO dto)
    {
        var todoItem = await _context.TodoItems.FindAsync(id);
        if (todoItem is null) return NotFound(new { message = "ไม่พบงานที่ต้องการแก้ไข" });

        if (todoItem.CategoryId != dto.CategoryId)
        {
            var categoryExists = await _context.Categories.AnyAsync(c => c.Id == dto.CategoryId);
            if (!categoryExists) return BadRequest(new { message = $"หมวดหมู่ใหม่ ID: {dto.CategoryId} ไม่มีอยู่ในระบบ" });
        }


        todoItem.Title = dto.Title;
        todoItem.IsComplete = dto.IsComplete;
        if (dto.DueDate.HasValue)
        {
            todoItem.DueDate = dto.DueDate.Value;
        }
        todoItem.CategoryId = dto.CategoryId;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoItem(int id)
    {
        var todoItem = await _context.TodoItems.FindAsync(id);
        if (todoItem is null) return NotFound(new { message = "ไม่พบงานที่ต้องการลบ" });

        _context.TodoItems.Remove(todoItem);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}