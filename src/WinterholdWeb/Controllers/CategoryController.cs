using Microsoft.AspNetCore.Mvc;
using WinterholdWeb.Services;

namespace WinterholdWeb.Controllers;

public class CategoryController : Controller
{
    private readonly CategoryService _service;

    public CategoryController(CategoryService service)
    {
        _service = service;
    }

    public IActionResult Index(int pageNumber = 1, int pageSize = 10, string name = "")
    {
        var viewModel = _service.Get(pageNumber, pageSize, name);
        return View(viewModel);
    }

    [HttpGet("categorybook/book/{name}")]
    public IActionResult GetCategoryBook()
    {
        return RedirectToAction("Index", "Book");
    }

    [HttpGet("category/delete/{name}")]
    public IActionResult Delete(string name)
    {
        try
        {
            _service.Delete(name);
            return RedirectToAction("Index");
        }
        catch (System.Exception)
        {
            return View("Delete");
        }
    }
}