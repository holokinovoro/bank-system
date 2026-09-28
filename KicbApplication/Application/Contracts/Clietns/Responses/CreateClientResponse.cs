namespace Application.Contracts.Cards;

public record CreateClientResponse
{
    public Guid ClientId {get; set;}
    public required string Email {get; set;}
}