using Application.Contracts.Accounts;
using Application.Contracts.Cards;
using Application.Contracts.Clients;
using Application.Contracts.Phones;
using Application.Interfaces;

namespace Application.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IPhoneRepository _phoneRepository;
    private readonly IAccountRepository _accountRepository;

    public ClientService(
        IClientRepository clientRepository,
        IPhoneRepository phoneRepository,
        IAccountRepository accountRepository
        )
    {
        _clientRepository = clientRepository;
        _phoneRepository = phoneRepository;
        _accountRepository = accountRepository;
    }

    public async Task<CreateClientResponse> CreateClientAsync(CreateClientRequest request)
    {
        var client = await _clientRepository.CreateClientAsync(
            request.FirstName,
            request.LastName,
            request.MiddleName,
            "",
            ""
        );

        return new CreateClientResponse
        {
            ClientId = client.Id,
            Email = client.Email
        };
    }

    // не уверен такой метод парсинга правильный или нет
    public async Task<GetClientResponse> GetClientByIdAsync(Guid clientId)
    {
        var client = await _clientRepository.GetClientByIdAsync(clientId);
        var phones = await _phoneRepository.GetPhonesByClientIdAsync(clientId);
        var accounts = await _accountRepository.GetAccountsByClientIdAsync(clientId);

        if (client == null)
            throw new Exception("Client not found");

        return new GetClientResponse
        {
            ClientId = client.Id,
            Email = client.Email,
            Phones = phones.Select(phone => new GetPhoneResponse
            {
                PhoneNumber = phone.Number,
                Type = phone.Type,
                ClientId = phone.clientId
            }).ToList(),
            Accounts = accounts.Select(account => new GetAccountResponse
            {
                AccountId = account.Id,
                AccountNumber = account.AccountNumber,
                Currency = account.Currency,
                Balance = account.Balance,
                ClientId = account.ClientId,
                Cards = account.Cards.Select(card => new GetCardResponse
                {
                    Id = card.Id,
                    CardNumber = card.CardNumber,
                    ExpirationDate = card.ExpirationDate,
                    Type = card.Type.ToString(),
                    AccountNumber = card.Account.AccountNumber,
                    IsActive = card.IsActive
                }).ToList()
            }).ToList()
        };
    }

    // не стал добавлять телефоны и счета иначе список может стать огромным 
    public async Task<List<GetClientResponse>> GetAllClientsAsync()
    {
        var clients = await _clientRepository.GetAllClientsAsync();

        return clients.Select(client => new GetClientResponse
        {
            ClientId = client.Id,
            Email = client.Email
        }).ToList();
    }

    public async Task UpdateClientAsync(UpdateClientRequest request)
    {
        var client = await _clientRepository.GetClientByIdAsync(request.ClientId);
        if (client == null)
            throw new Exception("Client not found");
        if (request.FirstName != null)
            client.FirstName = request.FirstName;
        if (request.LastName != null)
            client.LastName = request.LastName;
        if (request.MiddleName != null)
            client.MiddleName = request.MiddleName;
        if (request.BirthDate.HasValue)
            client.BirthDate = request.BirthDate.Value;

        await _clientRepository.UpdateClientAsync(client);
    }

    public async Task DeleteClientAsync(Guid clientId)
    {
        await _clientRepository.DeleteClientAsync(clientId);
    }
}

