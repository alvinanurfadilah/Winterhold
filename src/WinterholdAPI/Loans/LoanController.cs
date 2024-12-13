using Microsoft.AspNetCore.Mvc;

namespace WinterholdAPI.Loans;

[Route("api/v1/loan")]
[ApiController]
public class LoanController : ControllerBase
{   
    private readonly LoanService _service;

    public LoanController(LoanService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var dto = _service.Get();
        return Ok(dto);
    }

    [HttpGet("{id}")]
    public IActionResult Get(long id)
    {
        var dto = _service.Get(id);
        return Ok(dto);
    }

    [HttpGet("detail/{id}")]
    public IActionResult GetDetail(long id)
    {
        var dto = _service.GetDetail(id);
        return Ok(dto);
    }

    [HttpPost]
    public IActionResult Insert(LoanFormDTO dto)
    {
        dto = _service.Insert(dto);
        return Created("", dto);
    }

    [HttpPut]
    public IActionResult Put(LoanFormDTO dto)
    {
        dto = _service.Update(dto);
        return Ok(dto);
    }
}