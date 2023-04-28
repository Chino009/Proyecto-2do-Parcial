using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Api.DataAccess.Interfaces;
using TecNM.Proyecto.Core.Entities;
using Dapper;
using Dapper.Contrib.Extensions;
namespace TecNM.Proyecto.Api.Repositories;

public class OrderGameRepository : IOrderGameRepository
{   
    private readonly IDbContext _dbContext;
    public OrderGameRepository(IDbContext context){
        _dbContext = context;
    }
    public async Task<OrderGame> SaveAsync(OrderGame OrderGame)
    {
        OrderGame.Id = await _dbContext.Connection.InsertAsync(OrderGame);
        return OrderGame;
    }
    public async Task<OrderGame> UpdateAsync(OrderGame OrderGame)
    {
        await _dbContext.Connection.UpdateAsync(OrderGame);
        return OrderGame;
    }
    public async Task<List<OrderGame>> GetAllAsync()
    {
        const string sql = "SELECT * FROM OrderGame WHERE IsDeleted = 0";
        var categories = await _dbContext.Connection.QueryAsync<OrderGame>(sql);
        return categories.ToList();
    }
    public async Task<bool> DeleteAsync(int id)
    {
       var OrderGame = await GetById(id);
       if (OrderGame == null){
         return false;
       }
       OrderGame.IsDeleted = true;
       return await _dbContext.Connection.UpdateAsync(OrderGame);
    }
    public async Task<OrderGame> GetById(int id)
    {
        var OrderGame = await _dbContext.Connection.GetAsync<OrderGame>(id);

        if(OrderGame == null){
            return null;
        }
        return OrderGame.IsDeleted == true ? null: OrderGame;
    }
}