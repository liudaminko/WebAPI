using Bookstore_WebAPI.Models;

namespace Bookstore_WebAPI.Interfaces
{
    public interface ITranslatorRepository
    {
        ICollection<Translator> GetTranslators();
        Translator GetTranslator(int id);
        Translator GetTranslator(string last_name);
        bool HasTranslator(int id);
        bool HasTranslator(string last_name);
        bool CreateTranslator(Translator translator);
        bool Save();
    }
}
