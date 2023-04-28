using System.ComponentModel.DataAnnotations;

using TecNM.Proyecto.Core.Entities;
namespace TecNM.Proyecto.Core.Dto;
public class UserDto : DtoBase{

[RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ]+$", ErrorMessage = "Name: Introduce solamente carácteres alfabeticos.")]
[StringLength(100, MinimumLength =1, ErrorMessage = "Sobrepasaste el límite de carácteres.")]
public string? Name { get; set; }
public string? Username { get; set; }
public string? Password { get; set; }

[RegularExpression(@"^[0-9]*$", ErrorMessage = "Phone: Introduce solo números")]
[StringLength(10, MinimumLength = 10, ErrorMessage = "Sobrepasaste el límite de carácteres")]
public string? Phone { get; set; }
public string? Address { get; set; }

public UserDto(){
}

public UserDto(User user){
    Id = user.Id;
    Name = user.Name;
    Username = user.Username;
    Phone = user.Phone;
    Password = user.Password;
    Address = user.Address;
  }
}
