using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_WebAPI.Models
{
    public class PhysicalBook
    {
        [Key]
        public int ItemId { get; set; }
        public CoverType CoverType { get; set; }
        public Condition Condition { get; set; }
        public Item Item { get; set; }
    }
}
