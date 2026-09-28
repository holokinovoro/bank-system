using Application.Contracts.Accounts;
using Application.Contracts.Phones;

namespace Application.Contracts.Clients;

public record GetClientResponse
{
    public Guid ClientId {get; set;}
    public required string Email {get; set;}
    public List<GetPhoneResponse>? Phones {get; set;}
    public List<GetAccountResponse>? Accounts {get; set;}
}