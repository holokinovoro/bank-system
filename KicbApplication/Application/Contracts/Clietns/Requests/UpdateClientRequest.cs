namespace Application.Contracts.Clients;

public record UpdateClientRequest
{
    public Guid ClientId {get; set;}
    public string? FirstName {get; set;}
    public string? LastName {get; set;}
    public string? MiddleName {get; set;}
    public string? Email {get; set;}
    public DateOnly? BirthDate {get; set;}
}