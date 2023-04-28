using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Api.DataAccess.Interfaces;
using TecNM.Proyecto.Core.Entities;
using Dapper;
using Dapper.Contrib.Extensions;
namespace TecNM.Proyecto.Api.Repositories;

public class GameCategoryRepository:IGameCategoryRepository
{
    private readonly IDbContext _dbContext;
    public GameCategoryRepository(IDbContext context){
        _dbContext = context;
    }
    public async Task<GameCategory> SaveAsync(GameCategory category)
    {
        //metodo propio para hacer incersiones asincronas 
        category.Id = await _dbContext.Connection.InsertAsync(category);
        return category;
    }
    public async Task<GameCategory> UpdateAsync(GameCategory category)
    {
        await _dbContext.Connection.UpdateAsync(category);
        return category;
    }
    public async Task<List<GameCategory>> GetAllAsync()
    {
        const string sql = "SELECT * FROM GameCategory WHERE IsDeleted = 0";
        var categories = await _dbContext.Connection.QueryAsync<GameCategory>(sql);
        return categories.ToList();
    }
    public async Task<bool> DeleteAsync(int id)
    {
       var category = await GetById(id);
       if (category == null){
         return false;
       }
       category.IsDeleted = true;
       return await _dbContext.Connection.UpdateAsync(category);
    }
    public async Task<GameCategory> GetById(int id)
    {
        var category = await _dbContext.Connection.GetAsync<GameCategory>(id);
        if(category == null){
            return null;
        }
        return category.IsDeleted == true ? null: category;
    }
}