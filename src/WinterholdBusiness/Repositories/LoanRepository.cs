using Microsoft.EntityFrameworkCore;
using WinterholdBusiness.Interfaces;
using WinterholdDataAccess.Models;

namespace WinterholdBusiness.Repositories;

public class LoanRepository : ILoanRepository
{
    private readonly WinterholdContext _dbContext;

    public LoanRepository(WinterholdContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Loan> Get(int pageNumber, int pageSize, string bookTitle, string customerName)
    {
        return _dbContext.Loans
        .Include(loan => loan.BookCodeNavigation)
        .Include(loan => loan.CustomerNumberNavigation)
        .Where(loan => loan.BookCodeNavigation.Title.ToLower().Contains(bookTitle??"".ToLower()) 
        && (loan.CustomerNumberNavigation.FirstName + " " + loan.CustomerNumberNavigation.LastName).ToLower().Contains(customerName??"".ToLower()))
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToList();
    }

    public Loan GetDetail(long id)
    {
        return _dbContext.Loans
        .Include(loan => loan.CustomerNumberNavigation)
        .Include(loan => loan.BookCodeNavigation)
        .ThenInclude(loan => loan.Author)
        .Include(loan => loan.BookCodeNavigation)
        .ThenInclude(loan => loan.CategoryNameNavigation)
        .Where(loan => loan.Id == id)
        .FirstOrDefault();
    }

    public Loan Get(long id)
    {
        return _dbContext.Loans.Find(id);
    }

    public int Count(string bookTitle, string customerName)
    {
        return _dbContext.Loans
        .Where(loan => loan.BookCodeNavigation.Title.ToLower().Contains(bookTitle??"".ToLower()) 
        && (loan.CustomerNumberNavigation.FirstName + " " + loan.CustomerNumberNavigation.LastName).ToLower().Contains(customerName??"".ToLower()))
        .Count();
    }

    public Loan Insert(Loan model)
    {
        _dbContext.Loans.Add(model);
        _dbContext.SaveChanges();
        return model;
    }

    public Loan Update(Loan model)
    {
        _dbContext.Loans.Update(model);
        _dbContext.SaveChanges();
        return model;
    }
}