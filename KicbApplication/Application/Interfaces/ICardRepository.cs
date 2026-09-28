using Domain.Models.Cards;

namespace Application.Interfaces;

public interface ICardRepository
{
    Task<Card> CreateCardAsync(Guid accountId, string cardNumber, DateOnly expirationDate, CardType cardType);
    Task DeleteCardAsync(Guid cardId);
    Task<List<Card>> GetAllCardsAsync();
    Task<Card?> GetCardByIdAsync(Guid cardId);
    Task<List<Card>> GetCardsByAccountIdAsync(Guid accountId);
    Task UpdateCardAsync(Card card);
    Task BlockCardAsync(Guid cardId);
    Task UnBlockCardAsync(Guid cardId);
}
