using WinterholdBusiness.Interfaces;
using WinterholdWeb.ViewModels;
using WinterholdWeb.ViewModels.Loan;

namespace WinterholdWeb.Services;

public class LoanService
{
    private readonly ILoanRepository _repository;
    private readonly IBookRepository _bookRepository;

    public LoanService(ILoanRepository repository, IBookRepository bookRepository)
    {
        _repository = repository;
        _bookRepository = bookRepository;
    }
    
    public LoanIndexViewModel Get(int pageNumber, int pageSize, string bookTitle, string customerName)
    {
        var model = _repository.Get(pageNumber, pageSize, bookTitle, customerName)
        .Select(loan => new LoanViewModel() {
            Id = loan.Id,
            BookTitle = loan.BookCodeNavigation.Title,
            CustomerName = loan.CustomerNumberNavigation.FirstName + " " + loan.CustomerNumberNavigation.LastName,
            LoanDate = loan.LoanDate.ToString("dd/MM/yyyy"),
            DueDate = loan.DueDate.ToString("dd/MM/yyyy"),
            ReturnDate = loan.ReturnDate != null ? loan.ReturnDate?.ToString("dd/MM/yyyy") : "-"
        });

        return new LoanIndexViewModel()
        {
            Loans = model.ToList(),
            Pagination = new PaginationViewModel() {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRows = _repository.Count(bookTitle, customerName)
            },
            BookTitle = bookTitle,
            CustomerName = customerName
        };
    }

    public void Return(long id)
    {
        var model = _repository.Get(id);
        model.ReturnDate = DateTime.Today;

        var updateStatusBook = _bookRepository.Get(model.BookCode);
        updateStatusBook.IsBorrowed = false;
        _bookRepository.Update(updateStatusBook);

        _repository.Update(model);
    }
}
