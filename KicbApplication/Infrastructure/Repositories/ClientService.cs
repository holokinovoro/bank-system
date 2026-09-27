using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Users;
using Application.Interfaces;

namespace Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly AppDbContext _context;

    public ClientRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Client> CreateClientAsync(
        string firstName,
        string lastName,
        string middleName,
        string username,
        string password)
    {
        var client = new Client(firstName, lastName, middleName, username, password);
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task<Client?> GetClientByIdAsync(Guid clientId)
    {
        return await _context.Clients.FindAsync(clientId);
    }

    public async Task<List<Client>> GetAllClientsAsync()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task UpdateClientAsync(Client client)
    {
        _context.Clients.Update(client);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteClientAsync(Guid clientId)
    {
        var client = await _context.Clients.FindAsync(clientId);
        if (client != null)
        {
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }
    }

}