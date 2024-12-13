using WinterholdDataAccess.Models;

namespace WinterholdBusiness.Interfaces;

public interface ICustomerRepository
{
    public List<Customer> Get();
    public List<Customer> Get(int pageNumber, int pageSize, string membershipNumber, string fullName, bool membershipExpireDate);
    public Customer Get(string membershipNumber);
    public int Count(string membershipNumber, string fullName, bool membershipExpireDate);
    public void Insert(Customer model);
    public void Update(Customer model);
    public void Delete(Customer model);
}
