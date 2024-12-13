using Microsoft.AspNetCore.Mvc;
using WinterholdDataAccess.Models;
using WinterholdWeb.Services;

namespace WinterholdWeb.Controllers;

public class LoanController : Controller
{
    private readonly LoanService _service;

    public LoanController(LoanService service)
    {
        _service = service;
    }

    public IActionResult Index(int pageNumber = 1, int pageSize = 10, string bookTitle = "", string customerName = "")
    {
        var viewModel = _service.Get(pageNumber, pageSize, bookTitle, customerName);
        return View(viewModel);
    }

    [HttpGet("loan/return/{id}")]
    public IActionResult Return(long id)
    {
        _service.Return(id);
        return RedirectToAction("Index");
    }
}
