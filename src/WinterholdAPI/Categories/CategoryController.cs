using Microsoft.AspNetCore.Mvc;

namespace WinterholdAPI.Categories;

[Route("api/v1/category")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly CategoryService _service;

    public CategoryController(CategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get(string name)
    {
        var dto = _service.Get(name);
        return Ok(dto);
    }

    [HttpPost]
    public IActionResult Insert(CategoryFormDTO dto)
    {
        dto = _service.Insert(dto);
        return Created("", dto);
    }

    [HttpPut]
    public IActionResult Put(CategoryFormDTO dto)
    {
        dto = _service.Update(dto);
        return Ok(dto);
    }
}