namespace Models.Users;

// создал базовый класс от которого будут наследоваться клиент и админ
// 
public abstract class User
{
    public Guid Id { get; init; } = Guid.NewGuid();
    // Id будет генерироваться автоматически с помощью NewGuid() при создании.
    public string Username { get; protected set; } = null!;
    public string Password { get; protected set; } = null!;
}

// модель клиента в котором будут все нужные свойства для пользователя 
public class Client : User
{
    public string FirstName {get; set;} = null!;
    public string LastName {get; set;} = null!;
    public string MiddleName {get; set;} = null!;
    public string Email { get; set; } = null!;
    public DateOnly BirthDate { get; set; }

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