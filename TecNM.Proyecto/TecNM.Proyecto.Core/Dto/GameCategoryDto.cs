using System.ComponentModel.DataAnnotations;
using TecNM.Proyecto.Core.Entities;
namespace TecNM.Proyecto.Core.Dto;

public class GameCategoryDto : DtoBase{
    
    [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ]+$", ErrorMessage = "Name: Introduce carácteres alfabeticos.")]
[StringLength(100, MinimumLength =1, ErrorMessage = "Sobrepasaste el límite de carácteres.")]
public string? Name { get; set; }

public GameCategoryDto(){

}
public GameCategoryDto(GameCategory category){

    Name = category.Name;
    Id = category.Id;
    
  }
}
