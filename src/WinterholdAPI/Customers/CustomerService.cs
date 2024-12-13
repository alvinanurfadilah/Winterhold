using WinterholdBusiness.Interfaces;

namespace WinterholdAPI.Customers;

public class CustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public CustomerDTO Get(string membershipNumber)
    {
        var dto = _repository.Get(membershipNumber);
        return new CustomerDTO()
        {
            MembershipNumber = dto.MembershipNumber,
            FullName = dto.FirstName + " " + dto.LastName,
            BirthDate = dto.BirthDate.ToString("dd/MM/yyyy"),
            Gender = dto.Gender,
            Phone = dto.Phone,
            Address = dto.Address
        };
    }
}