namespace Models.Accounts;

public class Accoiunt
{
    public Guid Id {get; init;} = Guid.NewGuid();
    public string AccountNumber {get; private set;} = null!;
    public string Currency {get; private set;} = null!;
    public decimal Balance {get; private set;} = 0;
}