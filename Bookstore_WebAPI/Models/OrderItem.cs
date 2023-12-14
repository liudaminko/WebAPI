using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_WebAPI.Models
{
    public class OrderItem
    {
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int Amount { get; set; }
        public Item Item { get; set; }
        public Order Order { get; set; }
    }
}
