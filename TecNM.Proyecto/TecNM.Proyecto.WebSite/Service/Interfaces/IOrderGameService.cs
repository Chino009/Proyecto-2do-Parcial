using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Http;

namespace TecNM.Proyecto.WebSite.Service.Interfaces;

public interface IOrderGameService
{
    Task<Response<List<OrderGameDto>>> GetAllAsync();

    Task<Response<OrderGameDto>> GetById(int id);

    Task<Response<OrderGameDto>> SaveAsync(OrderGameDto orderGame);

    Task<Response<OrderGameDto>> UpdateAsync(OrderGameDto orderGame);

    Task<Response<bool>> DeleteAsync(int id);    
}