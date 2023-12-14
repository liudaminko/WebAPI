using Bookstore_WebAPI.Data;
using Bookstore_WebAPI.Interfaces;
using Bookstore_WebAPI.Models;

namespace Bookstore_WebAPI.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly DataContext _context;
        public GenreRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateGenre(Genre genre)
        {
            _context.Add(genre);
            return Save();
        }

        public Genre GetGenre(int id)
        {
            return _context.Genres.Where(g => g.Id == id).FirstOrDefault();
        }

        public Genre GetGenre(string name)
        {
            return _context.Genres.Where(g => g.Name == name).FirstOrDefault();
        }

        public bool HasGenre(int id)
        {
            return _context.Genres.Any(g => g.Id == id);
        }

        public bool HasGenre(string name)
        {
            return _context.Genres.Any(g => g.Name == name);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        ICollection<Genre> IGenreRepository.GetGenres()
        {
            return _context.Genres.ToList();
        }
    }
}
