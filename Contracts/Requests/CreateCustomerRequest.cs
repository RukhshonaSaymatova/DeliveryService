namespace Contracts.Requests;

public class CreateCustomerRequest
{
    public required string Name { get; set; }
    public string? Address { get; set; }
    public required string Email { get; set; }
}