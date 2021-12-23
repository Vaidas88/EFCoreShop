using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.Models
{
    public class ShopItemModel
    {
        public int Id { get; set; }

        [Display(Name = "Shop Item Name:")]
        [Required(ErrorMessage = "The name is required.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "The length must be in the range from 5 to 20 chars.")]
        public string Name { get; set; }

        public int ShopId { get; set; }

        public ShopModel Shop { get; set; }

        public DateTime ExpiryDate { get; set; } = DateTime.UtcNow + TimeSpan.FromDays(60);

        public bool IsDeleted { get; set; } = false;

        [Display(Name = "Tags:")]
        public List<TagModel> Tags { get; set; }
    }
}