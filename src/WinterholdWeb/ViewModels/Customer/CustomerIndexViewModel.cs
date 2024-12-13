namespace WinterholdWeb.ViewModels.Customer;

public class CustomerIndexViewModel
{
    public List<CustomerViewModel> Customers { get; set; }
    public PaginationViewModel Pagination { get; set; }
    public string MembershipNumber { get; set; }
    public string FullName { get; set; }
    public bool MembershipExpireDate { get; set; }
}
