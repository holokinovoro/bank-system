namespace Application.Contracts.Clients;

public record CreateClientRequest
{
    public required string FirstName {get; set;}
    public required string LastName {get; set;}
    public required string MiddleName {get; set;}
    public required string Email {get; set;}
    public DateOnly BirthDate {get; set;}
}