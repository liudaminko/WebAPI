using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore_WebAPI.Models
{
    public class Delivery
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int DeliveryTypeId { get; set; }
        public string? Address { get; set; }
        public string TrackingNumber { get; set; } = null!;
        public DeliveryType DeliveryType { get; set; }
    }
}
