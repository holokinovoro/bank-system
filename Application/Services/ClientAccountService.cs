using DataBase;
using Microsoft.EntityFrameworkCore;
using Models.Accounts;

namespace Services;

public class ClientAccountService
{
    private readonly AppDbContext _context;

    public ClientAccountService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Account> CreateAccountAsync(
        Guid clientId, 
        string accountNumber, 
        decimal balance,
        string currency)
    {
        var client = await _context.Clients.FindAsync(clientId);
        if (client == null)
        {
            throw new Exception("Client not found");
        }

        var account = new Account()
        {
            AccountNumber = accountNumber,
            Balance = balance,
            Currency = currency,
            ClientId = clientId,
            Client = client
        };
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();
        return account;
    }

    public async Task<Account?> GetAccountByIdAsync(Guid accountId)
    {
        return await _context.Accounts.FindAsync(accountId);
    }

    public async Task<List<Account>> GetAllAccountsAsync()
    {
        return await _context.Accounts.ToListAsync();
    }

    public async Task<List<Account>> GetAccountsByClientIdAsync(Guid clientId)
    {
        return await _context.Accounts
            .Where(a => a.ClientId == clientId)
            .ToListAsync();
    }

    public async Task UpdateAccountAsync(Account account)
    {
        _context.Accounts.Update(account);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAccountAsync(Guid accountId)
    {
        var account = await _context.Accounts.FindAsync(accountId);
        if (account != null)
        {
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
        }
    }
}