using Microsoft.AspNetCore.Mvc;
using WinterholdAPI.Customers;

namespace WinterholdAPI;

[Route("api/v1/customer")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly CustomerService _service;

    public CustomerController(CustomerService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get(string membershipNumber)
    {
        var dto = _service.Get(membershipNumber);
        return Ok(dto);
    }
}
