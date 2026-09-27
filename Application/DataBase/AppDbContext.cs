using Microsoft.EntityFrameworkCore;
using Models.Accounts;
using Models.Cards;
using Models.Phones;
using Models.Users;

namespace DataBase;

public class AppDbContext
(DbContextOptions<AppDbContext> options) 
: DbContext(options)
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Phone> Phones { get; set; }
    public DbSet<Account> Accounts {get; set;}
    public DbSet<Card> Cards {get; set;}
}