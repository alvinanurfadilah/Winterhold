using Microsoft.AspNetCore.Mvc.Rendering;
using WinterholdBusiness.Interfaces;
using WinterholdDataAccess.Models;
using WinterholdWeb.ViewModels;
using WinterholdWeb.ViewModels.Book;
using WinterholdWeb.ViewModels.Category;

namespace WinterholdWeb.Services;

public class BookService
{
    private readonly IBookRepository _repository;
    private readonly IAuthorRepository _authorRepository;

    public BookService(IBookRepository repository, IAuthorRepository authorRepository)
    {
        _repository = repository;
        _authorRepository = authorRepository;
    }

    private List<SelectListItem> GetAuthors()
    {
        var model = _authorRepository.Get()
        .Select(author => new SelectListItem() {
            Text = author.Title + " " + author.FirstName + " " + author.LastName,
            Value = author.Id.ToString()
        }).ToList();

        return model;
    }

    public string IsBorrowed(bool isBorrowed)
    {
        var status = isBorrowed == true ? "Borrowed" : "Available";
        return status;
    }

    public BookIndexViewModel Get(string categoryName, int pageNumber, int pageSize, string title, string author, bool isBorrowed)
    {
        var model = _repository.Get(categoryName, pageNumber, pageSize, title, author, isBorrowed)
        .Select(book => new BookViewModel() {
            Code = book.Code,
            Title = book.Title,
            CategoryName = book.CategoryName,
            Author = book.Author?.Title + " " + book.Author?.FirstName + " " + book.Author?.LastName,
            IsBorrowed = IsBorrowed(book.IsBorrowed),
            ReleaseDate = book.ReleaseDate?.ToString("dd/MM/yyyy"),
            TotalPage = book.TotalPage,
            Summary = book.Summary
        });

        return new BookIndexViewModel()
        {
            Books = model.ToList(),
            Pagination = new PaginationViewModel() {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRows = _repository.Count(categoryName, title, author, isBorrowed)
            },
            Title = title,
            Author = author,
            IsBorrowed = isBorrowed,
            Name = categoryName
        };
    }

    public BookFormViewModel GetForm(string categoryName)
    {
        return new BookFormViewModel()
        {
            Authors = GetAuthors(),
            CategoryName = categoryName
        };
    }

    public BookFormViewModel Get(string code)
    {
        var model = _repository.Get(code);

        return new BookFormViewModel()
        {
            Code = model.Code,
            Title = model.Title,
            CategoryName = model.CategoryName,
            AuthorId = model.AuthorId,
            ReleaseDate = model.ReleaseDate,
            TotalPage = model.TotalPage,
            Summary = model.Summary,
            Authors = GetAuthors()
        };
    }

    public void Insert(BookFormViewModel viewModel)
    {
        var model = new Book()
        {
            Code = viewModel.Code,
            Title = viewModel.Title,
            CategoryName = viewModel.CategoryName,
            AuthorId = viewModel.AuthorId,
            ReleaseDate = viewModel.ReleaseDate,
            TotalPage = viewModel.TotalPage,
            Summary = viewModel.Summary
        };

        _repository.Insert(model);
    }

    public void Update(BookFormViewModel viewModel)
    {
        var model = new Book()
        {
            Code = viewModel.Code,
            Title = viewModel.Title,
            CategoryName = viewModel.CategoryName,
            AuthorId = viewModel.AuthorId,
            ReleaseDate = viewModel.ReleaseDate,
            TotalPage = viewModel.TotalPage,
            Summary = viewModel.Summary
        };

        _repository.Update(model);
    }

    public void Delete(string code)
    {
        var model = _repository.Get(code);
        _repository.Delete(model);
    }
}

