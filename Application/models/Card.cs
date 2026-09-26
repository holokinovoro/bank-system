namespace Models.Cards;

public class Card
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string CardNumber { get; private set; } = null!;
    public DateOnly ExpirationDate { get; private set; } = DateOnly.FromDateTime(DateTime.Now.AddYears(3));
    public CardTypre Type {get; set;}
    public string CVV { get; private set; } = null!;
}

public enum CardTypre
{
    Debit,
    Credit
}