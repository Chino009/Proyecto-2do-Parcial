using TecNM.Proyecto.Core.Entities;

namespace TecNM.Proyecto.Api.Repositories.Interfaces;

public interface IGameRepository
{

    Task<Game> SaveAsync(Game Game);


    Task<Game> UpdateAsync(Game Game);
    Task<List<Game>> GetAllAsync();


    Task<bool> DeleteAsync(int id);

    Task<Game> GetById(int id);

    }