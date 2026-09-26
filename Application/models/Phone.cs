namespace Models.Phones;

public class Phone
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Number { get; private set; } = null!;
    public PhoneType Type {get; set;}
}

public enum PhoneType
{
    Mobile,
    Home,
    Work
}