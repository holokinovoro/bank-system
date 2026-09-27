using Microsoft.EntityFrameworkCore;
using Domain.Models.Accounts;
using Domain.Models.Cards;
using Domain.Models.Phones;
using Domain.Models.Users;

namespace Infrastructure.DataBase;

public class AppDbContext
(DbContextOptions<AppDbContext> options) 
: DbContext(options)
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Phone> Phones { get; set; }
    public DbSet<Account> Accounts {get; set;}
    public DbSet<Card> Cards {get; set;}

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {

    //     base.OnModelCreating(modelBuilder);
    // }
}