using Application.Contracts.Phones;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PhoneController : ControllerBase
{
    private readonly IPhoneService _phoneService;

    public PhoneController(IPhoneService phoneService)
    {
        _phoneService = phoneService;
    }

    [HttpPost("create-phone")]
    public async Task<ActionResult<CreatePhoneResponse>> CreatePhone([FromBody]CreatePhoneRequest request)
    {
        try
        {
            var phone = await _phoneService.CreatePhoneAsync(request);
            return Ok(phone);
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetPhoneResponse>> GetPhone(Guid id)
    {
        try
        {
            var phone = await _phoneService.GetPhoneByIdAsync(id);
            return Ok(phone);
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<GetPhoneResponse>>> GetAllPhones()
    {
        try
        {
            var phones = await _phoneService.GetAllPhonesAsync();
            return Ok(phones);
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("update-phone")]
    public async Task<IActionResult> UpdatePhone(UpdatePhoneRequest request)
    {
        try
        {
            await _phoneService.UpdatePhoneAsync(request);
            return NoContent();
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeletePhone(Guid id)
    {
        try
        {
            await _phoneService.DeletePhoneAsync(id);
            return NoContent();
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}