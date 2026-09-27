using Domain.Models.Cards;

namespace Application.Contracts.Cards.ResponseDto;
public record CreateCardResponse //dto для ответа на создание карты
 {
     public string CardNumber { get; init; } = null!;
     public DateOnly ExpirationDate { get; init; }
     public CardType Type { get; init; }
     public string AccountNumber { get; init; } = null!;
 }