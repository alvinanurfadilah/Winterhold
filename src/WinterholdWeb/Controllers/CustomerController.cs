using Microsoft.AspNetCore.Mvc;
using WinterholdWeb.Services;
using WinterholdWeb.ViewModels.Customer;

namespace WinterholdWeb.Controllers;

public class CustomerController : Controller
{
    private readonly CustomerService _service;

    public CustomerController(CustomerService service)
    {
        _service = service;
    }

    [HttpGet("customer")]
    public IActionResult Index(int pageNumber = 1, int pageSize = 10, string membershipNumber = "", string fullName = "", bool membershipExpireDate = false)
    {
        var viewModel = _service.Get(pageNumber, pageSize, membershipNumber, fullName, membershipExpireDate);
        return View(viewModel);
    }

    [HttpGet("customer/form")]
    public IActionResult Add()
    {
        var viewModel = _service.Get();
        return View("Form", viewModel);
    }

    [HttpPost("customer/form")]
    public IActionResult Insert(CustomerFormViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            _service.Insert(viewModel);
            return RedirectToAction("Index");
        }

        var vm = _service.Get();
        return View("Form", vm);
    }

    [HttpGet("customer/form/{membershipNumber}")]
    public IActionResult Edit(string membershipNumber)
    {
        var viewModel = _service.Get(membershipNumber);
        return View("Form", viewModel);
    }

    [HttpPost("customer/form/{membershipNumber}")]
    public IActionResult Update(CustomerFormViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            _service.Update(viewModel);
            return RedirectToAction("Index");
        }

        var vm = _service.Get();
        return View("Form", vm);
    }

    [HttpGet("customer/delete/{membershipNumber}")]
    public IActionResult Delete(string membershipNumber)
    {
        try
        {
            _service.Delete(membershipNumber);
            return RedirectToAction("Index");
        }
        catch (System.Exception)
        {
            return View("Delete");
        }
    }

    [HttpGet("customer/extend/{membershipNumber}")]
    public IActionResult Extend(string membershipNumber)
    {
        _service.Extend(membershipNumber);
        return RedirectToAction("Index");
    }
}
