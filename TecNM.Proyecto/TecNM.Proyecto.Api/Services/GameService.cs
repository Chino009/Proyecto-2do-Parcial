using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Api.Services.interfaces;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Entities;

namespace TecNM.Proyecto.Api.Services;
public class GameService : IGameService
{
    private readonly IGameRepository _GameRepository;
    private readonly IGameCategoryRepository _GameCategoryRepository;
    public GameService(IGameRepository GameRepository, IGameCategoryRepository GameCategoryRepository)
    {
        _GameRepository = GameRepository;
        _GameCategoryRepository = GameCategoryRepository;
    }
    public async Task<GameDto> SaveAsync(GameDto GameDto)
    {
        var GameoCategory = await _GameCategoryRepository.GetById(GameDto.IdCategory);
        if (GameoCategory == null)
            throw new Exception("Category no encontrada");
        var Game = new Game
        {
            Name = GameDto.Name,
            Description = GameDto.Description,
            Price = GameDto.Price,
            Image = GameDto.Image,
            Stock = GameDto.Stock,
            IdCategory = GameDto.IdCategory,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
        };
        Game = await _GameRepository.SaveAsync(Game);
        GameDto.Id = Game.Id;
        return GameDto;
    }
    public async Task<GameDto> UpdateAsync(GameDto GameDto)
    {
        var Game = await _GameRepository.GetById(GameDto.Id);
        if (Game == null)
            throw new Exception("Game Not Found");
        var GameoCategory = await _GameCategoryRepository.GetById(GameDto.IdCategory);
        if (GameoCategory == null)
            throw new Exception("Game Category Not Found");
        Game.Name = GameDto.Name;
        Game.Description = GameDto.Description;
        Game.Price = GameDto.Price;
        Game.Image = GameDto.Image;
        Game.Stock = GameDto.Stock;
        Game.IdCategory = GameDto.IdCategory;
        Game.UpdatedBy = "";
        Game.UpdateDate = DateTime.Now;
        await _GameRepository.UpdateAsync(Game);
        return GameDto;
    }
    public async Task<List<GameDto>> GetAllAsync()
    {
        var categories = await _GameRepository.GetAllAsync();
        var categoriesDto =
            categories.Select(c => new GameDto(c)).ToList();
        return categoriesDto;
    }
    public async Task<bool> GameExist(int id)
    {
        var Game = await _GameRepository.GetById(id);
        return (Game != null);
    }
    public async Task<GameDto> GetById(int id)
    {
        var Game = await _GameRepository.GetById(id);
        if (Game == null)
            throw new Exception("Game Not Found");
        var GameDto = new GameDto(Game);
        return GameDto;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        return await _GameRepository.DeleteAsync(id);
    }
}

