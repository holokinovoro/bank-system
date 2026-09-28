using Application.Contracts.Cards;
using Application.Contracts.Clients;

namespace Application.Interfaces;

public interface IClientService
{
    Task<CreateClientResponse> CreateClientAsync(CreateClientRequest request);
    Task DeleteClientAsync(Guid clientId);
    Task<List<GetClientResponse>> GetAllClientsAsync();
    Task<GetClientResponse> GetClientByIdAsync(Guid clientId);
    Task UpdateClientAsync(UpdateClientRequest request);
}

