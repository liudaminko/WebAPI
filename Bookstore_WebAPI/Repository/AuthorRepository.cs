using Bookstore_WebAPI.Data;
using Bookstore_WebAPI.Interfaces;
using Bookstore_WebAPI.Models;

namespace Bookstore_WebAPI.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;
        public AuthorRepository(DataContext context) 
        { 
            _context = context;
        }

        public bool CreateAuthor(Author author)
        {
            _context.Add(author);
            return Save();
        }

        public bool DeleteAuthor(Author author)
        {
            _context.Remove(author);
            return Save();
        }

        public Author GetAuthor(int id)
        {
            return _context.Author.Where(a => a.Id == id).FirstOrDefault();
        }

        public Author GetAuthor(string last_name)
        {
            return _context.Author.Where(a => a.LastName == last_name).FirstOrDefault();
        }

        public ICollection<Author> GetAuthors()
        {
            return _context.Author.OrderBy(a => a.Id).ToList();
        }

        public bool HasAuthor(int id)
        {
            return _context.Author.Any(a => a.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateAuthor(Author author)
        {
            _context.Update(author);
            return Save();
        }
    }
}
