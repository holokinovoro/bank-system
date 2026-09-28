using Domain.Models.Cards;

namespace Application.Contracts.Cards.ResponseDto;
public record CreateCardResponse //dto для ответа на создание карты
 {
     public string CardNumber { get; set; } = null!;
     public DateOnly ExpirationDate { get; set; }
     public CardType Type { get; set; }
     public string AccountNumber { get; set; } = null!;
 }