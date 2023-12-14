using Bookstore_WebAPI.Data;
using Bookstore_WebAPI.Interfaces;
using Bookstore_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore_WebAPI.Repository
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly DataContext _context;
        public PublisherRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreatePublisher(Publisher publisher)
        {
            _context.Add(publisher);
            return Save();
        }

        public Publisher GetPublisher(int id)
        {
            return _context.Publishers.Where(p => p.Id == id).FirstOrDefault();
        }

        public Publisher GetPublisher(string name)
        {
            return _context.Publishers.Where(p => p.Name == name).FirstOrDefault();
        }

        public ICollection<Publisher> GetPublishers()
        {
            return _context.Publishers.ToList();
        }

        public bool HasPublisher(int id)
        {
            return _context.Publishers.Any(p => p.Id == id);
        }

        public bool HasPublisher(string name)
        {
            return _context.Publishers.Any(p => p.Name == name);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
