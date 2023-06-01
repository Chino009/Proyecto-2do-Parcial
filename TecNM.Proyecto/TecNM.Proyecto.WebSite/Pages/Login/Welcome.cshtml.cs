using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TecNM.Proyecto.WebSite.Pages.Login;

public class Welcome : PageModel
{
    public string Username { get; set; }

    public void OnGet()
    {
        Username = HttpContext.Session.GetString("username");
    }

    public IActionResult OnGetLogout()
    {
        HttpContext.Session.Remove("username");
        return RedirectToPage("/Index");
    }
}