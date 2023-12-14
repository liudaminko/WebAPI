using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_WebAPI.Models
{
    public class Review
    {
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [Column(TypeName = "decimal(4, 2)")]
        [Range(1, 5)]
        public int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
