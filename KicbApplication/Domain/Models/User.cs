using Domain.Models.Accounts;
using Domain.Models.Phones;

namespace Domain.Models.Users;

// создал базовый класс от которого будут наследоваться клиент и админ
// 
public abstract class User
{
    public Guid Id { get; init; } = Guid.NewGuid();
    // Id будет генерироваться автоматически с помощью NewGuid() при создании.
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}

// модель клиента в котором будут все нужные свойства для пользователя 
public class Client : User
{
    public string FirstName {get; set;} = null!;
    public string LastName {get; set;} = null!;
    public string MiddleName {get; set;} = null!;
    public string Email { get; set; } = null!;
    public DateOnly BirthDate { get; set; }
    public List<Phone?> Phones {get; set;} = new List<Phone?>(); // у клиента может быть несколько телефонов
    public List<Account?> Accounts {get; set;} = new List<Account?>(); // у клиента может быть несколько счетов
    public Client(
        string firstName, 
        string lastName, 
        string middleName, 
        string username, 
        string password) 
        : base()
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Username = username;
        Password = password;
    }
}

// модель админа со свойством роли 
public class Admin : User
{
    public AdminRole Role { get; private set; }

    public Admin(string username, string password, AdminRole role) : base()
    {
        Username = username;
        Password = password;
        Role = role;
    }
}

public enum AdminRole
{
    SuperAdmin,
    Admin,
    Moderator
}