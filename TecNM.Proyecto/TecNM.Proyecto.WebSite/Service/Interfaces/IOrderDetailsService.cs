using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Http;

namespace TecNM.Proyecto.WebSite.Service.Interfaces;

public interface IOrderDetailsService
{
    Task<Response<List<OrderDetailsDto>>> GetAllAsync();

    Task<Response<OrderDetailsDto>> GetById(int id);

    Task<Response<OrderDetailsDto>> SaveAsync(OrderDetailsDto order);

    Task<Response<OrderDetailsDto>> UpdateAsync(OrderDetailsDto order);

    Task<Response<bool>> DeleteAsync(int id);
}