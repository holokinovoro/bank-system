using Application.Contracts.Accounts;

namespace Application.Interfaces;

public interface IAccountService
{
    Task CloseAccountAsync(Guid accountId);
    Task<CreateAccountResponse> CreateAccountAsync(CreateAccountRequest request);
    Task<GetAccountResponse> GetAccountByIdAsync(Guid accountId);
    Task<List<GetAccountResponse>> GetAccountsByClientIdAsync(Guid clientId);
    Task<List<GetAccountResponse>> GetAllAccountsAsync();
    Task UpdateAccountAsync(UpdateAccountRequest request);
    Task DeleteAccountAsync(Guid accountId);
}
