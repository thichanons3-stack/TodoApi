using Microsoft.EntityFrameworkCore;
using TodoApiV2.Models;

namespace TodoApiV2.Data;

public class TodoDb : DbContext
{
    public TodoDb(DbContextOptions<TodoDb> options) : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    public DbSet<Category> Categories => Set<Category>();
}