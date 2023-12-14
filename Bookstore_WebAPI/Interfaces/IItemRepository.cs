using Bookstore_WebAPI.Models;

namespace Bookstore_WebAPI.Interfaces
{
    public interface IItemRepository
    {
        ICollection<Item> GetItems();
        Item GetItem(int id);
        Item GetItem(string name);
        bool HasItem(int id);
        bool HasItem(string name);
        bool CreateItem(Item item);
        bool Save();
    }
}
