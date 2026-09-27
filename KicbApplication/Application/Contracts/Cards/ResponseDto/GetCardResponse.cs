using Domain.Models.Cards;

public record GetCardResponse
{
    public Guid Id { get; set; }
    public required string CardNumber { get; set; }
    public DateOnly ExpirationDate { get; set; }
    public required string Type { get; set; }
    public required string AccountNumber { get; set; }
    public bool IsActive { get; set; }
    
}