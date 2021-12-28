using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopApp.Repositories
{
    public class ShopItemRepository : GenericRepository<ShopItemModel>
    {
        public ShopItemRepository(DataContext context) : base(context)
        {
        }

        public override IEnumerable<ShopItemModel> GetAll()
        {
            return _context.ShopItems
                .Include(s => s.Shop)
                .Include(t => t.Tags)
                    .ThenInclude(tag => tag.Tag)
                        .ToList();
        }
    }
}
