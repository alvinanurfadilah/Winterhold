namespace WinterholdWeb.ViewModels.Loan;

public class LoanIndexViewModel
{
    public List<LoanViewModel> Loans { get; set; }
    public PaginationViewModel Pagination { get; set; }
    public string BookTitle { get; set; }
    public string CustomerName { get; set; }
}
