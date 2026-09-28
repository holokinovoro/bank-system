using Application.Contracts.Transactions;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpPatch]
    public async Task<IActionResult> ExcecuteTransaction([FromBody]TransactionRequest request)
    {
        try
        {
            await _transactionService.ExecuteTransactionAsync(request);
            return NoContent();
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // тут я не успел обработать всю логику перевода счетов между собо
    // так же необходимо будет сделать таблицу переводов в котором можно будет мониторить все переводы
}