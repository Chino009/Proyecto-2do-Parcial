using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Http;

namespace TecNM.Proyecto.WebSite.Service.Interfaces;

public interface IGameCategoryService
{
    Task<Response<List<GameCategoryDto>>> GetAllAsync();

    Task<Response<GameCategoryDto>> GetById(int id);

    Task<Response<GameCategoryDto>> SaveAsync(GameCategoryDto gameCategory);

    Task<Response<GameCategoryDto>> UpdateAsync(GameCategoryDto gameCategory);

    Task<Response<bool>> DeleteAsync(int id); 
}