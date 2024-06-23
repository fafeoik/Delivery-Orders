using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.DataAccess.Models
{
    public class AddressModel
    {
        public Guid Id { get; set; }
        public string? AddressLine { get; set; }
        public Guid CityId { get; set; }
        public CityModel? City { get; set; }
        public virtual List<OrderModel>? Orders { get; set; }
    }
}
