using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_WebAPI.Models
{
    public class Accessories
    {
        [Key]
        public int ItemId { get; set; }
        public string? Material { get; set; }
        public string? Coating { get; set; }
        public int? Weight { get; set; }
        public Item Item { get; set; }
    }
}
