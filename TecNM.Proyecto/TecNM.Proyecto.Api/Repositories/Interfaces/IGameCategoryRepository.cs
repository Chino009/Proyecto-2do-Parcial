using TecNM.Proyecto.Core.Entities;

namespace TecNM.Proyecto.Api.Repositories.Interfaces;

public interface IGameCategoryRepository
{

    Task<GameCategory> SaveAsync(GameCategory category);


    Task<GameCategory> UpdateAsync(GameCategory category);
    Task<List<GameCategory>> GetAllAsync();


    Task<bool> DeleteAsync(int id);

    Task<GameCategory> GetById(int id);

    }