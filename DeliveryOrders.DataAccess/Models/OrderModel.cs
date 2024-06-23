using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.DataAccess.Models
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public Guid RecipientAddressId { get; set; }
        public AddressModel? RecipientAddress { get; set; }
        public Guid SenderAddressId { get; set; }
        public AddressModel? SenderAddress { get; set; }
        public double? CargoWeight { get; set; }
        public DateTime? CargoPickupDate { get; set; }
    }
}
