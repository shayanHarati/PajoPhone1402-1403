using Microsoft.EntityFrameworkCore;
using PajoPhone.Datalayer.Models;

namespace PajoPhone.DataLayer;

public class Context:DbContext
{
    public Context(DbContextOptions<Context> options):base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}