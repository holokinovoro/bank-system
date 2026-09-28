namespace Application.Contracts.Accounts;

public record UpdateAccountRequest
{
    public Guid AccountId {get; set;}
    public string? AccountNumber {get; set;}
    public string? Currency {get; set;}
    public decimal Balance {get; set;}
    
}