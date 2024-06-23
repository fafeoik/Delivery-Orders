using System.ComponentModel.DataAnnotations;

namespace DeliveryOrders.Server.DTO
{
    public class OrderPostDTO
    {
        [Required(ErrorMessage = "Обязательное поле")]
        public string? SenderCity { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        public string? SenderAddressLine { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        public string? RecipientCity { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        public string? RecipientAddressLine { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Range(0.1, double.MaxValue)]
        public double? CargoWeight { get; set; }

        [Required]
        public DateTime CargoPickupDate { get; set; }
    }
}
