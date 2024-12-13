using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WinterholdDataAccess.Models;
using WinterholdWeb.Validation;

namespace WinterholdWeb.ViewModels.Customer;

public class CustomerFormViewModel
{
    [Required]
    [StringLength(maximumLength:20)]
    // [UniqueMembershipNumber]
    public string MembershipNumber { get; set; } = null!;

    [Required]
    [StringLength(maximumLength:50)]
    public string FirstName { get; set; } = null!;

    [StringLength(maximumLength:50)]
    public string? LastName { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    [StringLength(maximumLength:10)]
    public string Gender { get; set; }

    [StringLength(maximumLength:20)]
    public string? Phone { get; set; }
    public DateTime MembershipExpireDate { get; set; }
    
    [StringLength(maximumLength:500)]
    public string? Address { get; set; }

    public List<SelectListItem> Genders { get; set; } = new List<SelectListItem>();
}
