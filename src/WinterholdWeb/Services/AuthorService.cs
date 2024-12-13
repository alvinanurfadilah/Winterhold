using WinterholdBusiness.Interfaces;
using WinterholdDataAccess.Models;
using WinterholdWeb.ViewModels;
using WinterholdWeb.ViewModels.Author;
using WinterholdWeb.ViewModels.Book;

namespace WinterholdWeb.Services;

public class AuthorService
{
    private readonly IAuthorRepository _repository;

    public AuthorService(IAuthorRepository repository)
    {
        _repository = repository;
    }

    public int GetAge(DateTime birthDate, DateTime? deceasedDate)
    {
        TimeSpan durasi;
        if (deceasedDate == null)
        {
            DateTime today = DateTime.Today;
            durasi = today - birthDate;
        } else
        {
            durasi = deceasedDate.Value - birthDate;
            
        }
        int age = (int)durasi.TotalDays/365;
        return age;
    }

    public string GetStatus(DateTime? DeceasedDate)
    {
        var status = DeceasedDate == null ? "Alive" : "Deceased";
        return status;
    }

    public AuthorIndexViewModel Get(int pageNumber, int pageSize, string name)
    {
        var model = _repository.Get(pageNumber, pageSize, name)
        .Select(auth => new AuthorViewModel() {
            Id = auth.Id,
            FullName = auth.Title + " " + auth.FirstName + " " + auth.LastName,
            Age = GetAge(auth.BirthDate, auth.DeceasedDate),
            Status = GetStatus(auth.DeceasedDate),
            Education = auth.Education
        });

        return new AuthorIndexViewModel()
        {
            Authors = model.ToList(),
            Pagination = new PaginationViewModel() {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRows = _repository.Count(name)
            },
            Name = name
        };
    }

    public AuthorFormViewModel Get(long id)
    {
        var model = _repository.Get(id);

        return new AuthorFormViewModel()
        {
            Id = model.Id,
            Title = model.Title,
            FirstName = model.FirstName,
            LastName = model.LastName,
            BirthDate = model.BirthDate,
            DeceasedDate = model.DeceasedDate,
            Education = model.Education,
            Summary = model.Summary
        };
    }

    public AuthorBooksViewModel GetAuthorBook(long id)
    {
        var model = _repository.GetAuthorBooks(id);
        var authorBook = new List<BookViewModel>();

        foreach (var item in model.Books)
        {
            var bookViewModel = new BookViewModel()
            {
                Title = item.Title,
                CategoryName = item.CategoryName,
                IsBorrowed = item.IsBorrowed == true ? "Borrowed" : "Available",
                ReleaseDate = item.ReleaseDate?.ToString("dd/MM/yyyy"),
                TotalPage = item.TotalPage
            };

            authorBook.Add(bookViewModel);
        }

        return new AuthorBooksViewModel()
        {
            FullName = model.Title + " " + model.FirstName + " " + model.LastName,
            BirthDate = model.BirthDate.ToString("dd MMMM yyyy"),
            DeceasedDate = model.DeceasedDate == null ? "-" : model.DeceasedDate?.ToString("dd MMMM yyyy"),
            Education = model.Education,
            Summary = model.Summary,
            AuthorBooks = authorBook
        };
    }

    public void Insert(AuthorFormViewModel viewModel)
    {
        var model = new Author()
        {
            Title = viewModel.Title,
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            BirthDate = viewModel.BirthDate,
            DeceasedDate = viewModel.DeceasedDate,
            Education = viewModel.Education,
            Summary = viewModel.Summary
        };

        _repository.Insert(model);
    }

    public void Update(AuthorFormViewModel viewModel)
    {
        var model = new Author()
        {
            Id = viewModel.Id,
            Title = viewModel.Title,
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            BirthDate = viewModel.BirthDate,
            DeceasedDate = viewModel.DeceasedDate,
            Education = viewModel.Education,
            Summary = viewModel.Summary
        };

        _repository.Update(model);
    }

    public void Delete(long id)
    {
        var model = _repository.Get(id);
        _repository.Delete(model);
    }
}