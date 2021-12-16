using Microsoft.EntityFrameworkCore;
using ShopApp.Models;
using System.Linq;

namespace ShopApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
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
                 });

            modelBuilder.Entity<ShopItem>().HasData(
                new ShopItem()
                {
                    Id = 1,
                    Name = "Banana",
                    ShopId = 1
                },
                new ShopItem()
                {
                    Id = 2,
                    Name = "Apple",
                    ShopId = 1
                },
                new ShopItem()
                {
                    Id = 3,
                    Name = "Phone",
                    ShopId = 2
                },
                new ShopItem()
                {
                    Id = 4,
                    Name = "PC",
                    ShopId = 2
                },
                new ShopItem()
                {
                    Id = 5,
                    Name = "TV",
                    ShopId = 2
                },
                new ShopItem()
                {
                    Id = 6,
                    Name = "Potato",
                    ShopId = 1
                });
        }
    }
}
