using TecNM.Proyecto.Core.Dto;

namespace TecNM.Proyecto.Api.Services.interfaces;

public interface IGameService
{
    //metodo para guardar Gameos
    Task<GameDto> SaveAsync(GameDto Game);
    //Metodo para actualizar las Gameos
    Task<GameDto> UpdateAsync(GameDto Game);
    //Metodo para retornar una Lista de Gameos
    Task<List<GameDto>> GetAllAsync();
    //Metodo para retornar el id de las Gameos que borrara
    Task<bool> GameExist(int id);
    //Metodo para obtener uan categoria por id
    Task<GameDto> GetById(int id);
    Task<bool> DeleteAsync(int id);
}
