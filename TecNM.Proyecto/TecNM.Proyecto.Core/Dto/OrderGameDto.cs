using System.ComponentModel.DataAnnotations;
using TecNM.Proyecto.Core.Entities;
namespace TecNM.Proyecto.Core.Dto;

public class OrderGameDto : DtoBase
{
    [RegularExpression("^[1-9][0-9]{0,44}$",
     ErrorMessage = "IdUser: Introduce solamente carácteres númericos enteros.")]
    public int idUser { get; set; }
    
    [RegularExpression(@"^\d{1,10}([.,]\d{1,2})?$", 
    ErrorMessage = "Ammount: Introduce solamente carácteres númericos.")]
    public double Ammount { get; set; }
    public string orderAddress { get; set; }

    public OrderGameDto()
    {

    }
    public OrderGameDto(OrderGame Order1)
    {
        Id = Order1.Id;
        idUser = Order1.idUser;
        Ammount = Order1.Ammount;
        orderAddress = Order1.orderAddress;

    }
}
