using Application.Contracts.Phones;
using Application.Interfaces;

namespace Application.Services;

public class PhoneService : IPhoneService
{
    private readonly IPhoneRepository _phoneRepository;
    private readonly IClientRepository _clientRepository;

    public PhoneService(
        IPhoneRepository phoneRepository,
        IClientRepository clientRepository
        )
    {
        _phoneRepository = phoneRepository;
        _clientRepository = clientRepository;
    }

    public async Task<CreatePhoneResponse> CreatePhoneAsync(CreatePhoneRequest request)
    {
        var client = await _clientRepository.GetClientByIdAsync(request.ClientId);
        if (client == null)
        {
            throw new Exception("Client does not exist");
        }
        var phone = await _phoneRepository.CreatePhoneAsync(
            client.Id,
            request.PhoneNumber,
            request.Type
        );

        return new CreatePhoneResponse
        {
            PhoneId = phone.Id,
            PhoneNumber = phone.Number,
            ClientId = client.Id
        };
    }

    public async Task<GetPhoneResponse> GetPhoneByIdAsync(Guid Id)
    {
        var phone = await _phoneRepository.GetPhoneByIdAsync(Id);

        if (phone == null)
            throw new Exception("Phone does not found");
        return new GetPhoneResponse
        {
            PhoneNumber = phone.Number,
            Type = phone.Type,
            ClientId = phone.clientId
        };
    }

    public async Task<List<GetPhoneResponse>> GetAllPhonesAsync()
    {
        var phones = await _phoneRepository.GetAllPhonesAsync();

        return phones.Select(phone => new GetPhoneResponse
        {
            PhoneNumber = phone.Number,
            Type = phone.Type,
            ClientId = phone.clientId
        }).ToList();
    }

    public async Task<List<GetPhoneResponse>> GetPhonesByClientIdAsync(Guid clientId)
    {
        var phones = await _phoneRepository.GetPhonesByClientIdAsync(clientId);

        return phones.Select(phone => new GetPhoneResponse
        {
            PhoneNumber = phone.Number,
            Type = phone.Type,
            ClientId = phone.clientId
        }).ToList();
    }

    public async Task UpdatePhoneAsync(UpdatePhoneRequest request)
    {
        var phone = await _phoneRepository.GetPhoneByIdAsync(request.PhoneId);
        if (phone == null)
            throw new Exception("Phone does not found");

        if (request.PhoneNumber != null)
            phone.Number = request.PhoneNumber;

        if (request.Type != phone.Type)
            phone.Type = request.Type;

        await _phoneRepository.UpdatePhoneAsync(phone);
    }

    public async Task DeletePhoneAsync(Guid phoneId)
    {
        await _phoneRepository.DeletePhoneAsync(phoneId);
    }
}