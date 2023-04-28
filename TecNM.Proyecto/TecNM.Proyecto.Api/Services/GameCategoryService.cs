using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Api.Services.interfaces;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Entities;
namespace TecNM.Proyecto.Api.Services;
public class GameCategoryService : IGameCategoryService
{
    private readonly IGameCategoryRepository _productCategoryRepository;
    public GameCategoryService(IGameCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }
    public async Task<GameCategoryDto> SaveAsync(GameCategoryDto categoryDto)
    {
       var category = new GameCategory
       {
            Name = categoryDto.Name,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
        };
       category = await _productCategoryRepository.SaveAsync(category);
        categoryDto.Id = category.Id;
        return categoryDto;
    }
    public async Task<GameCategoryDto> UpdateAsync(GameCategoryDto categoryDto)
    {
        var category = await _productCategoryRepository.GetById(categoryDto.Id);
        if (category == null)
            throw new Exception("Game Not Found");
        category.Name = categoryDto.Name;
        category.UpdatedBy = "";
        category.UpdateDate = DateTime.Now;
        await _productCategoryRepository.UpdateAsync(category);
        return categoryDto;
    }
    public async Task<List<GameCategoryDto>> GetAllAsync()
    {
        var categories = await _productCategoryRepository.GetAllAsync();
        var categoriesDto =
            categories.Select(c => new GameCategoryDto(c)).ToList();
        return categoriesDto;
    }
    public async Task<bool> GameCategoryExist(int id)
    {
        var category = await _productCategoryRepository.GetById(id);
        return (category != null);
    }
    public async Task<GameCategoryDto> GetById(int id)
    {
        var category = await _productCategoryRepository.GetById(id);
        if (category == null)
            throw new Exception("Game Not Found");
        var categoryDto = new GameCategoryDto(category);
        return categoryDto;
    }
      public async Task<bool> DeleteAsync(int id)
    {
         return await _productCategoryRepository.DeleteAsync(id);
    }
}

