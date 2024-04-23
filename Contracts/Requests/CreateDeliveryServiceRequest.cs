﻿namespace Contracts.Requests;

public class CreateDeliveryServiceRequest
{
    public required string Name { get; set; }
    public string? Address { get; set; }
    public required string Email { get; set; }
}
