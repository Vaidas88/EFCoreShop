using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Models
{
    public class ShopItemModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "The length can be in the range from 5 to 20 chars.")]
        public string Name { get; set; }

        public int ShopId { get; set; }

        public ShopModel Shop { get; set; }

        public DateTime ExpiryDate { get; set; } = DateTime.UtcNow + TimeSpan.FromDays(60);
    }
}
