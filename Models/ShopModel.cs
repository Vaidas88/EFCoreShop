using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Models
{
    public class ShopModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ShopItemModel> ShopItems { get; set; }
    }
}
