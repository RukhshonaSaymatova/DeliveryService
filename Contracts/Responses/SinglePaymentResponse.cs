using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Responses
{
    public record class SinglePaymentResponse
    {
        public int Id { get; init; }
        public int OrderId { get; set; }


        public string? Amount { get; set; }
        public string? Status { get; set; }
    }
}
