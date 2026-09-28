using Application.Contracts.Accounts;
using Application.Contracts.Cards;
using Application.Contracts.Clients;
using Application.Contracts.Phones;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;
    private readonly IPhoneService _phoneService;
    private readonly IAccountService _accountService;

    public ClientController(
        IClientService clientService,
        IPhoneService phoneService,
        IAccountService accountService
        )
    {
        _clientService = clientService;
        _phoneService = phoneService;
        _accountService = accountService;
    }

    [HttpPost("create-client")]
    public async Task<ActionResult<CreateClientResponse>> CreateClient(
        [FromBody] CreateClientRequest request)
    {
        var client = await _clientService.CreateClientAsync(request);

        return Created(string.Empty, client);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetClientResponse>> GetClient(Guid id)
    {
        try
        {
            var client = await _clientService.GetClientByIdAsync(id);
            return Ok(client);
        }
        catch(Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("{id:guid}/phones")]
    public async Task<ActionResult<List<GetPhoneResponse>>> GetPhonesByClientId(Guid id)
    {
        try
        {
            var phones = await _phoneService.GetPhonesByClientIdAsync(id);
            return Ok(phones);
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id:guid}/accounts")]
    public async Task<ActionResult<List<GetAccountResponse>>> GetAccountsByClientId(Guid id)
    {
        try
        {
            var accounts = await _accountService.GetAccountsByClientIdAsync(id);
            return Ok(accounts);
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<GetClientResponse>>> GetAllClients()
    {
        var clients = await _clientService.GetAllClientsAsync();
        return Ok(clients);
    }
    
    [HttpPut("update-client")]
    public async Task<IActionResult> UpdateClient(
        [FromBody]UpdateClientRequest request
    )
    {
        try
        {
            await _clientService.UpdateClientAsync(request);
            return NoContent();
        }
        catch(Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteClient(Guid id)
    {
        try
        {
            await _clientService.DeleteClientAsync(id);
            return NoContent();
        }
        catch(Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}