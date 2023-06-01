using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.WebSite.Service.Interfaces;

namespace TecNM.Proyecto.WebSite.Pages.GameCategory;

public class ListModel : PageModel
{
    private readonly IGameCategoryService _service;
    public List<GameCategoryDto> Game { get; set; }

    
    public ListModel(IGameCategoryService service)
    {
        Game = new List<GameCategoryDto>();
        _service = service;
    }
    
    public async Task<IActionResult> OnGet()
    {
        //llamada al servicio
        var response = await _service.GetAllAsync();
        Game = response.Data;

        return Page();
    }
}