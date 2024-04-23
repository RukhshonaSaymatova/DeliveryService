using System.Text.Json.Serialization;


namespace Contracts.Requests
{
    public record class UpdateOrderRequest
    {
        [JsonIgnore] public int Id { get; set; }
        public string? Status { get; set; }
        public string? TotalAmount { get; set; }
        public string? DeliveryAddress { get; set; }

        public int CustomerId { get; set; }
        public int DeliveryServiceId { get; set; }
        public int DeliveryPersonId { get; set; }
        public int VehicleId { get; set; }
    }
}
