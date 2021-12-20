using Microsoft.EntityFrameworkCore;
using ShopApp.Models;
using System.Linq;

namespace ShopApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<ShopModel> Shops { get; set; }
        public DbSet<ShopItemModel> ShopItems { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShopModel>().HasData(
                new ShopModel()
                {
                    Id = 1,
                    Name = "Food Shop"
                },
                 new ShopModel()
                 {
                     Id = 2,
                     Name = "Electronics Shop"
                 });

            modelBuilder.Entity<ShopItemModel>().HasData(
                new ShopItemModel()
                {
                    Id = 1,
                    Name = "Banana",
                    ShopId = 1
                },
                new ShopItemModel()
                {
                    Id = 2,
                    Name = "Apple",
                    ShopId = 1
                },
                new ShopItemModel()
                {
                    Id = 3,
                    Name = "Phone",
                    ShopId = 2
                },
                new ShopItemModel()
                {
                    Id = 4,
                    Name = "PC",
                    ShopId = 2
                },
                new ShopItemModel()
                {
                    Id = 5,
                    Name = "TV",
                    ShopId = 2
                },
                new ShopItemModel()
                {
                    Id = 6,
                    Name = "Potato",
                    ShopId = 1
                });
        }
    }
}
