using Application.Contracts.Phones;

namespace Application.Interfaces;

public interface IPhoneService
{
    Task<CreatePhoneResponse> CreatePhoneAsync(CreatePhoneRequest request);
    Task DeletePhoneAsync(Guid phoneId);
    Task<List<GetPhoneResponse>> GetAllPhonesAsync();
    Task<GetPhoneResponse> GetPhoneByIdAsync(Guid Id);
    Task<List<GetPhoneResponse>> GetPhonesByClientIdAsync(Guid clientId);
    Task UpdatePhoneAsync(UpdatePhoneRequest request);
}
