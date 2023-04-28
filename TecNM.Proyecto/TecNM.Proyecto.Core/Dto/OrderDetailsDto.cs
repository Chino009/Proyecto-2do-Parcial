using System.ComponentModel.DataAnnotations;
using TecNM.Proyecto.Core.Entities;
namespace TecNM.Proyecto.Core.Dto;

public class OrderDetailsDto : DtoBase
{
    [RegularExpression("^[1-9][0-9]{0,44}$", 
    ErrorMessage = "IdGame: Introduce solamente carácteres númericos enteros.")]
    public int idGame { get; set; }
    
    [RegularExpression("^[1-9][0-9]{0,44}$", 
    ErrorMessage = "IdOrder: Introduce solamente carácteres númericos enteros.")]
    public int idOrder { get; set; }

    [RegularExpression("^[0-9]{0,44}$",
     ErrorMessage = "Quantity: Introduce solamente carácteres númericos enteros.")]
    public int Quantity { get; set; }

    public OrderDetailsDto()
    {

    }
    public OrderDetailsDto(OrderDetails OrderDetails)
    {
        Id = OrderDetails.Id;
        idOrder = OrderDetails.idOrder;
           idGame = OrderDetails.idGame;
        Quantity = OrderDetails.Quantity;
    }
}
