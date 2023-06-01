using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.WebSite.Service.Interfaces;

namespace TecNM.Proyecto.WebSite.Pages.Game;

public class ListModel : PageModel
{
    private readonly IGameService _service;
    public List<GameDto> Game { get; set; }

    
    public ListModel(IGameService service)
    {
        Game = new List<GameDto>();
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