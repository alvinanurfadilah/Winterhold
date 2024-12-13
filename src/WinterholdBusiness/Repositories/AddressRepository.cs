using WinterholdBusiness.Interfaces;
using WinterholdDataAccess.Models;

namespace WinterholdBusiness.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly WinterholdContext _dbContext;

    public AddressRepository(WinterholdContext dbContext)
    {
        _dbContext = dbContext;
    }

    // public void Insert(List<Address> model)
    // {
    //     _dbContext.Addresses.Add(model[0]);
    //     _dbContext.Addresses.Add(model[1]);
    //     _dbContext.Addresses.Add(model[2]);
    //     _dbContext.SaveChanges();
    // }

    public void Insert(Address model)
    {
        _dbContext.Addresses.Add(model);
        _dbContext.SaveChanges();
    }
}
