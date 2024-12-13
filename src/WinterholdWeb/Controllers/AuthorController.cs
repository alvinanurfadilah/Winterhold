using Microsoft.AspNetCore.Mvc;
using WinterholdWeb.Services;
using WinterholdWeb.ViewModels.Author;

namespace WinterholdWeb.Controllers;

public class AuthorController : Controller
{
    private readonly AuthorService _service;

    public AuthorController(AuthorService service)
    {
        _service = service;
    }

    [HttpGet("author")]
    public IActionResult Index(int pageNumber = 1, int pageSize = 10, string name = "")
    {
        var viewModel = _service.Get(pageNumber, pageSize, name);
        return View(viewModel);
    }

    [HttpGet("author/form")]
    public IActionResult Add()
    {
        return View("Form");
    }

    [HttpPost("author/form")]
    public IActionResult Insert(AuthorFormViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            _service.Insert(viewModel);
            return RedirectToAction("Index", "Author");
        }

        return View("Form");
    }

    [HttpGet("author/form/{id}")]
    public IActionResult Edit(long id)
    {
        var viewModel = _service.Get(id);
        return View("Form", viewModel);
    }

    [HttpPost("author/form/{id}")]
    public IActionResult Update(AuthorFormViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            _service.Update(viewModel);
            return RedirectToAction("Index");
        }
        return View("Form");
    }

    [HttpGet("author/delete/{id}")]
    public IActionResult Delete(long id)
    {
        try
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
        catch (System.Exception)
        {
            return View("Delete");
        }
    }

    [HttpGet("author/book/{id}")]
    public IActionResult GetAuthorBooks(long id)
    {
        var viewModel = _service.GetAuthorBook(id);
        return View("Books", viewModel);
    }
}