namespace ShopApp.Models
{
    public class ShopItemTagModel
    {
        public int ShopItemId { get; set; }

        public ShopItemModel ShopItem { get; set; }

        public int TagId { get; set; }

        public TagModel Tag { get; set; }
    }
}
