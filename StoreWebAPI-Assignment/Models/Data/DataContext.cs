using Microsoft.EntityFrameworkCore;
using StoreWebAPI_Assignment.Models.Category;
using StoreWebAPI_Assignment.Models.Order;
using StoreWebAPI_Assignment.Models.Product;
using StoreWebAPI_Assignment.Models.User;

namespace StoreWebAPI_Assignment.Models.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual DbSet<UserEntity> Users { get; set; } = null!;
        public virtual DbSet<CategoryEntity> Categories { get; set; } = null!;
        public virtual DbSet<ProductEntity> Products { get; set; } = null!;
        public virtual DbSet<OrderEntity> Orders { get; set; } = null!;
        public virtual DbSet<OrderRowEntity> OrderRows { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderRowEntity>()
                .HasKey(c => new { c.OrderId, c.ArticleNumber });

        }
    }
}
