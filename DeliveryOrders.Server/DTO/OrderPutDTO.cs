using System.ComponentModel.DataAnnotations;

namespace DeliveryOrders.Server.DTO
{
    public class OrderPutDTO
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [Range(0.1, double.MaxValue)]
        public double? CargoWeight { get; set; }

        [Required]
        public DateTime CargoPickupDate { get; set; }
    }
}
