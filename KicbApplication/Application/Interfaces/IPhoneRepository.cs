using Domain.Models.Phones;

namespace Application.Interfaces;

public interface IPhoneRepository
{
    Task<Phone> CreatePhoneAsync(Guid clientId, string phoneNumber, PhoneType phoneType);
    Task DeletePhoneAsync(Guid phoneId);
    Task<List<Phone>> GetAllPhonesAsync();
    Task<Phone> GetPhoneByIdAsync(Guid phoneId);
    Task<List<Phone>> GetPhonesByClientIdAsync(Guid clientId);
    Task UpdatePhoneAsync(Phone phone);
}
