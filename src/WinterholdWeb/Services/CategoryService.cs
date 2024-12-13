using WinterholdBusiness.Interfaces;
using WinterholdWeb.ViewModels;
using WinterholdWeb.ViewModels.Book;
using WinterholdWeb.ViewModels.Category;

namespace WinterholdWeb.Services;

public class CategoryService
{
    private readonly ICategoryRepository _repository;
    private readonly IBookRepository _bookRepository;

    public CategoryService(ICategoryRepository repository, IBookRepository bookRepository)
    {
        _repository = repository;
        _bookRepository = bookRepository;
    }

    public int GetTotalBook(string name)
    {
        var totalBook =  _bookRepository.GetForm(name).Where(book => book.CategoryName == name);
        return totalBook.Count();
    }

    public CategoryIndexViewModel Get(int pageNumber, int pageSize, string name)
    {
        var model = _repository.Get(pageNumber, pageSize, name)
        .Select(cat => new CategoryViewModel() {
            Name = cat.Name,
            Floor = cat.Floor,
            Isle = cat.Isle,
            Bay = cat.Bay,
            TotalBooks = GetTotalBook(cat.Name)
        });

        return new CategoryIndexViewModel()
        {
            Categories = model.ToList(),
            Pagination = new PaginationViewModel() {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRows = _repository.Count(name)
            },
            Name = name
        };
    }

    public void Delete(string name)
    {
        var model = _repository.Get(name);
        _repository.Delete(model);
    }
}