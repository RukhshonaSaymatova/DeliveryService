﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Responses
{
    public record class SingleCustomerResponse
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public string? Address { get; init; }
        public string? Email { get; init; }
    }
}
