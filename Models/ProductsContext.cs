using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ProductsAPI.Models
{
    public class ProductsContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {

        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData
            (new Product() { ProductId = 1, ProductName = "Iphone 14", ProductPrice = 60000, IsActive = true });

            modelBuilder.Entity<Product>().HasData
           (new Product() { ProductId = 2, ProductName = "Iphone 15", ProductPrice = 70000, IsActive = true });

            modelBuilder.Entity<Product>().HasData
           (new Product() { ProductId = 3, ProductName = "Iphone 16", ProductPrice = 80000, IsActive = true });

            modelBuilder.Entity<Product>().HasData
           (new Product() { ProductId = 4, ProductName = "Iphone 17", ProductPrice = 90000, IsActive = false });

            modelBuilder.Entity<Product>().HasData
           (new Product() { ProductId = 5, ProductName = "Iphone 18", ProductPrice = 95000, IsActive = true });
        }


        public DbSet<Product> Products { get; set; }
    }
}