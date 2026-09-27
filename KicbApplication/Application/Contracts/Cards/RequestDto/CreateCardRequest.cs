using System.ComponentModel.DataAnnotations;
using Domain.Models.Cards;

namespace Application.Contracts.Cards.RequestDto;

public record CreateCardRequest //dto для запроса на создание карты с валидацией данных
{
    [Required]
    public Guid AccountId {get; set;}
    [Required]
    [StringLength(16, MinimumLength = 16, ErrorMessage = "Card number must be 16 digits.")]
    [RegularExpression(@"^\d{16}$", ErrorMessage = "Card number must be numeric.")]
    public string CardNumber {get; set;} = null!;
    [Required]
    [DataType(DataType.Date)]
    public DateOnly ExpirationDate { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddYears(3));
    [Required]
    public CardType Type {get; set;}

}