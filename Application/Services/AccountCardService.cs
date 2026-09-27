using DataBase;
using Microsoft.EntityFrameworkCore;
using Models.Cards;

namespace Services;

public class AccountCardService
{
    private readonly AppDbContext _context;

    public AccountCardService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Card> CreateCardAsync(
        Guid accountId, 
        string cardNumber, 
        CardType cardType)
    {
        var account = await _context.Accounts.FindAsync(accountId);
        if (account == null)
        {
            throw new Exception("Account not found");
        }

        var accountCard = new Card()
        {
            CardNumber = cardNumber,
            Type = cardType,
            AccountId = accountId,
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