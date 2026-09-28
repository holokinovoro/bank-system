using Domain.Models.Cards;

public record UpdateCardRequest
{
    public Guid Id { get; set; }
    public string? CardNumber { get; set; }
    public DateOnly? ExpirationDate { get; set; }
    public CardType Type { get; set; }
    public bool IsActive { get; set; }
}