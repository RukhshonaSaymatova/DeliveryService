using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Contracts.Requests
{
    public record class UpdateVehicleRequest
    {
        [JsonIgnore] public int Id { get; set; }
        public string? Type { get; set; }
        public string? NumberPlate { get; set; }

    }
}
