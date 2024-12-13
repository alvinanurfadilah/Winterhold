using WinterholdDataAccess.Models;

namespace WinterholdBusiness.Interfaces;

public interface ILoanRepository
{
    public List<Loan> Get(int pageNumber, int pageSize, string bookTitle, string customerName);
    public Loan GetDetail(long id);
    public Loan Get(long id);
    public int Count(string bookTitle, string customerName);
    public Loan Insert(Loan model);
    public Loan Update(Loan model);
}