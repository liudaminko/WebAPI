using Bookstore_WebAPI.Data;
using Bookstore_WebAPI.Interfaces;
using Bookstore_WebAPI.Models;

namespace Bookstore_WebAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public Book GetBook(int id)
        {
            return _context.Books.Where(b => b.ItemId == id).FirstOrDefault();
        }

        public ICollection<Book> GetBooksByGenre(int genreId)
        {
            return _context.Books.Where(b => b.GenreId == genreId).ToList();
        }

        public ICollection<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public bool HasBook(int id)
        {
            return _context.Books.Any(b => b.ItemId == id);
        }

        public bool CreateBook(Book book)
        {
            _context.Add(book);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool HasBookByGenre(int genreId)
        {
            return _context.Books.Any(b => b.GenreId == genreId);
        }

        public bool UpdateBook(Book book)
        {
            _context.Update(book);
            return Save();
        }

        public bool DeleteBook(Book book)
        {
            _context.Remove(book);
            return Save();
        }
    }
}
