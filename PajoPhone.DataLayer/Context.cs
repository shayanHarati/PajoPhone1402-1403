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
        modelBuilder.Entity<Product>().HasData(
            new Product()
            {
                ProductName = "محصول 1" ,
                ProductPrice = 12000000,
                ProductColor = "مشکی",
                ImageProduct = "p1.jpg",
                Id = 1
            },
            new Product()
            {
                ProductName = "محصول 2" ,
                ProductPrice = 5000000,
                ProductColor = "سفید",
                ImageProduct = "p1.jpg",
                Id = 2
            },
            new Product()
            {
                ProductName = "محصول 3" ,
                ProductPrice = 20000000,
                ProductColor = "مشکی",
                ImageProduct = "p1.jpg",
                Id = 3
            },
            new Product()
            {
                ProductName = "محصول 4" ,
                ProductPrice = 500000,
                ProductColor = "مشکی",
                ImageProduct = "p1.jpg",
                Id = 4
            }
            
            );
    }
}