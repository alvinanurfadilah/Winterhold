using WinterholdBusiness.Interfaces;
using WinterholdDataAccess.Models;

namespace WinterholdAPI.Categories;

public class CategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public CategoryFormDTO Get(string name)
    {
        var model = _repository.Get(name);

        return new CategoryFormDTO()
        {
            Name = model.Name,
            Floor = model.Floor,
            Isle = model.Isle,
            Bay = model.Bay
        };
    }

    public CategoryFormDTO Insert(CategoryFormDTO dto)
    {
        var model = new Category()
        {
            Name = dto.Name,
            Floor = dto.Floor,
            Isle = dto.Isle,
            Bay = dto.Bay
        };

        var result = _repository.Insert(model);
        return new CategoryFormDTO()
        {
            Name = result.Name,
            Floor = result.Floor,
            Isle = result.Isle,
            Bay = result.Bay
        };
    }

    public CategoryFormDTO Update(CategoryFormDTO dto)
    {
        var model = new Category()
        {
            Name = dto.Name,
            Floor = dto.Floor,
            Isle = dto.Isle,
            Bay = dto.Bay
        };

        var result = _repository.Update(model);
        return new CategoryFormDTO()
        {
            Name = result.Name,
            Floor = result.Floor,
            Isle = result.Isle,
            Bay = result.Bay
        };
    }
}
