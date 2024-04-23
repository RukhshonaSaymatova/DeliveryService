using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests
{
    public record class GetAllDeliveryPersonsRequest
    {
        public IEnumerable<DeliveryPerson> Items { get; set; }
    }
}
