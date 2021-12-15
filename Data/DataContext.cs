using Microsoft.EntityFrameworkCore;
using ShopApp.Models;

namespace ShopApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>().HasData(
                new Shop()
                {
                    Id = 1,
                    Name = "Food Shop"
                },
                 new Shop()
                 {
                     Id = 2,
                     Name = "Electronics Shop"
                 },
                new Shop()
                {
                    Id = 3,
                    Name = "Cosmetics Shop"
                });

            modelBuilder.Entity<ShopItem>().HasData(
                new ShopItem()
                {
                    Id = 1,
                    Name = "Banana"
                    
                },
                 new ShopItem()
                 {
                     Id = 2,
                     Name = "Electronics Shop"
                 },
                new ShopItem()
                {
                    Id = 3,
                    Name = "Cosmetics Shop"
                });
        }*/
    }
}
