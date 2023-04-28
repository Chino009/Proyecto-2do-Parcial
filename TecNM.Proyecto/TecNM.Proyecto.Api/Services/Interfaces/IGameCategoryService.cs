using TecNM.Proyecto.Core.Dto;

namespace TecNM.Proyecto.Api.Services.interfaces;
public interface IGameCategoryService
{
    //metodo para guardar categorias
    Task<GameCategoryDto> SaveAsync(GameCategoryDto category);
    //Metodo para actualizar las categorias de Productos
    Task<GameCategoryDto> UpdateAsync(GameCategoryDto category);
    //Metodo para retornar una Lista de categorias
    Task<List<GameCategoryDto>> GetAllAsync();
    //Metodo para retornar el id de las categorias que borrara
    Task<bool> GameCategoryExist(int id);
    //Metodo para obtener uan categoria por id
    Task<GameCategoryDto> GetById(int id);
    Task<bool> DeleteAsync(int id);
}
