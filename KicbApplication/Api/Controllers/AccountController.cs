using Application.Contracts.Accounts;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly ICardService _cardService;

    public AccountController(
        IAccountService accountService,
        ICardService cardService
        )
    {
        _accountService = accountService;
        _cardService = cardService;
    }

    [HttpPost("create-account")]
    public async Task<ActionResult<CreateAccountResponse>> CreateAccount([FromBody] CreateAccountRequest request)
    {
        try
        {
            var account = await _accountService.CreateAccountAsync(request);
            return Ok(account);
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetAccountResponse>> GetAccountById(Guid id)
    {
        try
        {
            var account = await _accountService.GetAccountByIdAsync(id);
            return Ok(account);
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<GetAccountResponse>>> GetAllAccounts()
    {
        try
        {
            var accounts = await _accountService.GetAllAccountsAsync();
            return Ok(accounts);
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id:guid}/cards")]
    public async Task<ActionResult<GetCardResponse>> GetCardsByAccountId(Guid id)
    {
        try
        {
            var cards = await _cardService.GetCardsByAccountIdAsync(id);
            return Ok(cards);
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPatch("close-account/{id:guid}")]
    public async Task<IActionResult> CloseAccount(Guid id)
    {
        try
        {
            await _accountService.CloseAccountAsync(id);
            return NoContent();
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("update-account")]
    public async Task<IActionResult> UpdateAccount([FromBody]UpdateAccountRequest request)
    {
        try
        {
            await _accountService.UpdateAccountAsync(request);
            return NoContent();
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("delete-account/{id:guid}")]
    public async Task<IActionResult> DeleteAccount(Guid id)
    {
        try
        {
            await _accountService.DeleteAccountAsync(id);
            return NoContent();
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}