using Microsoft.AspNetCore.Mvc;

namespace WinterholdAPI.Books;

[Route("api/v1/book")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly BookService _service;

    public BookController(BookService service)
    {
        _service = service;
    }

    [HttpGet("summary")]
    public IActionResult GetSummary(string code)
    {
        var dto = _service.GetSummary(code);
        return Ok(dto);
    }
}
