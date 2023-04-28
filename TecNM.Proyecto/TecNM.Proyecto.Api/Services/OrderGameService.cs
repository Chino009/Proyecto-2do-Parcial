using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Api.Services.interfaces;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Entities;

namespace TecNM.Proyecto.Api.Services;
public class OrderGameService : IOrderGameService
{
    private readonly IOrderGameRepository _Order1Repository;
    private readonly IUserRepository _UserRepository;
    public OrderGameService(IOrderGameRepository Order1Repository,IUserRepository UserRepository)
    {
        _Order1Repository = Order1Repository;        
        _UserRepository = UserRepository;
    }
    public async Task<OrderGameDto> SaveAsync(OrderGameDto Order1Dto)
    {
        var user = await _UserRepository.GetById(Order1Dto.idUser);
        if (user == null)
            throw new Exception("User no encontrado");
        var Order1 = new OrderGame
        {
            idUser = Order1Dto.idUser,Ammount = Order1Dto.Ammount,
            orderAddress = Order1Dto.orderAddress,CreatedBy = "",
            CreatedDate = DateTime.Now,UpdatedBy = "",
            UpdateDate = DateTime.Now
        };
        Order1 = await _Order1Repository.SaveAsync(Order1);
        Order1Dto.Id = Order1.Id;
        return Order1Dto;
    }
    public async Task<OrderGameDto> UpdateAsync(OrderGameDto Order1Dto)
    {
        var user = await _UserRepository.GetById(Order1Dto.idUser);
        if (user == null)
            throw new Exception("User no encontrado");
        var Order1 = await _Order1Repository.GetById(Order1Dto.Id);
        if (Order1 == null)
            throw new Exception("Order Not Found");
        Order1.idUser = Order1Dto.idUser;
        Order1.Ammount = Order1Dto.Ammount;
        Order1.orderAddress = Order1Dto.orderAddress;
        Order1.UpdatedBy = "";
        Order1.UpdateDate = DateTime.Now;
        await _Order1Repository.UpdateAsync(Order1);
        return Order1Dto;
    }
    public async Task<List<OrderGameDto>> GetAllAsync()
    {
        var categories = await _Order1Repository.GetAllAsync();
        var categoriesDto =
            categories.Select(c => new OrderGameDto(c)).ToList();
        return categoriesDto;
    }
    public async Task<bool> Order1Exist(int id)
    {
        var Order1 = await _Order1Repository.GetById(id);
        return (Order1 != null);
    }
    public async Task<OrderGameDto> GetById(int id)
    {
        var Order1 = await _Order1Repository.GetById(id);
        if (Order1 == null)
            throw new Exception("Order Not Found");
        var Order1Dto = new OrderGameDto(Order1);
        return Order1Dto;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        return await _Order1Repository.DeleteAsync(id);
    }
}