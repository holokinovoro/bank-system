using Application.Contracts.Transactions;
using Application.Interfaces;

namespace Application.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task ExecuteTransactionAsync(TransactionRequest request)
    {
        await _transactionRepository.ExecuteTransactionAsync(
            request.SenderAccountNumber,
            request.RecieverAccountNumber,
            request.Amount
        );
    }
}