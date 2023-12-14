using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bookstore_WebAPI.DTO
{
    public class BookDTO
    {
        public int ItemId { get; set; }
        public int GenreId { get; set; }
        public decimal Rating { get; set; }
        public int PublicationYear { get; set; }
        public int PublisherId { get; set; }
        public int? TranslatorId { get; set; }
        public string Language { get; set; } = null!;
        public int Pages { get; set; }
    }
}
