using Microsoft.AspNetCore.Mvc;

namespace WinterholdWeb.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View("Index");
    }
}