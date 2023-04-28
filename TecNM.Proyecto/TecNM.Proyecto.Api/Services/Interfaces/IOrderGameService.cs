using TecNM.Proyecto.Core.Dto;

namespace TecNM.Proyecto.Api.Services.interfaces;

public interface IOrderGameService
{
    //metodo para guardar orders
    Task<OrderGameDto> SaveAsync(OrderGameDto Order1);
    //Metodo para actualizar las orders de Productos
    Task<OrderGameDto> UpdateAsync(OrderGameDto Order1);
    //Metodo para retornar una Lista de orders
    Task<List<OrderGameDto>> GetAllAsync();
    //Metodo para retornar el id de las orders que borrara
    Task<bool> Order1Exist(int id);
    //Metodo para obtener uan categoria por id
    Task<OrderGameDto> GetById(int id);
    Task<bool> DeleteAsync(int id);
}
