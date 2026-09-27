using Domain.Models.Phones;

namespace Application.Contracts.Phones;

public record GetPhoneResponse
{
    public string? PhoneNumber {get; set;}
    public PhoneType Type {get; set;}
    public Guid ClientId {get; set;}
}