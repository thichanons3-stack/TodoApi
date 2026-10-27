using System.ComponentModel.DataAnnotations;

namespace TodoApiV2.DTOs.Categories;

public class CategoryCreateDTO
{
    [Required(ErrorMessage = "กรุณาระบุชื่อหมวดหมู่")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "ชื่อหมวดหมู่ต้องมีความยาวระหว่าง 2 ถึง 30 ตัวอักษร")]
    public string? Name { get; set; }
}