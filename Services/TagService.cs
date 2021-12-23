using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Services
{
    public class TagService
    {
        private readonly DataContext _context;

        public TagService(DataContext context)
        {
            _context = context;
        }

        public List<TagModel> GetAll()
        {
            return _context.Tags.ToList();
        }

        public TagModel GetSingle(int id)
        {
            return _context.Tags.Find(id);
        }

        public void Create(TagModel tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
        }

        public void Edit(TagModel tag)
        {
            _context.Tags.Update(tag);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var tag = _context.Tags.Find(id);
            _context.Remove(tag);
            _context.SaveChanges();
        }
    }
}