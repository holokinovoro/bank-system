using Domain.Models.Cards;
using Domain.Models.Users;
namespace Domain.Models.Accounts;

public class Account
{
    public Guid Id {get; init;} = Guid.NewGuid();
    public string AccountNumber {get; set;} = null!;
    public string Currency {get; set;} = null!;
    public decimal Balance {get; set;} = 0;
    public bool IsActive {get; set;} // возможность блокировки счета
    public Guid ClientId {get; set;} // связь с клиентом
    public Client Client {get; set;} = null!;
    public List<Card?> Cards {get; set;} = new List<Card?>(); // у счета может быть несколько карт
}