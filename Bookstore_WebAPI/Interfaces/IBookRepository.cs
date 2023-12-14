using Bookstore_WebAPI.Models;

namespace Bookstore_WebAPI.Interfaces
{
    public interface IBookRepository
    {
        ICollection<Book> GetBooks();
        Book GetBook(int id);
        ICollection<Book> GetBooksByGenre(int genreId);
        bool HasBook(int id);
        bool HasBookByGenre(int genreId);
        bool CreateBook(Book book);
        bool UpdateBook(Book book);
        bool DeleteBook(Book book);
        bool Save();
    }
}
