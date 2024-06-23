using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.DataAccess.Models
{
    public class CityModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public List<AddressModel>? Addresses { get; set; }
    }
}
