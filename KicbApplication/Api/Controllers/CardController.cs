using Application.Contracts.Cards.RequestDto;
using Application.Contracts.Cards.ResponseDto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CardController : ControllerBase
{
    private readonly ICardService _cardService;

    public CardController(ICardService cardService)
    {
        _cardService = cardService;
    }

    [HttpPost("create-card")]
    public async Task<ActionResult<CreateCardResponse>> CreateCard([FromBody] CreateCardRequest request)
    {
        try
        {
            var card = await _cardService.CreateCardAsync(request);
            return Ok(card); 
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetCardResponse>> GetCard(Guid id)
    {
        try
        {
            var card = await _cardService.GetCardByIdAsync(id);
            return Ok(card);
        }
        catch(Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<GetCardResponse>>> GetAllCards()
    {
        try
        {
            var cards = await _cardService.GetAllCardsAsync();
            return Ok(cards);
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("update-card")]
    public async Task<IActionResult> UpdateCard(UpdateCardRequest request)
    {
        try
        {
            await _cardService.UpdateCardAsync(request);
            return NoContent();
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPatch("block/{id:guid}")] 
    public async Task<IActionResult> BlockCard(Guid id)
    {
        try
        {
            await _cardService.BlockCardAsync(id);
            return NoContent();
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPatch("unblock/{id:guid}")]
    public async Task<IActionResult> UnblockCard(Guid id)
    {
        try
        {
            await _cardService.UnBlockCardAsync(id);
            return NoContent();
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCard(Guid id)
    {
        try
        {
            await _cardService.DeleteCardAsync(id);
            return NoContent();
        }
        catch(Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

}