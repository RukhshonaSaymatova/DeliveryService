using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Responses
{
    public record class SingleVehicleResponse
    {
        public int Id { get; init; }
        public string? Type { get; set; }
        public string? NumberPlate { get; set; }
    }
}
