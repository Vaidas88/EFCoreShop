using System;

namespace ShopApp.Models
{
    public class ShopItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Shop Shop { get; set; }
        DateTime ExpiryDate { get; set; } = DateTime.UtcNow + TimeSpan.FromDays(60);
    }
}
