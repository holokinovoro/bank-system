namespace Application.Contracts.Accounts;

public record GetAccountResponse
{
    public Guid AccountId {get; set;}
    public string? AccountNumber {get; set;}
    public string? Currency {get; set;}
    public decimal Balance {get; set;}
    public Guid ClientId {get; set;}
    public List<GetCardResponse>? Cards {get; set;}
}