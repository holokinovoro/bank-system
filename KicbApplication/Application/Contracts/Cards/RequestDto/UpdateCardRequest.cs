using Domain.Models.Cards;

public record UpdateCardRequest
{
    public Guid Id { get; set; }
    public string? CardNumber { get; init; }
    public DateOnly? ExpirationDate { get; init; }
    public CardType Type { get; init; }
    public bool IsActive { get; init; }
}