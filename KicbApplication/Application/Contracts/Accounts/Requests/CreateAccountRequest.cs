using System.ComponentModel.DataAnnotations;

namespace Application.Contracts.Accounts;

public record CreateAccountRequest
{
    public Guid ClientId { get; set; }
    public required string AccountNumber { get; set; }
    public required string Currency { get; set; }
    [Range(0, double.MaxValue)]
    public decimal Balance { get; set; }    
}