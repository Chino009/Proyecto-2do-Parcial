using Microsoft.AspNetCore.Mvc;
using TecNM.Proyecto.Core.Entities;
using TecNM.Proyecto.Core.Http;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Api.Services.interfaces;
namespace TecNM.Proyecto.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderGameController : ControllerBase
{
    private readonly IOrderGameService _Order1Service;
    public OrderGameController(IOrderGameService Order1Service)
    {
        _Order1Service = Order1Service;
    }
    [HttpGet]
    public async Task<ActionResult<Response<List<OrderGameDto>>>> GetAll()
    {
         var response = new Response<List<OrderGameDto>>{
            Data = await _Order1Service.GetAllAsync()
        };
        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult<Response<OrderGameDto>>> Post([FromBody] OrderGameDto Order1Dto){
        var response = new Response<OrderGameDto>{
            Data = await _Order1Service.SaveAsync(Order1Dto)
        };
        return Created($"/api/[controller]/{response.Data.Id}",response);
    }
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<OrderGameDto>>> GetById(int id){
        var response = new Response<OrderGameDto>();
        if(!await _Order1Service.Order1Exist(id)){
            response.Errors.Add("Order Not Found");
            return NotFound(response);
        }
        response.Data = await _Order1Service.GetById(id);
        return Ok(response);
    }
    [HttpPut]
    public async Task<ActionResult<Response<OrderGameDto>>> Update([FromBody] OrderGameDto Order1Dto){
        var response = new Response<OrderGameDto>();
        if(!await _Order1Service.Order1Exist(Order1Dto.Id))
        {
           response.Errors.Add("Order Not Found");
            return NotFound(response);
        }       
        response.Data = await _Order1Service.UpdateAsync(Order1Dto);
        return Ok(response);
    }
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<OrderGame>>> Delete(int id){  
        var response = new Response<bool>();
        var result = await _Order1Service.DeleteAsync(id);
        response.Data = result;
        return Ok(response);
    }
}