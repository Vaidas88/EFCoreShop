using System.Collections.Generic;
using System.Linq;
using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Services
{
    public class ShopService
    {
        private readonly DataContext _context;

        public ShopService(DataContext context)
        {
            _context = context;
        }

        public List<ShopModel> GetAll()
        {
            return _context.Shops.ToList();
        }

        public ShopModel GetSingle(int id)
        {
            return _context.Shops.Find(id);
        }

        public void Create(ShopModel shop)
        {
            _context.Shops.Add(shop);
            _context.SaveChanges();
        }

        public void Edit(ShopModel shop)
        {
            _context.Shops.Update(shop);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var shop = _context.Shops.Find(id);
            _context.Remove(shop);
            _context.SaveChanges();
        }
    }
}