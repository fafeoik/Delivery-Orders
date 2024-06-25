using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryOrders.DataAccess.Models
{
    public class OrderModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid RecipientAddressId { get; set; }
        public AddressModel? RecipientAddress { get; set; }
        [Required]
        public Guid SenderAddressId { get; set; }
        public AddressModel? SenderAddress { get; set; }
        [Required]
        public double? CargoWeight { get; set; }
        [Required]
        public DateOnly? CargoPickupDate { get; set; }
        [Required]
        public DateTimeOffset? OrderCreationDate { get; set; }
    }
}
