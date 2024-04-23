using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests
{
    public record class GetAllOrdersRequest
    {
        public IEnumerable<Order> Items { get; set; }
    }
}
