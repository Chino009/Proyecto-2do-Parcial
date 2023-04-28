using Microsoft.AspNetCore.Mvc;
using TecNM.Proyecto.Core.Entities;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Http;
using TecNM.Proyecto.Api.Services.interfaces;

namespace TecNM.Proyecto.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameService _ProductService;
    public GameController(IGameService ProductService)
    {
        _ProductService = ProductService;
    }
    [HttpGet]
    public async Task<ActionResult<Response<List<GameDto>>>> GetAll()
    {
        var response = new Response<List<GameDto>>{
            Data = await _ProductService.GetAllAsync()
        };
        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult<Response<GameDto>>> Post([FromBody] GameDto categoryDto){
        var response = new Response<GameDto>{
            Data = await _ProductService.SaveAsync(categoryDto)
        };
        return Created($"/api/[controller]/{response.Data.Id}",response);
    }
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<GameDto>>> GetById(int id){
        var response = new Response<GameDto>();
        if(!await _ProductService.GameExist(id)){
            response.Errors.Add("Game Not Found");
            return NotFound(response);
        }
        response.Data = await _ProductService.GetById(id);
        return Ok(response);
    }
    [HttpPut]
        public async Task<ActionResult<Response<GameDto>>> Update([FromBody] GameDto categoryDto){
        var response = new Response<GameDto>();
        if(!await _ProductService.GameExist(categoryDto.Id))
        {
           response.Errors.Add("Game Not Found");
            return NotFound(response);
        }
        response.Data = await _ProductService.UpdateAsync(categoryDto);
        return Ok(response);
    }
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Game>>> Delete(int id){
        var response = new Response<bool>();
        var result = await _ProductService.DeleteAsync(id);
        response.Data = result;      
        return Ok(response);
    }
}