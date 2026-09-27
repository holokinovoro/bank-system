using Models.Users;

namespace Models.Phones;

public class Phone
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Number { get; set; } = null!;
    public PhoneType Type {get; set;}
    public Guid clientId {get; set;}
    public Client Client {get; set;} = null!;
}

public enum PhoneType
{
    Mobile,
    Home,
    Work
}