using Application.Contracts.Cards;
using Application.Contracts.Cards.RequestDto;
using Application.Contracts.Cards.ResponseDto;
using Application.Interfaces;
using Domain.Models.Cards;

namespace Application.Services;

public class CardService : ICardService
{
    private readonly ICardRepository _cardRepository;
    public CardService(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }

    // метод для создания карты на основе запроса CreateCardRequest
    public async Task<CreateCardResponse> CreateCardAsync(CreateCardRequest request)
    {
        var card = await _cardRepository.CreateCardAsync(
            request.AccountId,
            request.CardNumber,
            request.ExpirationDate,
            request.Type
        );

        return new CreateCardResponse
        {
            CardNumber = card.CardNumber,
            ExpirationDate = card.ExpirationDate,
            Type = card.Type,
            AccountNumber = card.Account.AccountNumber
        };
    }

    public async Task<GetCardResponse> GetCardByIdAsync(Guid cardId)
    {
        var card = await _cardRepository.GetCardByIdAsync(cardId);

        if (card == null)
        {
            throw new Exception("Card not found");
        }

        return new GetCardResponse
        {
            Id = card.Id,
            CardNumber = card.CardNumber,
            ExpirationDate = card.ExpirationDate,
            Type = card.Type.ToString(),
            AccountNumber = card.Account.AccountNumber,
            IsActive = card.IsActive
        };
    }

    public async Task<List<GetCardResponse>> GetAllCardsAsync()
    {
        var cards = await _cardRepository.GetAllCardsAsync();
        return cards.Select(card => new GetCardResponse
        {
            Id = card.Id,
            CardNumber = card.CardNumber,
            ExpirationDate = card.ExpirationDate,
            Type = card.Type.ToString(),
            AccountNumber = card.Account.AccountNumber,
            IsActive = card.IsActive
        }).ToList();
    }

    public async Task<List<GetCardResponse>> GetCardsByAccountIdAsync(Guid accountId)
    {
        var cards = await _cardRepository.GetCardsByAccountIdAsync(accountId);
        return cards.Select(card => new GetCardResponse
        {
            Id = card.Id,
            CardNumber = card.CardNumber,
            ExpirationDate = card.ExpirationDate,
            Type = card.Type.ToString(),
            AccountNumber = card.Account.AccountNumber,
            IsActive = card.IsActive
        }).ToList();
    }

    public async Task UpdateCardAsync(UpdateCardRequest request)
    {
        var card = await _cardRepository.GetCardByIdAsync(request.Id);

        if (card == null)
        {
            throw new Exception("Card not found");
        }

        if (request.CardNumber != null)
        {
            card.CardNumber = request.CardNumber;
        }
        if (request.ExpirationDate.HasValue)
        {
            card.ExpirationDate = request.ExpirationDate.Value;
        }
        if (request.Type != card.Type)
        {
            card.Type = request.Type;
        }
        if (request.IsActive != card.IsActive)
        {
            card.IsActive = request.IsActive;
        }

        await _cardRepository.UpdateCardAsync(card);
    }

    public async Task BlockCardAsync(Guid cardId)
    {
        await _cardRepository.BlockCardAsync(cardId);
    }

    public async Task UnBlockCardAsync(Guid cardId)
    {
        await _cardRepository.UnBlockCardAsync(cardId);
    }

    public async Task DeleteCardAsync(Guid cardId)
    {
        await _cardRepository.DeleteCardAsync(cardId);
    }

}