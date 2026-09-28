using Infrastructure.DataBase;
using Application.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Application.Services;

var builder = WebApplication.CreateBuilder(args);

// конфигурация бд
builder.Services.AddDbContext<AppDbContext>(o =>
    o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); // регистрирую базу данных 

// контроллеры
builder.Services.AddControllers();
    
// регистрирую свои репозитории с временем жизни Scoped, чтобы они создавались на каждый запрос
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddScoped<IPhoneRepository, PhoneRepository>();
builder.Services.AddScoped<IPhoneService, PhoneService>();

builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<ICardService, CardService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// app.UseRouting();

app.MapControllers();
// app.UseAuthorization(); не успел реализовать авторизацию и аутентификацию :(

app.Run();

// все что смог успеть сделать. 
// тут я реализовал чистую архитектуру, поделил проект на логические слои 
// есть все crud операции для каждой сущности
// надеюсь тестовое задание получилось нормальным)

// P.S. было написано без единой строки нейронки 