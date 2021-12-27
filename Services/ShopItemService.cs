using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Services
{
    public class ShopItemService
    {
        private readonly DataContext _context;

        public ShopItemService(DataContext context)
        {
            _context = context;
        }

        public List<ShopItemModel> GetAll()
        {
            return _context.ShopItems
                .Include(s => s.Shop)
                .Include(t => t.Tags)
                    .ThenInclude(tag => tag.Tag)
                        .ToList();
        }

        public List<ShopItemModel> GetAllByShopId(int id)
        {
            return _context.ShopItems.Where(item => item.ShopId == id)
                .Include(s => s.Shop)
                .Include(t => t.Tags)
                    .ThenInclude(tag => tag.Tag).ToList();
        }

        public ShopItemModel GetSingle(int id)
        {
            return _context.ShopItems.Find(id);
        }

        public void Create(ShopItemModel shopItem)
        {
            _context.ShopItems.Add(shopItem);
            _context.SaveChanges();
        }

        public void Edit(ShopItemModel shopItem)
        {
            _context.ShopItems.Update(shopItem);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var shopItem = _context.ShopItems.Find(id);
            _context.Remove(shopItem);
            _context.SaveChanges();
        }
    }
}