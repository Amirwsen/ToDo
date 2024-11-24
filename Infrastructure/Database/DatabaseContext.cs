using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<ToDo> ToDoTable { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ToDo>().HasQueryFilter(todo => todo.IsDeleted == false);
        
        base.OnModelCreating(builder);
    }
}