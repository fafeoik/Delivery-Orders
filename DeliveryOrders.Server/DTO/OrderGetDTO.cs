namespace DeliveryOrders.Server.DTO
{
    public class OrderGetDTO
    {
        public Guid Id { get; set; }
        public string? SenderCity { get; set; }
        public string? SenderAddressLine { get; set; }
        public string? RecipientCity { get; set; }
        public string? RecipientAddressLine { get; set; }
        public double? CargoWeight { get; set; }
        public DateOnly CargoPickupDate { get; set; }
        public DateTimeOffset? OrderCreationDate { get; set; }
    }
}
