using WinterholdBusiness.Interfaces;
using WinterholdDataAccess.Models;

namespace WinterholdBusiness.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly WinterholdContext _dbContext;

    public CustomerRepository(WinterholdContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Customer> Get()
    {
        return _dbContext.Customers.ToList();
    }

    public List<Customer> Get(int pageNumber, int pageSize, string membershipNumber, string fullName, bool membershipExpireDate)
    {
        return _dbContext.Customers
        .Where(customer => customer.MembershipNumber.ToLower().Contains(membershipNumber??"".ToLower()) 
        && (customer.FirstName + " " + customer.LastName).ToLower().Contains(fullName??"".ToLower())
        && (membershipExpireDate ? customer.MembershipExpireDate < DateTime.Today : customer.MembershipExpireDate >= DateTime.Today))
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToList();
    }

    public Customer Get(string membershipNumber)
    {
        return _dbContext.Customers.Find(membershipNumber);
    }

    public int Count(string membershipNumber, string fullName, bool membershipExpireDate)
    {
        return _dbContext.Customers
        .Where(customer => customer.MembershipNumber.ToLower().Contains(membershipNumber??"".ToLower()) 
        && (customer.FirstName + " " + customer.LastName).ToLower().Contains(fullName??"".ToLower())
        && (membershipExpireDate ? customer.MembershipExpireDate < DateTime.Today : customer.MembershipExpireDate >= DateTime.Today))
        .Count();
    }

    public void Insert(Customer model)
    {
        _dbContext.Customers.Add(model);
        _dbContext.SaveChanges();
    }

    public void Update(Customer model)
    {
        _dbContext.Customers.Update(model);
        _dbContext.SaveChanges();
    }

    public void Delete(Customer model)
    {
        _dbContext.Customers.Remove(model);
        _dbContext.SaveChanges();
    }
}
