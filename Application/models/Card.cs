using Models.Accounts;

namespace Models.Cards;

public class Card
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string CardNumber { get; set; } = null!;
    public DateOnly ExpirationDate { get; private set; } = DateOnly.FromDateTime(DateTime.Now.AddYears(3));
    public CardType Type {get; set;}
    public Guid AccountId {get; set;}
    public Account Account {get; set;} = null!;
}

public enum CardType
{
    Debit,
    Credit
}