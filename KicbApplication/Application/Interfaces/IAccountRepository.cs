using Domain.Models.Accounts;

namespace Application.Interfaces;

public interface IAccountRepository
{
    Task<Account> CreateAccountAsync(Guid clientId, string accountNumber, decimal balance, string currency);
    Task DeleteAccountAsync(Guid accountId);
    Task<Account?> GetAccountByIdAsync(Guid accountId);
    Task<List<Account>> GetAccountsByClientIdAsync(Guid clientId);
    Task<List<Account>> GetAllAccountsAsync();
    Task UpdateAccountAsync(Account account);
}
