using System.Text.Json.Serialization;


namespace Contracts.Requests
{
    public record class UpdateCustomerRequest
    {
        [JsonIgnore] public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email {  get; set; }
    }
}
