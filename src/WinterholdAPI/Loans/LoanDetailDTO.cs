namespace WinterholdAPI.Loans;

public class LoanDetailDTO
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public string CategoryName { get; set; } = null!;
    public string Author { get; set; }
    public int Floor { get; set; }
    public string Isle { get; set; }
    public string Bay { get; set; }


    public string MembershipNumber { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string MembershipExpireDate { get; set; }
}
