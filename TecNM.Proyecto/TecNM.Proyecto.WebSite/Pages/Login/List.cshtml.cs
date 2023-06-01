using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Proyecto.Api.DataAccess;
using TecNM.Proyecto.Api.DataAccess.Interfaces;
using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.WebSite.Service.Interfaces;

namespace TecNM.Proyecto.WebSite.Pages.Login;

public class ListModel : PageModel
{
    [BindProperty]
    public string Username { get; set; }

    [BindProperty]
    public string Password { get; set; }
    
    private readonly IUserService _service;
    public UserDto Users { get; set; }

    public string Msg { get; set; }
    
    public ListModel(IUserService service)
    {
        Users = new UserDto();
        _service = service;
    }

    public async Task<IActionResult> OnPost()
    {
        var response = await _service.GetAllAsync();
        var users = response.Data;
        
        var user = users.FirstOrDefault(u => u.Username.Equals(Username, StringComparison.OrdinalIgnoreCase));

        if (user != null && user.Password == Password)
        {
            // Usuario encontrado en la base de datos y la contraseña coincide
            return RedirectToPage("./List");
        }
        else
        {
            Msg = "Invalid";
            return Page();
        }
    }
}

