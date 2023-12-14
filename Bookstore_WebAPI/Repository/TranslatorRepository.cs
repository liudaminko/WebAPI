using Bookstore_WebAPI.Data;
using Bookstore_WebAPI.Interfaces;
using Bookstore_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore_WebAPI.Repository
{
    public class TranslatorRepository : ITranslatorRepository
    {
        private readonly DataContext _context;
        public TranslatorRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateTranslator(Translator translator)
        {
            _context.Add(translator);
            return Save();
        }

        public Translator GetTranslator(int id)
        {
            return _context.Translators.Where(t => t.Id == id).FirstOrDefault();
        }

        public Translator GetTranslator(string last_name)
        {
            return _context.Translators.Where(t => t.LastName == last_name).FirstOrDefault();
        }

        public ICollection<Translator> GetTranslators()
        {
            return _context.Translators.ToList();
        }

        public bool HasTranslator(int id)
        {
            return _context.Translators.Any(t => t.Id == id);
        }

        public bool HasTranslator(string last_name)
        {
            return _context.Translators.Any(t => t.LastName == last_name);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
