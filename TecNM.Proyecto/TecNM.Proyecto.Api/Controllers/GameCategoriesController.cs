using Microsoft.AspNetCore.Mvc;
using TecNM.Proyecto.Core.Entities;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Http;
using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Api.Services.interfaces;

namespace TecNM.Proyecto.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameCategoryController : ControllerBase
{
    private readonly IGameCategoryService _productCategoryService;
    public GameCategoryController(IGameCategoryService productCategoryService)
    {
        _productCategoryService = productCategoryService;
    }
    [HttpGet]
    public async Task<ActionResult<Response<List<GameCategoryDto>>>> GetAll()
    {
        var response = new Response<List<GameCategoryDto>>{
            Data = await _productCategoryService.GetAllAsync()
        };
        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult<Response<GameCategoryDto>>> Post([FromBody] GameCategoryDto categoryDto){   
        var response = new Response<GameCategoryDto>{
            Data = await _productCategoryService.SaveAsync(categoryDto)
        };
        return Created($"/api/[controller]/{response.Data.Id}",response);
    }
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<GameCategoryDto>>> GetById(int id){
        var response = new Response<GameCategoryDto>();
        if(!await _productCategoryService.GameCategoryExist(id)){
            response.Errors.Add("Game Not Found");
            return NotFound(response);
        }
        response.Data = await _productCategoryService.GetById(id);
        return Ok(response);
    }
    [HttpPut]
        public async Task<ActionResult<Response<GameCategoryDto>>> Update([FromBody] GameCategoryDto categoryDto){
        var response = new Response<GameCategoryDto>();
        
        if(!await _productCategoryService.GameCategoryExist(categoryDto.Id))
        {
           response.Errors.Add("Game Not Found");
            return NotFound(response);
        }
        response.Data = await _productCategoryService.UpdateAsync(categoryDto);
        return Ok(response);
    }
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<GameCategory>>> Delete(int id){
       var response = new Response<bool>();
        var result = await _productCategoryService.DeleteAsync(id);
        response.Data = result;
        return Ok(response);
    }
}