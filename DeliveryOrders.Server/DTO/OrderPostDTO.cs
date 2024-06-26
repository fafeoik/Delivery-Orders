using System.ComponentModel.DataAnnotations;

namespace DeliveryOrders.Server.DTO
{
    public class OrderPostDTO
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(40)]
        public string? SenderCity { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(50)]
        public string? SenderAddressLine { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(40)]
        public string? RecipientCity { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [MaxLength(50)]
        public string? RecipientAddressLine { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Range(0.1, double.MaxValue)]
        public double? CargoWeight { get; set; }

        [Required]
        public DateOnly? CargoPickupDate { get; set; }
    }
}
