using TecNM.Proyecto.Core.Entities;

namespace TecNM.Proyecto.Api.Repositories.Interfaces;

public interface IOrderGameRepository
{

    Task<OrderGame> SaveAsync(OrderGame OrderGame);


    Task<OrderGame> UpdateAsync(OrderGame OrderGame);
    Task<List<OrderGame>> GetAllAsync();


    Task<bool> DeleteAsync(int id);

    Task<OrderGame> GetById(int id);

    }