using Domain.Models.Phones;

namespace Application.Contracts.Phones;

public record UpdatePhoneRequest
{
    public Guid PhoneId {get; set;}
    public string? PhoneNumber {get; set;}
    public PhoneType Type {get; set;}
}