using PersonCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace PersonCrud.Data;

public class AppDbContext : DbContext
{
    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=PersonCrud.db");
    }
}