namespace Application.Contracts.Transactions;

public record TransactionRequest
{
    public required string SenderAccountNumber {get; set;}
    public required string RecieverAccountNumber {get; set;}
    public decimal Amount {get; set;}
}