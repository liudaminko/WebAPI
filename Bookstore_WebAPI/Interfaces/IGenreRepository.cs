using Bookstore_WebAPI.Models;

namespace Bookstore_WebAPI.Interfaces
{
    public interface IGenreRepository
    {
        ICollection<Genre> GetGenres();
        Genre GetGenre(int id);
        bool HasGenre(int id);
        bool HasGenre(string name);
        bool CreateGenre(Genre genre);
        bool Save();
    }
}
