using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public List<ShopItem> ShopItems { get; set; }
    }
}
