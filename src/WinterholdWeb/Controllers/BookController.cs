using Microsoft.AspNetCore.Mvc;
using WinterholdWeb.Services;
using WinterholdWeb.ViewModels.Book;

namespace WinterholdWeb.Controllers;

public class BookController : Controller
{
    private readonly BookService _service;

    public BookController(BookService service)
    {
        _service = service;
    }

    [HttpGet("book/{name}")]
    public IActionResult Index(string name, int pageNumber = 1, int pageSize = 10, string title = "", string author = "", bool isBorrowed = true)
    {
        var viewModel = _service.Get(name, pageNumber, pageSize, title, author, isBorrowed);
        return View(viewModel);
    }

    [HttpGet("book/form")]
    public IActionResult Add(string categoryName)
    {
        var viewModel = _service.GetForm(categoryName);
        return View("Form", viewModel);
    }

    [HttpPost("book/form")]
    public IActionResult Insert(BookFormViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            _service.Insert(viewModel);
            return RedirectToAction("Index", "Book", new {name = viewModel.CategoryName});
        }

        var vm = _service.GetForm(viewModel.CategoryName);
        return View("Form", vm);
    }

    [HttpGet("book/form/{code}")]
    public IActionResult Edit(string code)
    {
        var viewModel = _service.Get(code);
        return View("Form", viewModel);
    }

    [HttpPost("book/form/{code}")]
    public IActionResult Update(BookFormViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            _service.Update(viewModel);
            return RedirectToAction("Index", "Book", new {name = viewModel.CategoryName});
        }

        var vm = _service.GetForm(viewModel.CategoryName);
        return View("Form", vm);
    }

    [HttpGet("book/delete/{code}")]
    public IActionResult Delete(string code)
    {
        try
        {
            var viewModel = _service.Get(code);
            _service.Delete(code);
            return RedirectToAction("Index", "Book", new {name = viewModel.CategoryName});
        }
        catch (System.Exception)
        {
            return View("Delete");
        }
    }
}
