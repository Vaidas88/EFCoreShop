using System.Collections.Generic;
using ShopApp.Models;

namespace ShopApp.ViewModels
{
    public class ShopItemViewModel
    {
        public ShopItemModel ShopItem { get; set; }

        public List<ShopModel> Shops { get; set; }

        public List<TagModel> Tags { get; set; }

        public List<int> SelectedTagIds { get; set; }
    }
}