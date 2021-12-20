using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Models
{
    public class ShopModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "The length must be in the range from 5 to 20 chars.")]
        public string Name { get; set; }

        public List<ShopItemModel> ShopItems { get; set; }
    }
}
