using System;
using System.IO;
using Avalonia.Controls.Shapes;
using CustomersCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomersCrud.Data;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;User Id=postgres;Password=password;Database=CustomersCrud");
    }
}