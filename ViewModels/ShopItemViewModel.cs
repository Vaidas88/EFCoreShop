using ShopApp.Models;
using System.Collections.Generic;

namespace ShopApp.ViewModels
{
    public class ShopItemViewModel : ShopItemModel
    {
        public ShopItemViewModel()
        {

        }
        public ShopItemViewModel(ShopItemModel shopItem)
        {
            Id = shopItem.Id;
            Name = shopItem.Name;
            ShopId = shopItem.ShopId;
            Shop = shopItem.Shop;
            ExpiryDate = shopItem.ExpiryDate;
        }
        public List<ShopModel> Shops { get; set; }
    }
}
