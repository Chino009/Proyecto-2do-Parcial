using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Core.Entities;

namespace TecNM.Proyecto.Api.Repositories;

public class InMemoryGameCategoryRepository:IGameCategoryRepository
{

    private readonly List<GameCategory> _categories;
    public InMemoryGameCategoryRepository(){
        _categories = new List<GameCategory>();
    }


    public async Task<GameCategory> SaveAsync(GameCategory category)
    {
        category.Id = _categories.Count +1;

        _categories.Add(category);

        return category;
    }

    public async Task<GameCategory> UpdateAsync(GameCategory category)
    {
        var index = _categories.FindIndex(x => x.Id == category.Id);
        if(index != -1)
            _categories[index] = category;
        return await Task.FromResult(category);
    }

    public async Task<List<GameCategory>> GetAllAsync()
    {
        // var list = new List<GameCategory>();
        // list.Add(new GameCategory{Id = 1, Name = "Test", Description = "Test"});
        // list.Add(new GameCategory{Id = 2, Name = "Test2", Description = "Test2"});
        return _categories;
    }

    public async Task<bool> DeleteAsync(int id)
    {   
        _categories.RemoveAll(x => x.Id == id);

        return true;        
    }

    public async Task<GameCategory> GetById(int id)
    {
        //que obtenga el primero, pide una condicion. 
        var category = _categories.FirstOrDefault(x => x.Id == id);
        
        return await Task.FromResult(category);
    }
}