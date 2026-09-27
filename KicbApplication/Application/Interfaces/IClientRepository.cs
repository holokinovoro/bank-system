using Domain.Models.Users;

namespace Application.Interfaces;

public interface IClientRepository
{
    Task<Client> CreateClientAsync(string firstName, string lastName, string middleName, string username, string password);
    Task DeleteClientAsync(Guid clientId);
    Task<List<Client>> GetAllClientsAsync();
    Task<Client?> GetClientByIdAsync(Guid clientId);
    Task UpdateClientAsync(Client client);
}
