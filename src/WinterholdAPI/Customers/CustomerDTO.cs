namespace WinterholdAPI.Customers;

public class CustomerDTO
{
    public string MembershipNumber { get; set; } = null!;
    public string FullName { get; set; }
    public string BirthDate { get; set; }
    public string Gender { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Address { get; set; }
}