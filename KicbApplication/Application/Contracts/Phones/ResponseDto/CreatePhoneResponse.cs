namespace Application.Contracts.Phones;

public record CreatePhoneResponse
{
    public Guid PhoneId {get; set;}
    public required string PhoneNumber {get; set;}
    public Guid ClientId {get; set;}
}