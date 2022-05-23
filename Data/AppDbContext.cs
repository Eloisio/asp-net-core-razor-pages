using Microsoft.EntityFrameworkCore;
using TWTodoList.Data.EntityConfigs;
using TWTodoList.Models;

namespace TWTodoList.Data;

public class AppDbContext : DbContext
{
    public DbSet<Todo> Todos => Set<Todo>();

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseSqlServer("Server=Localhost;Database=TWTodoList;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new TodoEntityConfig());
    }
}