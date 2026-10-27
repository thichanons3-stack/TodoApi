using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApiV2.DTOs.Categories;
using TodoApiV2.Models;
using TodoApiV2.Data;

namespace TodoApiV2.Controllers;

[ApiController]
[Route("api/Categories")]
public class CategoriesController : ControllerBase
{
    private readonly TodoDb _context;
    public CategoriesController(TodoDb context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDetailDTO>>> GetCategories()
    {
        var categories = await _context.Categories.Include(c => c.todoItems)
        .ToListAsync();
        Console.WriteLine("Categories: ", categories);

        var result = categories.Select(c => new CategoryDetailDTO(c)).ToList();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDetailDTO>> GetCategory(int id)
    {
        var category = await _context.Categories.Include(c => c.todoItems).FirstOrDefaultAsync(c => c.Id == id);

        if (category == null)
        {
            return NotFound(new { message = "ไม่พบหมวดหมู่นี้ในระบบ" });
        }

        return Ok(new CategoryDetailDTO(category));
    }

    [HttpPost]
    public async Task<ActionResult<CategoryDetailDTO>> CreateCategory(CategoryCreateDTO dto)
    {
        var category = new Category
        {
            Name = dto.Name
        };

        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, new CategoryDetailDTO(category));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, Category category)
    {
        if (id != category.Id)
        {
            return BadRequest(new { message = "ID ใน URL และข้อมูลที่ส่งมาไม่ตรงกัน" });
        }

        // แจ้ง EF Core ให้ Track object นี้ และตั้งสถานะเป็น Modified เพื่อสั่งให้ออกคำสั่ง SQL UPDATE เมื่อ SaveChangesAsync
        _context.Entry(category).State = EntityState.Modified;

        // var existing = await _context.Categories.FindAsync(id);
        // if (existing == null) return NotFound();
        // existing.Name = category.Name;
        // await _context.SaveChangesAsync();


        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CategoryExists(id))
            {
                return NotFound(new { message = "ไม่พบหมวดหมู่ที่ต้องการแก้ไข" });
            }
            else
            {
                throw;
            }
        }

        return NoContent(); // Http 204: success but return nothing
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        // ค้นหาข้อมูลก่อนว่ามี ID นี้อยู่ในระบบหรือไม่
        var existing = await _context.Categories.FindAsync(id);

        // ถ้าไม่พบข้อมูลให้ส่ง Http 404 กลับไป
        if (existing == null) return NotFound();

        // ลบข้อมูลที่พบออกจาก Context
        _context.Categories.Remove(existing);

        // บันทึกการเปลี่ยนแปลงลง Database
        await _context.SaveChangesAsync();

        // ส่ง Http 204 กลับไป
        return NoContent();
    }

    // Helper method (private) เพื่อช่วยตรวจสอบว่ามี Category นี้อยู่หรือไม่
    private bool CategoryExists(int id)
    {
        return _context.Categories.Any(e => e.Id == id);
    }
}

