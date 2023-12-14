using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_WebAPI.Models
{
    public class Book
    {
        [Key]
        public int ItemId { get; set; }
        [Required]
        public int GenreId { get; set; }
        [Required]
        [Column(TypeName = "decimal(4, 2)")]
        [Range(1,5)]

        public decimal Rating { get; set; }
        [Required]
        public int PublicationYear { get; set; }
        [Required]
        public int PublisherId { get; set; }
        public int? TranslatorId { get; set; }

        public string Language { get; set; } = null!;
        [Required]
        public int Pages { get; set; }
        public Publisher Publisher { get; set; }
        public Translator Translator { get; set; }
        public Genre Genre { get; set; }

    }
}
