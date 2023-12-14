using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_WebAPI.Models
{
    public class WishlistItem
    {
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
