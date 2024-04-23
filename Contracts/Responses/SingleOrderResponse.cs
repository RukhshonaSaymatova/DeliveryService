using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Responses
{
    public record class SingleOrderResponse
    {
        public int Id { get; init; }
        public string? Status { get; set; }
        public string? TotalAmount { get; set; }
        public string? DeliveryAddress { get; set; }


        public int CustomerId { get; set; }
        public int DeliveryServiceId { get; set; }
        public int DeliveryPersonId { get; set; }
        public int VehicleId { get; set; }
    }
}
