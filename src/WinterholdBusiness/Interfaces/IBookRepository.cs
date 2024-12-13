using WinterholdDataAccess.Models;

namespace WinterholdBusiness.Interfaces;

public interface IBookRepository
{
    public List<Book> GetForm(string categoryName);
    public List<Book> GetForm();
    public List<Book> Get(string categoryName, int pageNumber, int pageSize, string title, string author, bool isBorrowed);
    public Book Get(string code);
    public Book GetSummary(string code);
    public int Count(string name, string title, string author, bool isBorrowed);
    public void Insert(Book model);
    public void Update(Book model);
    public void Delete(Book model);
}