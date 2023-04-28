using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Api.DataAccess.Interfaces;
using TecNM.Proyecto.Core.Entities;
using Dapper;
using Dapper.Contrib.Extensions;
namespace TecNM.Proyecto.Api.Repositories;

public class GameRepository:IGameRepository
{
    private readonly IDbContext _dbContext;
    public GameRepository(IDbContext context){
        _dbContext = context;
    }
    public async Task<Game> SaveAsync(Game  Game)
    {
        Game.Id = await _dbContext.Connection.InsertAsync( Game);
        return Game;
    }
    public async Task<Game> UpdateAsync(Game  Game)
    {
        await _dbContext.Connection.UpdateAsync( Game);
        return Game;
    }
    public async Task<List<Game>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Game WHERE IsDeleted = 0";
        var categories = await _dbContext.Connection.QueryAsync<Game>(sql);
        return categories.ToList();
    }
    public async Task<bool> DeleteAsync(int id)
    {
       var Game = await GetById(id);
       if (Game == null){
         return false;
       }
       Game.IsDeleted = true;
       return await _dbContext.Connection.UpdateAsync( Game);
    }
    public async Task<Game> GetById(int id)
    {
        var Game = await _dbContext.Connection.GetAsync<Game>(id);
        if(Game == null){
            return null;
        }
        return Game.IsDeleted == true ? null: Game;
    }
}