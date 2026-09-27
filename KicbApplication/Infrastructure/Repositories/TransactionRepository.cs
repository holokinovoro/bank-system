using Application.Interfaces;
using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly AppDbContext _context;

    public TransactionRepository(AppDbContext context)
    {
        _context = context;
    }

    // метод для выполнения транзакции между двумя счетами
    public async Task ExecuteTransactionAsync(string senderAccountNumber, string receiverAccountNumber, decimal amount)
    {
        var senderAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == senderAccountNumber);
        var receiverAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == receiverAccountNumber);

        if (senderAccount == null || receiverAccount == null)
        {
            throw new Exception("One or both accounts not found");
        }

        if (senderAccount.Balance < amount)
        {
            throw new Exception("Insufficient funds in sender's account");
        }

        // обернул в юзинг чтобы методы вошли в одну транзакцию, если что-то пойдет не так, то откатит все изменения
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                senderAccount.Balance -= amount;
                receiverAccount.Balance += amount;

                _context.Accounts.Update(senderAccount);
                _context.Accounts.Update(receiverAccount);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        ;

    }

}