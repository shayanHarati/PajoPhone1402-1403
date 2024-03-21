using Microsoft.EntityFrameworkCore;
using PajoPhone.Datalayer.Models;
using PajoPhone.DataLayer.Models;

namespace PajoPhone.DataLayer;

public class Context:DbContext
{
    public Context(DbContextOptions<Context> options):base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Field> Fields { get; set; }
    public DbSet<FieldProduct> FieldProducts { get; set; }
    public DbSet<Category> Category { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<FieldProduct>().HasOne<Product>(c => c.Product)
            .WithMany(c => c.Fields)
            .HasForeignKey(c => c.FieldId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<FieldProduct>().HasOne<Field>(c => c.Field)
            .WithMany(c => c.Products)
            .HasForeignKey(c => c.FieldId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Category>().HasData(
            new Category()
            {
                Title = "موبایل",
                Id = 1
            }
        );
        
        
        modelBuilder.Entity<Product>().HasData(
            new Product()
            {
                ProductName = "محصول 1" ,
                ProductPrice = 12000000,
                ProductColor = "مشکی",
                ImageProduct = "p1.jpg",
                Id = 1,
                CategoryId = 1
            },
            new Product()
            {
                ProductName = "محصول 2" ,
                ProductPrice = 5000000,
                ProductColor = "سفید",
                ImageProduct = "p1.jpg",
                Id = 2,
                CategoryId = 1
            },
            new Product()
            {
                ProductName = "محصول 3" ,
                ProductPrice = 20000000,
                ProductColor = "مشکی",
                ImageProduct = "p1.jpg",
                Id = 3,
                CategoryId = 1
            },
            new Product()
            {
                ProductName = "محصول 4" ,
                ProductPrice = 500000,
                ProductColor = "مشکی",
                ImageProduct = "p1.jpg",
                Id = 4,
                CategoryId = 1
            }
            
            );
    }
}