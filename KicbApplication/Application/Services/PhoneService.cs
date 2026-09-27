using Application.Contracts.Phones;
using Application.Interfaces;

namespace Application.Services;

public class PhoneService
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

    public async Task<CreatePhoneResponse> CreatePhone(CreatePhoneRequest request)
    {
        var client = await _clientRepository.GetClientByIdAsync(request.ClientId);
        if(client == null)
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

        if(phone == null)
            throw new Exception("Phone does not found");
        return new GetPhoneResponse
        {
            PhoneNumber = phone.Number,
            Type = phone.Type,
            ClientId = phone.clientId
        };
    }
}