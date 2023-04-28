using System.ComponentModel.DataAnnotations;
using TecNM.Proyecto.Core.Entities;
namespace TecNM.Proyecto.Core.Dto;
public class GameDto : DtoBase
{
    [RegularExpression("^(?=[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ0-9])[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ0-9 ]+$",
        ErrorMessage = "Name: Introduce solamente carácteres albabeticos y númericos")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Sobrepasaste el límite de carácteres")]

    public string? Name { get; set; }
        public string? Description { get; set; }
    
    [RegularExpression(@"^\d{1,4}([.,]\d{1,2})?$", 
    ErrorMessage = "Price: Formato de precio erróneo")]
    public double Price { get; set; }

    public string? Image { get; set; }
    [RegularExpression("^[0-9]{1,4}$", ErrorMessage = "Stock: Introduce carácteres numéricos enteros.")]
     public int Stock { get; set; }
     [RegularExpression("^[1-9][0-9]{0,44}$", 
     ErrorMessage = "IdCategory: Introduce carácter númerico entero")]
      public int IdCategory { get; set; }
      
    public GameDto()
    {

    }
    public GameDto(Game Game)
    {
        Id = Game.Id;
        Name = Game.Name;
        Description = Game.Description;
        Price = Game.Price;
        Image = Game.Image;
        Stock = Game.Stock;
        IdCategory = Game.IdCategory;
    }
}
