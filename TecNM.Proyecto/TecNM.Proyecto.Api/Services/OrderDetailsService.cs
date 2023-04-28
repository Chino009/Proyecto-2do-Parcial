using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Api.Services.interfaces;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Entities;

namespace TecNM.Proyecto.Api.Services;

public class OrderDetailsService : IOrderDetailsService
{
    private readonly IOrderDetailsRepository _OrderDetailsRepository;
    private readonly IGameRepository _GameRepository;
    private readonly IOrderGameRepository _Order1Repository;
    public OrderDetailsService(IOrderDetailsRepository OrderDetailsRepository, IGameRepository ProductRepository, IOrderGameRepository Order1Repository)
    {
        _OrderDetailsRepository = OrderDetailsRepository;
        _GameRepository = ProductRepository;
        _Order1Repository = Order1Repository;
    }
    public async Task<OrderDetailsDto> SaveAsync(OrderDetailsDto OrderDetailsDto)
    {
        var product = await _GameRepository.GetById(OrderDetailsDto.idGame);
        if (product == null)
            throw new Exception("Game no encontrado");
        var order1 = await _Order1Repository.GetById(OrderDetailsDto.idOrder);
        if (order1 == null)
            throw new Exception("Order no encontrado");
        var OrderDetails = new OrderDetails
        {
            idGame = OrderDetailsDto.idGame,
            idOrder = OrderDetailsDto.idOrder,
            Quantity = OrderDetailsDto.Quantity,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
        };
        OrderDetails = await _OrderDetailsRepository.SaveAsync(OrderDetails);
        OrderDetailsDto.Id = OrderDetails.Id;
        return OrderDetailsDto;
    }
    public async Task<OrderDetailsDto> UpdateAsync(OrderDetailsDto OrderDetailsDto)
    {
        var OrderDetails = await _OrderDetailsRepository.GetById(OrderDetailsDto.Id);
        if (OrderDetails == null)
            throw new Exception("OrderDetails Not Found");
        var product = await _GameRepository.GetById(OrderDetailsDto.idGame);
        if (product == null)
            throw new Exception("Game no encontrado");
        var order1 = await _Order1Repository.GetById(OrderDetailsDto.idOrder);
        if (order1 == null)
            throw new Exception("Order no encontrado");
        OrderDetails.idGame = OrderDetailsDto.idGame;
        OrderDetails.idOrder = OrderDetailsDto.idOrder;
        OrderDetails.Quantity = OrderDetailsDto.Quantity;
        OrderDetails.UpdatedBy = "";
        OrderDetails.UpdateDate = DateTime.Now;
        await _OrderDetailsRepository.UpdateAsync(OrderDetails);
        return OrderDetailsDto;
    }
    public async Task<List<OrderDetailsDto>> GetAllAsync()
    {
        var categories = await _OrderDetailsRepository.GetAllAsync();
        var categoriesDto =
            categories.Select(c => new OrderDetailsDto(c)).ToList();
        return categoriesDto;
    }
    public async Task<bool> OrderDetailsExist(int id)
    {
        var OrderDetails = await _OrderDetailsRepository.GetById(id);
        return (OrderDetails != null);
    }
    public async Task<OrderDetailsDto> GetById(int id)
    {
        var OrderDetails = await _OrderDetailsRepository.GetById(id);
        if (OrderDetails == null)
            throw new Exception("OrderDetails Not Found");
        var OrderDetailsDto = new OrderDetailsDto(OrderDetails);
        return OrderDetailsDto;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        return await _OrderDetailsRepository.DeleteAsync(id);
    }
}