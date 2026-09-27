using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Phones;
using Application.Interfaces;

namespace Infrastructure.Repositories;

public class PhoneRepository : IPhoneRepository
{
    private readonly AppDbContext _context;

    public PhoneRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Phone> CreatePhoneAsync(Guid clientId, string phoneNumber, PhoneType phoneType)
    {
        var client = await _context.Clients.FindAsync(clientId);
        if (client == null)
        {
            throw new Exception("Client not found");
        }

        var phone = new Phone()
        {
            Number = phoneNumber,
            Type = phoneType,
            clientId = clientId,
            Client = client
        };
        _context.Phones.Add(phone);
        await _context.SaveChangesAsync();
        return phone;
    }

    public async Task<Phone?> GetPhoneByIdAsync(Guid phoneId)
    {
        Phone? phone = await _context.Phones.FindAsync(phoneId);
        return phone;
    }

    public async Task<List<Phone>> GetAllPhonesAsync()
    {
        return await _context.Phones.ToListAsync();
    }

    public async Task<List<Phone>> GetPhonesByClientIdAsync(Guid clientId)
    {
        return await _context.Phones
            .Where(p => p.clientId == clientId)
            .ToListAsync();
    }

    public async Task UpdatePhoneAsync(Phone phone)
    {
        _context.Phones.Update(phone);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePhoneAsync(Guid phoneId)
    {
        var phone = await _context.Phones.FindAsync(phoneId);
        if (phone != null)
        {
            _context.Phones.Remove(phone);
            await _context.SaveChangesAsync();
        }
    }
}