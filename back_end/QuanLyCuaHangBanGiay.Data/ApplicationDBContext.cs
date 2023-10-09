using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        #region DbSet

        public DbSet<Brand>? Brand { get; set; }
        public DbSet<Category>? Category { get; set; }
        public DbSet<Color>? Color { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Employer>? Employers { get; set; }
        public DbSet<Image>? Images { get; set; }
        public DbSet<Material>? Material { get; set; }
        public DbSet<Order>? Order { get; set; }
        public DbSet<OrderDetail>? OrderDetails { get; set; }
        public DbSet<Product>? Product { get; set; }
        public DbSet<ProductDetail>? ProductDetail { get; set; }
        public DbSet<Sale>? Sales { get; set; }
        public DbSet<SaleDetail>? SaleDetail { get; set; }
        public DbSet<Size>? Size { get; set; }

        #endregion
    }
}