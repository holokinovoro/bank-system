using Application.Contracts.Cards.RequestDto;
using Application.Contracts.Cards.ResponseDto;

namespace Application.Interfaces;

public interface ICardService
{
    Task BlockCardAsync(Guid cardId);
    Task<CreateCardResponse> CreateCardAsync(CreateCardRequest request);
    Task DeleteCardAsync(Guid cardId);
    Task<List<GetCardResponse>> GetAllCardsAsync();
    Task<GetCardResponse> GetCardByIdAsync(Guid cardId);
    Task<List<GetCardResponse>> GetCardsByAccountIdAsync(Guid accountId);
    Task UpdateCardAsync(UpdateCardRequest request);
}
