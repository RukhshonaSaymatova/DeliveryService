using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Contracts.Requests
{
    public record class UpdatePaymentRequest
    {
        [JsonIgnore] public int Id { get; set; }
        public int OrderId { get; set; }


        public string? Amount { get; set; }
        public string? Status { get; set; }
    }
}
