using System.Net.Sockets;
using Microsoft.AspNetCore.Mvc.Rendering;
using WinterholdBusiness.Interfaces;
using WinterholdDataAccess.Models;
using WinterholdWeb.ViewModels;
using WinterholdWeb.ViewModels.Customer;

namespace WinterholdWeb.Services;

public class CustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public DateTime GetExpiredDate()
    {
        DateTime today = DateTime.Today;
        DateTime expired = today.AddYears(2);

        return expired;
    }

    public CustomerIndexViewModel Get(int pageNumber, int pageSize, string membershipNumber, string fullName, bool membershipExpireDate)
    {
        var model = _repository.Get(pageNumber, pageSize, membershipNumber, fullName, membershipExpireDate)
        .Select(customer => new CustomerViewModel() {
            MembershipNumber = customer.MembershipNumber,
            FullName = customer.FirstName + " " + customer.LastName,
            MembershipExpireDate = customer.MembershipExpireDate.ToString("dd/MM/yyyy")
        });

        return new CustomerIndexViewModel()
        {
            Customers = model.ToList(),
            Pagination = new PaginationViewModel() {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalRows = _repository.Count(membershipNumber, fullName, membershipExpireDate)
            },
            MembershipNumber = membershipNumber,
            FullName = fullName,
            MembershipExpireDate = membershipExpireDate
        };
    }

    private List<SelectListItem> GetGenders()
    {
        return new List<SelectListItem>()
        {
            new SelectListItem()
            {
                Text = "Female",
                Value = "Female"
            },
            new SelectListItem()
            {
                Text = "Male",
                Value = "Female"
            }
        };
    }

    public CustomerFormViewModel Get()
    {
        return new CustomerFormViewModel()
        {
            Genders = GetGenders()
        };
    }

    public CustomerFormViewModel Get(string membershipNumber)
    {
        var model = _repository.Get(membershipNumber);

        return new CustomerFormViewModel()
        {
            MembershipNumber = model.MembershipNumber,
            FirstName = model.FirstName,
            LastName = model.LastName,
            BirthDate = model.BirthDate,
            Gender = model.Gender,
            Phone = model.Phone,
            Address = model.Address,
            MembershipExpireDate = model.MembershipExpireDate,
            Genders = GetGenders()
        };
    }

    public void Insert(CustomerFormViewModel viewModel)
    {
        var model = new Customer()
        {
            MembershipNumber = viewModel.MembershipNumber,
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            BirthDate = viewModel.BirthDate,
            Gender = viewModel.Gender,
            Phone = viewModel.Phone,
            Address = viewModel.Address,
            MembershipExpireDate = GetExpiredDate()
        };
        _repository.Insert(model);
        
    }

    public void Update(CustomerFormViewModel viewModel)
    {
        var model = new Customer()
        {
            MembershipNumber = viewModel.MembershipNumber,
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            BirthDate = viewModel.BirthDate,
            Gender = viewModel.Gender,
            Phone = viewModel.Phone,
            Address = viewModel.Address
        };

        _repository.Update(model);
    }

    public void Delete(string membershipNumber)
    {
        var model = _repository.Get(membershipNumber);
        _repository.Delete(model);
    }

    public void Extend(string membershipNumber)
    {
        var model = _repository.Get(membershipNumber);
        var getExpired = model.MembershipExpireDate;
        model.MembershipExpireDate = getExpired.AddYears(2);

        _repository.Update(model);
    }
}
