using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.DataAccess.Models
{
    public class AddressModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string? AddressLine { get; set; }
        [Required]
        public Guid CityId { get; set; }
        public CityModel? City { get; set; }
        public virtual List<OrderModel>? SenderOrders { get; set; }
        public virtual List<OrderModel>? RecipentOrders { get; set; }
    }
}
