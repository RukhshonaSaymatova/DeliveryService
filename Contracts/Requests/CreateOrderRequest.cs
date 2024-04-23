using Domain.Entities;

namespace Contracts.Requests;

public class CreateOrderRequest
{
    public string Status { get; set; }
    public string TotalAmount { get; set; }
    public string DeliveryAddress { get; set; }


    public int CustomerId { get; set; }
    public int DeliveryServiceId { get; set; }
    public int DeliveryPersonId { get; set; }
    public int VehicleId { get; set; }
}
