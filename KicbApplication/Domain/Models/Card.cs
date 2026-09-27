using Domain.Models.Accounts;

namespace Domain.Models.Cards;

public class Card
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string CardNumber { get; set; } = null!;
    public DateOnly ExpirationDate { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddYears(3));
    public CardType Type {get; set;}
    public Guid AccountId {get; set;}
    public Account Account {get; set;} = null!;
    public bool IsActive {get; set;} = true; // возможность блокировки карты
}

public enum CardType
{
    Debit,
    Credit
}