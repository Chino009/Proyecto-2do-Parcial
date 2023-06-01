using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Http;

namespace TecNM.Proyecto.WebSite.Service.Interfaces;

public interface IGameService
{
    Task<Response<List<GameDto>>> GetAllAsync();

    Task<Response<GameDto>> GetById(int id);

    Task<Response<GameDto>> SaveAsync(GameDto game);

    Task<Response<GameDto>> UpdateAsync(GameDto game);

    Task<Response<bool>> DeleteAsync(int id);
}