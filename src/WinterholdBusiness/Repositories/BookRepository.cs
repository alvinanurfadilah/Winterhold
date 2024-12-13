using Microsoft.EntityFrameworkCore;
using WinterholdBusiness.Interfaces;
using WinterholdDataAccess.Models;

namespace WinterholdBusiness.Repositories;

public class BookRepository : IBookRepository
{
    private readonly WinterholdContext _dbContext;

    public BookRepository(WinterholdContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Book> GetForm(string categoryName)
    {
        return _dbContext.Books
        .Where(book => book.CategoryName == categoryName)
        .ToList();
    }
    public List<Book> GetForm()
    {
        return _dbContext.Books
        .ToList();
    }

    public List<Book> Get(string categoryName, int pageNumber, int pageSize, string title, string author, bool isBorrowed)
    {
        return _dbContext.Books
        .Include(book => book.CategoryNameNavigation)
        .Include(book => book.Author)
        .Where(book => book.Title.ToLower().Contains(title??"".ToLower()) 
        && (book.Author.FirstName + " " + book.Author.LastName).ToLower().Contains(author??"".ToLower())
        && book.CategoryNameNavigation.Name == categoryName
        && (isBorrowed ? (book.IsBorrowed == false) : true))
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToList();
    }

    public Book Get(string code)
    {
        return _dbContext.Books.Find(code);
    }

    public Book GetSummary(string code)
    {
        return _dbContext.Books
        .Where(book => book.Code == code)
        .FirstOrDefault();
    }

    public int Count(string categoryName, string title, string author, bool isBorrowed)
    {
        return _dbContext.Books
        .Where(book => book.Title.ToLower().Contains(title??"".ToLower()) 
        && (book.Author.FirstName + " " + book.Author.LastName).ToLower().Contains(author??"".ToLower())
        && book.CategoryNameNavigation.Name == categoryName
        && isBorrowed ? book.IsBorrowed == false : true)
        .Count();
    }

    public void Insert(Book model)
    {
        _dbContext.Books.Add(model);
        _dbContext.SaveChanges();
    }

    public void Update(Book model)
    {
        _dbContext.Books.Update(model);
        _dbContext.SaveChanges();
    }

    public void Delete(Book model)
    {
        _dbContext.Books.Remove(model);
        _dbContext.SaveChanges();
    }
}