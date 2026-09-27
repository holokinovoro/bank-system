namespace Application.Interfaces;

public interface ITransactionRepository
{
    Task ExecuteTransactionAsync(string senderAccountNumber, string receiverAccountNumber, decimal amount);
}
