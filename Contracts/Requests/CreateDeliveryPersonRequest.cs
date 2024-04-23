using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests;

public class CreateDeliveryPersonRequest
{
    public required string Name { get; set; }
    public string? ContactInfo { get; set; }
    public required string Email { get; set; }
}
