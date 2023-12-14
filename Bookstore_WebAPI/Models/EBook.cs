using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_WebAPI.Models
{
    public class EBook
    {
        [Key]
        public int ItemId { get; set; }
        public string MediaType { get; set; } = null!;
        [Required]
        public int FileSize { get; set; }
        public string DownloadLink { get; set; } = null!;
        public Item Item { get; set; }
    }
}
