namespace Contracts.Requests;

public class CreatePaymentRequest
{
    public int OrderId { get; set; }


    public string? Amount { get; set; }
    public string? Status { get; set; }
}