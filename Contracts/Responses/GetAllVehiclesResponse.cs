﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Responses
{
    public record class GetAllVehiclesResponse
    {
        public IEnumerable<SingleVehicleResponse> Items { get; init; } = Enumerable.Empty<SingleVehicleResponse>();

    }
}
