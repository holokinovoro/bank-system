using Application.Contracts.Accounts;
using Application.Interfaces;
using Domain.Models.Accounts;

namespace Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<CreateAccountResponse> CreateAccountAsync(CreateAccountRequest request)
    {
        var card = await _accountRepository.CreateAccountAsync(
            request.ClientId,
            request.AccountNumber,
            request.Balance,
            request.Currency
        );

        return new CreateAccountResponse
        {
            AccountId = card.Id,
            AccountNumber = card.AccountNumber,
            Balance = card.Balance,
            ClientId = card.ClientId
        };
    }

    // здесь в ответе сделал парсинг для списка карт
    public async Task<GetAccountResponse> GetAccountByIdAsync(Guid accountId)
    {
        var account = await _accountRepository.GetAccountByIdAsync(accountId);
        if (account == null)
            throw new Exception("Account does not found");

        return new GetAccountResponse
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
        };
    }

    public async Task<List<GetAccountResponse>> GetAllAccountsAsync()
    {
        var accounts = await _accountRepository.GetAllAccountsAsync();

        return accounts.Select(account => new GetAccountResponse
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
        }).ToList();
    }

    public async Task<List<GetAccountResponse>> GetAccountsByClientIdAsync(Guid clientId)
    {
        var accounts = await _accountRepository.GetAccountsByClientIdAsync(clientId);

        return accounts.Select(account => new GetAccountResponse
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
        }).ToList();
    }

    public async Task UpdateAccountAsync(UpdateAccountRequest request)
    {
        var account = await _accountRepository.GetAccountByIdAsync(request.AccountId);
        if (account == null)
            throw new Exception("Account not found");

        if (request.AccountNumber != null)
            account.AccountNumber = request.AccountNumber;
        if (request.Balance != account.Balance)
            account.Balance = request.Balance;
        if (request.Currency != null)
            account.Currency = request.Currency;

        await _accountRepository.UpdateAccountAsync(account);
    }

    // логика закрытие счета с проверкой на нулевой счет и наличии неактивных карт
    public async Task CloseAccountAsync(Guid accountId)
    {
        var account = await _accountRepository.GetAccountByIdAsync(accountId);

        if (account == null)
            throw new Exception("Account not found");

        bool hasInActiveCards = account.Cards.All(card => !card.IsActive);

        if (account.Balance == 0 & hasInActiveCards)
        {
            await _accountRepository.CloseAccountAsync(account.Id);
        }
    }

    public async Task DeleteAccountAsync(Guid accountId)
    {
        var account = await _accountRepository.GetAccountByIdAsync(accountId);

        if (account == null)
            throw new Exception("Account not found");

        await _accountRepository.DeleteAccountAsync(accountId);
    }
}