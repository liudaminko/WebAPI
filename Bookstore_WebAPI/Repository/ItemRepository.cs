using Bookstore_WebAPI.Data;
using Bookstore_WebAPI.Interfaces;
using Bookstore_WebAPI.Models;
using System.Data;

namespace Bookstore_WebAPI.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext _context;
        public ItemRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateItem(Item item)
        {
            _context.Add(item);
            return Save();
        }

        public Item GetItem(int id)
        {
            return _context.Items.Where(i => i.Id == id).FirstOrDefault();
        }

        public Item GetItem(string name)
        {
            return _context.Items.Where(i => i.Name == name).FirstOrDefault();
        }

        public ICollection<Item> GetItems()
        {
            return _context.Items.ToList();
        }

        public bool HasItem(int id)
        {
            return _context.Items.Any(i => i.Id == id);
        }

        public bool HasItem(string name)
        {
            return _context.Items.Any(i => i.Name== name);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
