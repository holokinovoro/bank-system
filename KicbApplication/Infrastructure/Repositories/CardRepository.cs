using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Cards;
using Application.Interfaces;

namespace Infrastructure.Repositories;

public class CardRepository : ICardRepository
{
    private readonly AppDbContext _context;

    public CardRepository(AppDbContext context)
    {
        _context = context;
    }

    // метод для создания карты для определенного счета
    public async Task<Card> CreateCardAsync(
        Guid accountId,
        string cardNumber,
        DateOnly expirationDate,
        CardType cardType)
    {
        // проверяем, существует ли счет с указанным accountId
        var account = await _context.Accounts.FindAsync(accountId);
        if (account == null)
        {
            throw new Exception("Account not found");
        }

        // создаем новую карту и связываем ее с найденным счетом
        var accountCard = new Card()
        {
            CardNumber = cardNumber,
            Type = cardType,
            ExpirationDate = expirationDate,
            AccountId = account.Id,
            Account = account
        };
        _context.Cards.Add(accountCard);
        await _context.SaveChangesAsync();
        return accountCard;
    }

    public async Task<Card?> GetCardByIdAsync(Guid cardId)
    {
        return await _context.Cards.FindAsync(cardId);
    }

    public async Task<List<Card>> GetAllCardsAsync()
    {
        return await _context.Cards.ToListAsync();
    }

    public async Task<List<Card>> GetCardsByAccountIdAsync(Guid accountId)
    {
        return await _context.Cards
            .Where(c => c.AccountId == accountId)
            .ToListAsync();
    }

    public async Task UpdateCardAsync(Card card)
    {
        _context.Cards.Update(card);
        await _context.SaveChangesAsync();
    }

    public async Task BlockCardAsync(Guid cardId)
    {
        var card = await _context.Cards.FindAsync(cardId);
        if (card != null)
        {
            card.IsActive = false;
            _context.Cards.Update(card);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UnBlockCardAsync(Guid cardId)
    {
        var card = await _context.Cards.FindAsync(cardId);
        if (card != null)
        {
            card.IsActive = true;
            _context.Cards.Update(card);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteCardAsync(Guid cardId)
    {
        var card = await _context.Cards.FindAsync(cardId);
        if (card != null)
        {
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
        }
    }
}