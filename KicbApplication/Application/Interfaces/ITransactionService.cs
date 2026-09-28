using Application.Contracts.Transactions;

namespace Application.Interfaces;

public interface ITransactionService
{
    Task ExecuteTransactionAsync(TransactionRequest request);
}
