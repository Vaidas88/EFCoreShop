using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Models
{
    public class ShopItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ShopId { get; set; }

        public Shop Shop { get; set; }
        public DateTime ExpiryDate { get; set; } = DateTime.UtcNow + TimeSpan.FromDays(60);
    }
}
