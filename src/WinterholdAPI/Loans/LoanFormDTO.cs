using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WinterholdAPI.Loans;

public class LoanFormDTO
{
    public long Id { get; set; }
    [Required]
    [StringLength(maximumLength:20)]
    public string CustomerNumber { get; set; } = null!;
    [Required]
    [StringLength(maximumLength:20)]
    public string BookCode { get; set; } = null!;
    [Required]
    public DateTime LoanDate { get; set; }
    [StringLength(maximumLength:500)]
    public string? Note { get; set; }

    public List<SelectListItem>? Customers { get; set; } = new List<SelectListItem>();
    public List<SelectListItem>? Books { get; set; } = new List<SelectListItem>();
}