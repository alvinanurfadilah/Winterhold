using Microsoft.AspNetCore.Mvc.Rendering;
using WinterholdBusiness.Interfaces;
using WinterholdDataAccess.Models;

namespace WinterholdAPI.Loans;

public class LoanService
{
    private readonly ILoanRepository _repository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IBookRepository _bookRepository;

    public LoanService(ILoanRepository repository, ICustomerRepository customerRepository, IBookRepository bookRepository)
    {
        _repository = repository;
        _customerRepository = customerRepository;
        _bookRepository = bookRepository;
    }

    public LoanDetailDTO GetDetail(long id)
    {
        var model = _repository.GetDetail(id);

        return new LoanDetailDTO()
        {
            Id = model.Id,
            Title = model.BookCodeNavigation.Title,
            CategoryName = model.BookCodeNavigation.CategoryName,
            Author = model.BookCodeNavigation.Author.FirstName + " " + model.BookCodeNavigation?.Author.LastName,
            Floor = model.BookCodeNavigation.CategoryNameNavigation.Floor,
            Isle = model.BookCodeNavigation.CategoryNameNavigation.Isle,
            Bay = model.BookCodeNavigation.CategoryNameNavigation.Bay,

            MembershipNumber = model.CustomerNumberNavigation.MembershipNumber,
            FullName = model.CustomerNumberNavigation.FirstName + " " + model.CustomerNumberNavigation.LastName,
            Phone = model.CustomerNumberNavigation?.Phone,
            MembershipExpireDate = model.CustomerNumberNavigation?.MembershipExpireDate.ToString("dd/MM/yyyy")
        };
    }

    private List<SelectListItem> GetCustomers()
    {
        var model = _customerRepository.Get()
        .Where(customer => customer.MembershipExpireDate > DateTime.Today)
        .Select(cus => new SelectListItem() {
            Text = cus.FirstName + " " + cus.LastName,
            Value = cus.MembershipNumber
        }).ToList();

        return model;
    }

    // private List<SelectListItem> GetBooks(string categoryName)
    // {
    //     var model = _bookRepository.GetForm(categoryName)
    //     .Where(book => book.IsBorrowed == false)
    //     .Select(book => new SelectListItem() {
    //         Text = book.Title,
    //         Value = book.Code
    //     }).ToList();

    //     return model;
    // }

    // public LoanFormDTO Get(string categoryName)
    // {
    //     return new LoanFormDTO()
    //     {
    //         Customers = GetCustomers(),
    //         Books = GetBooks(categoryName)
    //     };
    // }

    private List<SelectListItem> GetBooks()
    {
        var model = _bookRepository.GetForm()
        .Where(book => book.IsBorrowed == false)
        .Select(book => new SelectListItem() {
            Text = book.Title,
            Value = book.Code
        }).ToList();

        return model;
    }

    public LoanFormDTO Get()
    {
        return new LoanFormDTO()
        { 
            Customers = GetCustomers(),
            Books = GetBooks()
        };
    }

    public LoanFormDTO Get(long id)
    {
        var model = _repository.Get(id);

        return new LoanFormDTO()
        {
            Id = model.Id,
            CustomerNumber = model.CustomerNumber,
            BookCode = model.BookCode,
            LoanDate = model.LoanDate,
            Note = model.Note,
            Customers = GetCustomers(),
            Books = GetBooks()
        };
    }

    public LoanFormDTO Insert(LoanFormDTO dto)
    {
        var model = new Loan()
        {
            CustomerNumber = dto.CustomerNumber,
            BookCode = dto.BookCode,
            LoanDate = dto.LoanDate,
            Note = dto.Note,
            DueDate = dto.LoanDate.AddDays(5)
        };

        var result = _repository.Insert(model);

        var updateStatusBook = _bookRepository.Get(dto.BookCode);
        updateStatusBook.IsBorrowed = true;
        _bookRepository.Update(updateStatusBook);

        return new LoanFormDTO()
        {
            CustomerNumber = result.CustomerNumber,
            BookCode = result.BookCode,
            LoanDate = result.LoanDate,
            Note = result.Note
        };
    }

    public LoanFormDTO Update(LoanFormDTO dto)
    {
        var getLoan = _repository.Get(dto.Id);
        getLoan.CustomerNumber = dto.CustomerNumber;
        getLoan.BookCode = dto.BookCode;
        getLoan.LoanDate = dto.LoanDate;
        getLoan.Note = dto.Note;

        var updateStatusBook = _bookRepository.Get(getLoan.BookCode);
        updateStatusBook.IsBorrowed = false;
        _bookRepository.Update(updateStatusBook);

        var updateNewStatusBook = _bookRepository.Get(dto.BookCode);
        updateNewStatusBook.IsBorrowed = true;
        _bookRepository.Update(updateNewStatusBook);

        var result = _repository.Update(getLoan);

        return new LoanFormDTO()
        {
            Id = result.Id,
            CustomerNumber = result.CustomerNumber,
            BookCode = result.BookCode,
            LoanDate = result.LoanDate,
            Note = result.Note,
        };
    }
}