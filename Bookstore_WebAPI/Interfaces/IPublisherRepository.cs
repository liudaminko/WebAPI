using Bookstore_WebAPI.Models;

namespace Bookstore_WebAPI.Interfaces
{
    public interface IPublisherRepository
    {
        ICollection<Publisher> GetPublishers();
        Publisher GetPublisher(int id);
        Publisher GetPublisher(string name);
        bool HasPublisher(int id);
        bool HasPublisher(string name);
        bool CreatePublisher(Publisher publisher);
        bool Save();
    }
}
