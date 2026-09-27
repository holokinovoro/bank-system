using Domain.Models.Phones;

namespace Application.Contracts.Phones;

public record CreatePhoneRequest
{
    public Guid ClientId {get; set;}
    public required string PhoneNumber {get; set;}
    public required PhoneType Type {get; set;}
}